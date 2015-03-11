namespace breakout.GameSystem
{
    class Time
    {
        static int TimeDelay;

        public int Init()
        {
            TimeDelay = 50;
            return 0;
        }
        public int Update()
        {
            System.Threading.Thread.Sleep(TimeDelay);
            return 0;
        }
    }
}
