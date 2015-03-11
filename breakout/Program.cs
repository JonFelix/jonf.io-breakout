namespace breakout
{
    class Program
    {
        static void Main(string[] args)
        
        {
            breakout.GameSystem.Game game = new breakout.GameSystem.Game();
            game.Update(game.Init());
        }
    }
}
