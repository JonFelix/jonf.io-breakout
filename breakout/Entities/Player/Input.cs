namespace breakout.Entities.Player
{
    class Input
    {
        static bool mPlayerLeft;
        static bool mPlayerRight;
        static System.IO.Stream mInputStream;
        System.Threading.Thread inputThread;
        breakout.GameSystem.Time time = new breakout.GameSystem.Time();
       
        public bool PlayerLeft
        {
            get 
            { 
                return mPlayerLeft; 
            }
        }

        public bool PlayerRight
        {
            get 
            { 
                return mPlayerRight; 
            }
        }
      
        public int Init()
        {
            mInputStream = System.Console.OpenStandardInput();
            mPlayerLeft = false;
            mPlayerRight = false;              
            inputThread = new System.Threading.Thread(new System.Threading.ThreadStart(InputControl));
            inputThread.Start();
            return 0;
        }

        public int Update()
        {
            if (inputThread.ThreadState.Equals(System.Threading.ThreadState.Running) || inputThread.ThreadState.Equals(System.Threading.ThreadState.WaitSleepJoin))
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        private void InputControl()
        {
            while (true)
            {

                do
                {
                    mPlayerLeft = false;
                    mPlayerRight = false;
                    System.ConsoleKeyInfo playerInputKey = System.Console.ReadKey(true);
                    if (playerInputKey.Key == System.ConsoleKey.LeftArrow)
                    {
                        mPlayerLeft = true;
                    }
                    if (playerInputKey.Key == System.ConsoleKey.RightArrow)
                    {
                        mPlayerRight = true;
                    }
                }
                while (System.Console.KeyAvailable);

                time.Update();
            }
        }
    }
}

