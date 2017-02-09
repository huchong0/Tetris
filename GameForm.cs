using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class GameForm : Form
    {
        Random rand=new Random();
        OpeningForm father;     //父窗口
        Piece piece;                    //主骨牌，也就是当前操纵的骨牌
        Box[,] board = new Box[12,16];//棋盘
        EventHandler contactBottom;//“触底”事件
        Bitmap pic;                     //画布，用于双缓存
        int difficulty;
        bool transparent;           //是否“透明”模式
        int transTimes=0;
        int score;
        int num;                        //当前消除次数，用来增加难度
        Piece nextPiece;


        public GameForm(OpeningForm fa,int difficulty,bool trans)//构造函数，在游戏开始时做一些初始化工作,
        {                                                                                              //比如初始化第一个骨牌和第二个骨牌
            father = fa;

            InitializeComponent();

            piece = createNewPiece();
            nextPiece = createNewPiece();
            if (nextPiece.color == piece.color) nextPiece = createNewPiece();//降低重复率

            panel2.Invalidate();


            pic = new Bitmap(304, 404);//生成画布,并填充颜色
            Graphics.FromImage(pic).FillRectangle(Brushes.Black, new Rectangle(0, 0, 304, 404));
            pic_Paint();

            //通过难度值来计算自动降下的速率
            timer1.Enabled = true;
            this.difficulty = difficulty;
            timer1.Interval = (11- difficulty) * 100;
            num = 0;
            score = 0;
            transparent = trans;

            labelScore.Text = score.ToString();
            labelDifficulty.Text = difficulty.ToString();

            
            contactBottom += new EventHandler(this.piecePlus);
            contactBottom += new EventHandler(this.check);
        }


        private void piecePlus(object sender,EventArgs e)//将落下触底的主骨牌“固定”在棋盘上
        {
            foreach(Point pos in piece.Positions)
            {
                board[pos.X, pos.Y] = new Box(piece.color, pos.X, pos.Y);
            }
            piece = nextPiece;      //让下一个骨牌成为主骨牌
            if(!piecePass())            //倘若主骨牌已经无法出生，那么游戏结束，停止计时器，消除主骨牌
            {
                timer1.Stop();
                piece = null;
                return;
            }
            nextPiece = createNewPiece();
            if(nextPiece.color==piece.color) nextPiece = createNewPiece(); ;//降低重复率

            panel2.Invalidate();
            ++transTimes;
        }
        private void check(object sender, EventArgs e)//从上到下检测有无某行填满的情况，若有，则调用消除
        {
            for (int index = 0; index < 16; ++index)
            {
                for (int x = 0; x < 12; ++x)
                {
                    if (board[x, index] == null) break;
                    if (x == 11)
                    {
                        disappear(index);
                    }
                }
            }
        }
        private void disappear(int index)//消除指定行，实则将该行之上所有行下移一个单位坐标，然后删除最上行
        {
            //也肩负计数消除次数、增加难度的任务
            score += difficulty;
            ++num;
            labelScore.Text = score.ToString();
            if (num == 5)
            {
                num = 0;
                ++difficulty;
                if (difficulty > 10) difficulty = 10;
                timer1.Interval = (11 - difficulty) * 100;
                labelDifficulty.Text = difficulty.ToString();
            }
            for (; index > 0; --index)
            {
                for (int x = 0; x < 12; ++x)
                {
                    board[x, index] = board[x, index - 1];
                    if (board[x, index] == null) continue;
                    ++board[x, index].y;
                }
            }
            for (int x = 0; x < 12; ++x)
            {
                board[x, 0] = null;
            }
        }
        
        private Piece createNewPiece()
        {
            Piece nextPiece;
            int rad = rand.Next() % 100;
            if (rad < 10) nextPiece = new Piece_I();
            else if (rad < 25) nextPiece = new Piece_J();
            else if (rad < 40) nextPiece = new Piece_L();
            else if (rad < 55) nextPiece = new Piece_O();
            else if (rad < 70) nextPiece = new Piece_S();
            else if (rad < 85) nextPiece = new Piece_T();
            else nextPiece = new Piece_Z();
            return nextPiece;
        }//用随机数生成新骨牌


        private void GameForm_KeyDown(object sender, KeyEventArgs e)//根据按键事件调用移动系函数
        {
            if (piece == null) return;//游戏结束后的情况

            switch (e.KeyCode)
            {
                case Keys.Left:
                    piece.Left();
                    if (!piecePass())
                    {
                        piece.Right();
                        return;
                    }
                    break;
                case Keys.Up:
                    piece.Down();
                    
                    if(!piecePass())
                    {
                        piece.Up();
                        contactBottom(this, new EventArgs());
                    }
                    break;
                case Keys.Right:
                    piece.Right();
                    if (!piecePass())
                    {
                        piece.Left();
                        return;
                    }
                    break;
                case Keys.Down:
                    while(piecePass())
                    {
                        piece.Down();
                    }
                    piece.Up();
                    contactBottom(this, new EventArgs());
                    break;
                case Keys.Space:
                    piece.Rotate();
                    if (!piecePass())
                    {
                        piece.Rotate();
                        piece.Rotate();
                        piece.Rotate();
                        return;
                    }
                    break;
            }
            pic_Paint();

        }

        private bool piecePass()//检测主骨牌当前位置是否合法
        {

            foreach(Point item in piece.Positions)
            {
                int x = item.X;
                int y = item.Y;
                if (x > 11) return false;
                if (x < 0) return false;
                if (y > 15) return false;
                if (board[x, y] != null) return false;
            }
            return true;
        }





        private void pic_Paint()//在画布上画当前棋盘
        {
            if (piece == null) return;

            using (Graphics g = Graphics.FromImage(pic))//画主骨牌
            { 
            g.FillRectangle(Brushes.Black, new Rectangle(0, 0, 304, 404));//背景刷成黑色
            foreach (Point pos in piece.Positions)
            {

                int x = pos.X * 25;
                int y = pos.Y * 25;
                Point[] dark = new Point[6];
                dark[0] = new Point(x, y + 25);
                dark[1] = new Point(x + 5, y + 20);
                dark[2] = new Point(x + 20, y + 20);
                dark[3] = new Point(x + 20, y + 5);
                dark[4] = new Point(x + 25, y);
                dark[5] = new Point(x + 25, y + 25);
                g.FillRectangle(new SolidBrush(piece.color), new Rectangle(x, y, 25, 25));//画方块
                g.FillPolygon(Brushes.DarkSlateGray, dark);//画阴影

            }

            if (transparent && transTimes % 2 == 1)//选择透明模式后，奇数次落下后，界面会变成全黑
            {
                panel1.BackgroundImage = pic;
                panel1.Invalidate();
                return;
            }
            foreach (Box pos in board)//画棋盘上的骨牌山
            {
                if (pos == null) continue;


                int x = pos.x * 25;
                int y = pos.y * 25;
                Point[] dark = new Point[6];
                dark[0] = new Point(x, y + 25);
                dark[1] = new Point(x + 5, y + 20);
                dark[2] = new Point(x + 20, y + 20);
                dark[3] = new Point(x + 20, y + 5);
                dark[4] = new Point(x + 25, y);
                dark[5] = new Point(x + 25, y + 25);
                g.FillRectangle(new SolidBrush(pos.color), new Rectangle(x, y, 25, 25));
                g.FillPolygon(Brushes.DarkSlateGray, dark);
            }
        }
            panel1.BackgroundImage = pic;
            panel1.Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)//计时器，每次调用时发送up按键消息（事件）达成下降
        {
            GameForm_KeyDown(this, new KeyEventArgs(Keys.Up));
        }

        private void GameForm_FormClosed_1(object sender, FormClosedEventArgs e)//游戏界面关闭时自动切换回开始界面
        {
            father.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)//画右上角的预告骨牌
        {
            using (Graphics g = panel2.CreateGraphics())
            {
                foreach (Point pos in nextPiece.Positions)
                {
                    int x = (pos.X-3) * 20;
                    int y = (pos.Y+1) * 20;
                    Point[] dark = new Point[6];
                    dark[0] = new Point(x, y + 20);
                    dark[1] = new Point(x + 4, y + 16);
                    dark[2] = new Point(x + 16, y + 16);
                    dark[3] = new Point(x + 16, y + 5);
                    dark[4] = new Point(x + 20, y);
                    dark[5] = new Point(x + 20, y + 20);
                    g.FillRectangle(new SolidBrush(nextPiece.color), new Rectangle(x, y, 20, 20));
                    g.FillPolygon(Brushes.DarkSlateGray, dark);
                }
            }
        }
    }
}

