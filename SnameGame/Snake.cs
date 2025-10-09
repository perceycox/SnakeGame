using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnameGame
{
    public class Snake
    {
        private Rectangle[] snakeRec;
        private SolidBrush brush;
        private int x, y, width, height;

        public Rectangle[] SnakeRec
        {
            get { return snakeRec; }
        }

        public Snake()
        {
            snakeRec = new Rectangle[3];
            brush = new SolidBrush(Color.Blue);

            //starting coordinates
            x = 20;
            y = 0;

            //the size of a segment
            width = 10;
            height = 10;

            for (int index = 0; index < snakeRec.Length; index++)
            {

                //creates one body part
                snakeRec[index] = new Rectangle(x, y, width, height);

                //moves to the next segment
                x -= width;
            }

        }

        //fill each segment with colour
        public void drawSnake(Graphics paper)
        {
            foreach(Rectangle rec in snakeRec)
            {
                paper.FillRectangle(brush, rec);
            }
        }

        public void drawSnake()
        {
            for(int index = snakeRec.Length - 1; index > 0; index--)
            {
                snakeRec[index] = snakeRec[index - 1];

            }
        }

        public void moveDown()
        {
            drawSnake();
            snakeRec[0].Y += 10;
        }

        public void moveUp()
        {
            drawSnake();
            snakeRec[0].Y -= 10;
        }

        public void moveRight()
        {
            drawSnake();
            snakeRec[0].X += 10;
        }

        public void moveLeft()
        {
            drawSnake();
            snakeRec[0].X -= 10;
        }

        public void growSnake()
        {
            List<Rectangle> rec = snakeRec.ToList();
            rec.Add(new Rectangle(snakeRec[snakeRec.Length - 1].X, snakeRec[snakeRec.Length - 1].Y, width, height));
            snakeRec = rec.ToArray();
        }

    }
}
