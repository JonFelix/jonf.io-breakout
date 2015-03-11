namespace breakout.GameSystem
{
    class Game
    {
        breakout.Entities.Player.Player player = new breakout.Entities.Player.Player();
        breakout.Environment.Coordinations coords = new breakout.Environment.Coordinations();
        breakout.Entities.Player.Input input = new breakout.Entities.Player.Input();
        breakout.Draw.Draw draw = new breakout.Draw.Draw();
        breakout.Entities.Ball ball = new breakout.Entities.Ball();
        breakout.GameSystem.Time time = new breakout.GameSystem.Time();
        breakout.Draw.Interface userInterface = new breakout.Draw.Interface();

        public int Init()
        {
            int e = 0;
            e += draw.Init();
            e += userInterface.Init();
            e += input.Init();
            e += coords.Init();
            e += player.Init();
            e += ball.Init();
            e += time.Init();

            return e;
        }
        
        public void Update(int initCheck)
        {
            int e = 0;
            if (initCheck <= 1)
            {
                
                while (e <= 1)
                {
                    e = 0;
                    e += draw.Update();
                    e += userInterface.Update();
                    e += input.Update();
                    e += player.Update();
                    e += ball.Update();
                    e += time.Update();
                }
            }
            System.Console.Clear();
            System.Console.WriteLine(initCheck.ToString() + '\n' + e.ToString());
            System.Console.ReadLine();
        }
    }
}
