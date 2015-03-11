namespace breakout.Draw
{
    class Interface
    {
        breakout.Draw.Draw mDraw = new breakout.Draw.Draw();
        string mInterfaceHealthText;

        int mInterfaceScore;


        public int Init()
        {
            mInterfaceHealthText = "";
            mInterfaceScore = -1;
            return 1;
        }

        public int Update()
        {
            GUIDisplayHealth();
            GUIDisplayScore();
            return 1;
        }

        private void GUIDisplayHealth()
        {
            if(mInterfaceHealthText.Length != breakout.Entities.Player.Player.Health)
            {
                int tmpLength = mInterfaceHealthText.Length;
                mInterfaceHealthText = "";
                for (int i = 0; i < breakout.Entities.Player.Player.Health; i++)
                {
                    mInterfaceHealthText += "♥";
                }
                for (int i = 0; i < mInterfaceHealthText.Length*2; i++ )
                {
                    mDraw.QueueDrawInterface('♥', 1 + i, 0, System.ConsoleColor.Red);
                    mDraw.QueueDrawInterface(' ', 1 + i++, 0, System.ConsoleColor.Red);
                }
                for(int i = 0; i < tmpLength*2; i++)
                {
                    mDraw.QueueDrawInterface(' ', 1 + i, 0, System.ConsoleColor.Black);
                }
            }
        }

        private void GUIDisplayScore()
        {
            if(mInterfaceScore != breakout.Entities.Player.Player.Score)
            {
                if(mInterfaceScore < breakout.Entities.Player.Player.Score)
                {
                    mInterfaceScore++;
                }
                else
                {
                    mInterfaceScore--;
                }
                int scoreStartPos = breakout.Environment.Coordinations.GameWidth - mInterfaceScore.ToString().Length;
                for (int i = 0; i < mInterfaceScore.ToString().Length; i++ )
                {
                    mDraw.QueueDrawInterface(mInterfaceScore.ToString()[i], scoreStartPos + i, 0, System.ConsoleColor.Blue);
                }
            }
        }
    }
}
