namespace SnameGame
{
    public partial class Form1 : Form
    {
        Random randFood = new Random();
        Graphics paper;
        Snake snake = new Snake();
        Food food;

        bool left = false;
        bool right = false;
        bool down = false;
        bool up = false;

        int score = 0;

        public Form1()
        {
            InitializeComponent();
            food = new Food(randFood);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            paper = e.Graphics;
            snake.drawSnake(paper);
            food.drawFood(paper);

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Space)
            {
                timer1.Enabled = true;
                spaceBarLabel.Text = "";
                down = false;
                up = false;
                right = true;
                left = false;

            }

            if (e.KeyData == Keys.Down && up == false)
            {
                down = true;
                up = false;
                right = false;
                left = false;
            }

            if (e.KeyData == Keys.Up && down == false)
            {
                down = false;
                up = true;
                right = false;
                left = false;
            }

            if (e.KeyData == Keys.Right && left == false)
            {
                down = false;
                up = false;
                right = true;
                left = false;
            }

            if (e.KeyData == Keys.Left && right == false)
            {
                down = false;
                up = false;
                right = false;
                left = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            snakeScoreLabel.Text = Convert.ToString(score);

            if (down)
            {
                snake.moveDown();
            }

            if (up)
            {
                snake.moveUp();
            }

            if (right)
            {
                snake.moveRight();
            }

            if (left)
            {
                snake.moveLeft();
            }

            for (int index = 0; index < snake.SnakeRec.Length; index++)
            {
                if (snake.SnakeRec[index].IntersectsWith(food.foodRec))
                {
                    score += 10;
                    snake.growSnake();
                    food.foodLocation(randFood);
                }
            }

            collision();

            this.Invalidate();
        }

        public void collision()
        {
            for(int index = 1; index < snake.SnakeRec.Length; index++)
            {
                if (snake.SnakeRec[0].IntersectsWith(snake.SnakeRec[index]))
                {
                    restart();
                }
            }

            if (snake.SnakeRec[0].X < 0 || snake.SnakeRec[0].X > 290)
            {
                restart();
            }

            if (snake.SnakeRec[0].Y < 0 || snake.SnakeRec[0].Y > 290)
            {
                restart();
            }
        }

        public void restart()
        {
            timer1.Enabled = false;
            MessageBox.Show("Game Over");
            MessageBox.Show("Your score was " + score);

            snakeScoreLabel.Text = "0";
            score = 0;
            spaceBarLabel.Text = "Press Space to Begin";

            snake = new Snake();
        }
    }
}
