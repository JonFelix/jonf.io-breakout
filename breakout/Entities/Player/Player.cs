namespace breakout.Entities.Player
{
    class Player
    {


        breakout.Entities.Player.Input input = new breakout.Entities.Player.Input();
        breakout.Environment.Coordinations coords = new breakout.Environment.Coordinations();

        static int mHealth;
        static int mScore;

        static public int Health
        {
            get
            {
                return mHealth;
            }
            set
            {
                mHealth += value;
            }

        }

        static public int Score
        {
            get
            {
                return mScore;
            }
            set
            {
                mScore += value;
            }
        }
        
        public int Init()
        {
            mHealth = 5;
            mScore = 0;
            return 0;
        }

        public int Update()
        {
                MovePlayer();
                return 0;
        }

        private void MovePlayer()
        {
            int x = 0;
            if (input.PlayerLeft)
            {
                x--;
            }
            if (input.PlayerRight)
            {
                x++;
            }
            coords.MovePlayer(x, 0);
        }
    }
}
