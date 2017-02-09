using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Media;

namespace Tetris
{
    abstract class Piece
    {
        public Point Position=new Point(5,0);
        public Point[] Positions;
        public Color  color;
        protected int status;



        public abstract void Rotate();
        public  void Left()
        {
            --Positions[0].X;
            --Positions[1].X;
            --Positions[2].X;
            --Positions[3].X;
        }
        public  void Right()
        {
            ++Positions[0].X;
            ++Positions[1].X;
            ++Positions[2].X;
            ++Positions[3].X;
        }
        public  void Down()
        {
            ++Positions[0].Y;
            ++Positions[1].Y;
            ++Positions[2].Y;
            ++Positions[3].Y;
        }
        public void Up()
        {
            --Positions[0].Y;
            --Positions[1].Y;
            --Positions[2].Y;
            --Positions[3].Y;
        }
    }

    class Box
    {
        public Color color;
        public int x;
        public int y;
        public Box(Color color,int x,int y)
        {
            this.color = color;
            this.x = x;
            this.y = y;
        }

    }
    class Piece_I : Piece
    {
        public Piece_I()
        {
            Positions = new Point[4];
            
            Positions[0] = new Point(5, 0);
            Positions[1] = new Point(5, 1);
            Positions[2] = new Point(5, 2);
            Positions[3] = new Point(5, 3);

            color = Color.FromKnownColor(KnownColor.Cyan);
            status = 0;

        }
        public override void Rotate()
        {
            if(status==0)
            {
                Positions[0].X = Positions[1].X - 1;
                Positions[2].X = Positions[1].X + 1;
                Positions[3].X = Positions[1].X + 2;
                Positions[0].Y = Positions[2].Y = Positions[3].Y = Positions[1].Y;
                status = 1;
            }
            else
            {
                Positions[0].Y = Positions[1].Y - 1;
                Positions[2].Y = Positions[1].Y + 1;
                Positions[3].Y = Positions[1].Y + 2;
                Positions[0].X = Positions[2].X = Positions[3].X = Positions[1].X;
                status = 0;
            }
        }
    }
    class Piece_O : Piece
    {
        public Piece_O()
        {
            Positions = new Point[4];

            Positions[0] = new Point(5, 0);
            Positions[1] = new Point(5, 1);
            Positions[2] = new Point(6, 0);
            Positions[3] = new Point(6, 1);

            color = Color.FromKnownColor(KnownColor.Highlight);
            status = 0;

        }
        public override void Rotate() { }
    }
    class Piece_L: Piece
    {
        public Piece_L()
        {
            Positions = new Point[4];

            Positions[0] = new Point(7, 0);
            Positions[1] = new Point(7, 1);
            Positions[2] = new Point(6, 1);
            Positions[3] = new Point(5, 1);

            color = Color.FromKnownColor(KnownColor.LimeGreen);
            status = 0;

        }
        public override void Rotate()
        {
            switch (status)
            {
                case 0:
                    Positions[1].X = Positions[2].X;
                    Positions[1].Y = Positions[2].Y + 1;

                    Positions[0].X = Positions[1].X + 1;
                    Positions[0].Y = Positions[1].Y;

                    Positions[3].X = Positions[2].X;
                    Positions[3].Y = Positions[2].Y - 1;

                    status = 1;
                    break;
                case 1:
                    Positions[1].X = Positions[2].X-1;
                    Positions[1].Y = Positions[2].Y;

                    Positions[0].X = Positions[1].X;
                    Positions[0].Y = Positions[1].Y + 1;

                    Positions[3].X = Positions[2].X+1;
                    Positions[3].Y = Positions[2].Y ;

                    status = 2;
                    break;
                case 2:
                    Positions[1].X = Positions[2].X;
                    Positions[1].Y = Positions[2].Y - 1;

                    Positions[0].X = Positions[1].X - 1;
                    Positions[0].Y = Positions[1].Y;

                    Positions[3].X = Positions[2].X;
                    Positions[3].Y = Positions[2].Y + 1;

                    status = 3;
                    break;
                case 3:
                    Positions[1].X = Positions[2].X+1;
                    Positions[1].Y = Positions[2].Y;

                    Positions[0].X = Positions[1].X;
                    Positions[0].Y = Positions[1].Y-1;

                    Positions[3].X = Positions[2].X-1;
                    Positions[3].Y = Positions[2].Y;

                    status = 0;
                    break;
            }
        }
    }
    class Piece_J: Piece
    {
        public Piece_J()
        {
            Positions = new Point[4];

            Positions[0] = new Point(5, 0);
            Positions[1] = new Point(5, 1);
            Positions[2] = new Point(6, 1);
            Positions[3] = new Point(7, 1);

            color = Color.FromKnownColor(KnownColor.DarkOrange);
            status = 0;

        }
        public override void Rotate()
        {
            switch (status)
            {
                case 0:
                    Positions[1].X = Positions[2].X;
                    Positions[1].Y =Positions[2].Y-1;

                    Positions[0].X = Positions[1].X + 1;
                    Positions[0].Y = Positions[1].Y;

                    Positions[3].X = Positions[2].X;
                    Positions[3].Y = Positions[2].Y + 1;
                    status = 1;
                    break;
                case 1:
                    Positions[1].X = Positions[2].X+1;
                    Positions[1].Y = Positions[2].Y ;

                    Positions[0].X = Positions[1].X;
                    Positions[0].Y = Positions[1].Y+1;

                    Positions[3].X = Positions[2].X-1;
                    Positions[3].Y = Positions[2].Y ;
                    status = 2;
                    break;
                case 2:
                    Positions[1].X = Positions[2].X;
                    Positions[1].Y = Positions[2].Y + 1;

                    Positions[0].X = Positions[1].X - 1;
                    Positions[0].Y = Positions[1].Y;

                    Positions[3].X = Positions[2].X;
                    Positions[3].Y = Positions[2].Y - 1;
                    status = 3;
                    break;
                case 3:
                    Positions[1].X = Positions[2].X-1;
                    Positions[1].Y = Positions[2].Y ;

                    Positions[0].X = Positions[1].X;
                    Positions[0].Y = Positions[1].Y-1;

                    Positions[3].X = Positions[2].X+1;
                    Positions[3].Y = Positions[2].Y;
                    status = 0;
                    break;
            }
        }
    }
    class Piece_S : Piece
    {
        public Piece_S()
        {
            Positions = new Point[4];

            Positions[0] = new Point(5, 0);
            Positions[1] = new Point(5, 1);
            Positions[2] = new Point(6, 1);
            Positions[3] = new Point(6, 2);

            color = Color.FromKnownColor(KnownColor.White);
            status = 0;

        }
        public override void Rotate()
        {
            if (status == 0)
            {
                Positions[0].X -= 1;
                Positions[0].Y += 2;

                Positions[1].X = Positions[0].X + 1;
                Positions[1].Y = Positions[0].Y ;

                Positions[2].X = Positions[1].X;
                Positions[2].Y = Positions[1].Y - 1;

                Positions[3].X = Positions[2].X +1;
                Positions[3].Y = Positions[2].Y;
                status = 1;
            }
            else
            {
                Positions[0].X += 1;
                Positions[0].Y -= 2;

                Positions[1].X = Positions[0].X ;
                Positions[1].Y = Positions[0].Y+1;

                Positions[2].X = Positions[1].X+1;
                Positions[2].Y = Positions[1].Y;

                Positions[3].X = Positions[2].X;
                Positions[3].Y = Positions[2].Y+1;
                status = 0;
            }
        }
    }
    class Piece_Z : Piece
    {
        public Piece_Z()
        {
            Positions = new Point[4];

            Positions[0] = new Point(6, 0);
            Positions[1] = new Point(6, 1);
            Positions[2] = new Point(5, 1);
            Positions[3] = new Point(5, 2);

            color = Color.FromKnownColor(KnownColor.HotPink);
            status = 0;

        }
        public override void Rotate()
        {
            if (status == 0)
            {
                Positions[0].Y += 1;

                Positions[1].X = Positions[0].X - 1;
                Positions[1].Y = Positions[0].Y;

                Positions[2].X = Positions[1].X;
                Positions[2].Y = Positions[1].Y - 1;

                Positions[3].X = Positions[2].X - 1;
                Positions[3].Y = Positions[2].Y;
                status = 1;
            }
            else
            {
                Positions[0].Y-=1;

                Positions[1].X = Positions[0].X;
                Positions[1].Y = Positions[0].Y + 1;

                Positions[2].X = Positions[1].X - 1;
                Positions[2].Y = Positions[1].Y;

                Positions[3].X = Positions[2].X;
                Positions[3].Y = Positions[2].Y + 1;
                status = 0;
            }
        }
    }
    class Piece_T : Piece
    {
        public Piece_T()
        {
            Positions = new Point[4];

            Positions[0] = new Point(5, 1);
            Positions[1] = new Point(4, 1);
            Positions[2] = new Point(5, 0);
            Positions[3] = new Point(6, 1);

            color = Color.FromKnownColor(KnownColor.Yellow);
            status = 0;

        }
        public override void Rotate()
        {
            switch (status)
            {
                case 0:
                    Positions[1] = Positions[2];
                    Positions[2] = Positions[3];
                    Positions[3] = new Point(Positions[0].X, Positions[0].Y + 1);
                    status = 1;
                    break;
                case 1:
                    Positions[1] = Positions[2];
                    Positions[2] = Positions[3];
                    Positions[3] = new Point(Positions[0].X-1, Positions[0].Y);
                    status = 2;
                    break;
                case 2:
                    Positions[1] = Positions[2];
                    Positions[2] = Positions[3];
                    Positions[3] = new Point(Positions[0].X, Positions[0].Y-1);
                    status = 3;
                    break;
                case 3:
                    Positions[1] = Positions[2];
                    Positions[2] = Positions[3];
                    Positions[3] = new Point(Positions[0].X+1, Positions[0].Y);
                    status = 0;
                    break;
            }
        }
    }
    class Piece_NULL : Piece
    {
        public Piece_NULL()
        {
            Positions = null;
        }
        public override void Rotate()
        {
            return;
        }
    }

}
