namespace breakout.Draw
{
    class Draw
    {
        breakout.Environment.Dictionary mDictionary = new breakout.Environment.Dictionary();
        static System.Collections.Generic.Stack<int> mDrawQueueID;
        static System.Collections.Generic.Stack<int> mDrawQueueX;
        static System.Collections.Generic.Stack<int> mDrawQueueY;

        static System.Collections.Generic.Stack<char> mDrawQueueTextID;
        static System.Collections.Generic.Stack<int> mDrawQueueTextX;
        static System.Collections.Generic.Stack<int> mDrawQueueTextY;
        static System.Collections.Generic.Stack<System.ConsoleColor> mDrawQueueTextColor;

       

        public int Init()
        {
            mDrawQueueID = new System.Collections.Generic.Stack<int>();
            mDrawQueueX = new System.Collections.Generic.Stack<int>();
            mDrawQueueY = new System.Collections.Generic.Stack<int>();

            mDrawQueueTextID = new System.Collections.Generic.Stack<char>();
            mDrawQueueTextX = new System.Collections.Generic.Stack<int>();
            mDrawQueueTextY = new System.Collections.Generic.Stack<int>();
            mDrawQueueTextColor = new System.Collections.Generic.Stack<System.ConsoleColor>();

            System.Console.CursorVisible = false;

            // Setting the interface background
            System.Console.BackgroundColor = System.ConsoleColor.White;
            for (int i = breakout.Environment.Coordinations.GameHeight; i < breakout.Environment.Coordinations.GameHeight + 3; i++ )
            {
                for(int z = 0; z < breakout.Environment.Coordinations.GameWidth; z++)
                {
                    System.Console.SetCursorPosition(z, i);
                    System.Console.Write(" Hej Jon! ");
                }
            }
            System.Console.BackgroundColor = System.ConsoleColor.Black;
            return 0;
        }

        public int Update()
        {
            while(mDrawQueueID.Count > 0)
            {
                System.Console.SetCursorPosition(mDrawQueueX.Pop(), mDrawQueueY.Pop());
                System.Console.ForegroundColor = mDictionary.GetColor(mDrawQueueID.Peek());
                System.Console.Write(mDictionary.GetChar(mDrawQueueID.Pop()));
                breakout.Environment.Dictionary.ColorReset();
            }

            System.Console.BackgroundColor = System.ConsoleColor.White;
            while(mDrawQueueTextID.Count > 0)
            {
                System.Console.SetCursorPosition(mDrawQueueTextX.Pop(), mDrawQueueTextY.Pop());
                System.Console.ForegroundColor = mDrawQueueTextColor.Pop();
                System.Console.Write(mDrawQueueTextID.Pop());
            }
            breakout.Environment.Dictionary.ColorReset();
            System.Console.SetCursorPosition(71, 21);
            return 0;
        }

        public void QueueDraw(int id, int x, int y)
        {
            mDrawQueueX.Push(x);
            mDrawQueueY.Push(y);
            mDrawQueueID.Push(id);
        }

        public void QueueDrawInterface(char interfaceChar, int x, int y, System.ConsoleColor color)
        {
            mDrawQueueTextID.Push(interfaceChar);
            mDrawQueueTextX.Push(x);
            mDrawQueueTextY.Push(y + breakout.Environment.Coordinations.GameHeight);
            mDrawQueueTextColor.Push(color);
        }

        public void WipeBoard(bool interfaceWipe = false)
        {
            if (interfaceWipe)
            {
                mDrawQueueTextID.Clear();
                mDrawQueueTextX.Clear();
                mDrawQueueTextY.Clear();
                mDrawQueueTextColor.Clear();
            }
            mDrawQueueX.Clear();
            mDrawQueueY.Clear();
            mDrawQueueID.Clear();
            for (int i = 0; i < breakout.Environment.Coordinations.GameHeight; i++)
            {
                for(int z = 0; z < breakout.Environment.Coordinations.GameWidth; z++)
                {
                    mDrawQueueID.Push(0);
                    mDrawQueueX.Push(z);
                    mDrawQueueY.Push(i);
                }
            }
            for(int i = 0; i < 3; i++)
            {
                for(int z = 0; z < breakout.Environment.Coordinations.GameWidth; z++)
                {
                    mDrawQueueTextID.Push(' ');
                    mDrawQueueTextX.Push(z);
                    mDrawQueueTextY.Push(breakout.Environment.Coordinations.GameHeight + i);
                    mDrawQueueTextColor.Push(System.ConsoleColor.Black);
                }
            }
        }
    }
}
