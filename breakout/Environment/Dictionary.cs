namespace breakout.Environment
{
    class Dictionary
    {
        char[] ENTITY_CHAR = {' ', '-', '¤', '@', '|', ' ', '-', '*', '=', '=', '=', 'o'};
        System.ConsoleColor[] charColor = {   System.ConsoleColor.Black, 
                                              System.ConsoleColor.Green, 
                                              System.ConsoleColor.Green, 
                                              System.ConsoleColor.Green, 
                                              System.ConsoleColor.DarkGray, 
                                              System.ConsoleColor.Black, 
                                              System.ConsoleColor.DarkGray,
                                              System.ConsoleColor.DarkGray,
                                              System.ConsoleColor.Red,
                                              System.ConsoleColor.Yellow,
                                              System.ConsoleColor.Blue,
                                              System.ConsoleColor.White     };
        int[] DESTRUCTIBLE = { 8, 9, 10 };

        public char GetChar(int ID)
        {
            return ENTITY_CHAR[ID];
        }
        public System.ConsoleColor GetColor(int ID)
        {
            return charColor[ID];
        }

        static public void ColorReset()
        {
            System.Console.ForegroundColor = System.ConsoleColor.White;
            System.Console.BackgroundColor = System.ConsoleColor.Black;
        }
        public bool isDestructible(int ID)
        {
            bool mResult = false;
            foreach(int item in DESTRUCTIBLE)
            {
                if (ID == item)
                {
                    mResult = true;
                }
            }
            return mResult;
        }
    }
}
