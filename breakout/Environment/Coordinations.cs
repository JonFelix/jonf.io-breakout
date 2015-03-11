namespace breakout.Environment
{
    class Coordinations
    {
        breakout.Draw.Draw draw = new breakout.Draw.Draw();

        static int[,] mCoords;
        static int mPlayerX;
        static int mPlayerY;
        const int MAX_Y = 22;
        const int MAX_X = 80;

        static public int GameWidth
        {
            get
            {
                return MAX_X;
            }
        }

        static public int GameHeight
        {
            get
            {
                return MAX_Y;
            }
        }

        public int Init()
        { 
            mCoords = new int[MAX_X, MAX_Y];
            for (int i = 0; i < mCoords.GetLength(0); i++ )
            {
                for (int z = 0; z < mCoords.GetLength(1); z++)
                {
                    mCoords[i, z] = 0;
                }
            }
            mPlayerX = 40;
            mPlayerY = 20;
            CreateMap();           
            return 0; 
        }

        public void MovePlayer(int x, int y)
        {
            if ((mPlayerX + x > 0 && mPlayerX + x < MAX_X) && (mPlayerY > 0 && mPlayerY < MAX_Y))
            {
                if (!Collision(mPlayerX + x, mPlayerY + y))
                {
                    mCoords[mPlayerX, mPlayerY] = 0;
                    draw.QueueDraw(0, mPlayerX, mPlayerY);
                    mPlayerX += x;
                    mPlayerY += y;
                    mCoords[mPlayerX, mPlayerY] = 1;
                    draw.QueueDraw(1, mPlayerX, mPlayerY);
                }
            }
        }

        public void MoveEntity(int id, int oldX, int oldY, int newX, int newY)
        {
            mCoords[oldX, oldY] = 0;
            draw.QueueDraw(0, oldX, oldY);
            mCoords[newX, newY] = id;
            draw.QueueDraw(id, newX, newY);
        }

        public bool Collision(int x, int y)
        {
            if(mCoords[x, y] != 0)
            {
                return true;
            }
            return false;
        }

        public int GetSpace(int x, int y)
        {
            return mCoords[x, y];
        }

        public void SpawnEntity(int id, int x, int y)
        {
            mCoords[x, y] = id;
            draw.QueueDraw(id, x, y);
        }

        public void DeleteEntity(int x, int y)
        {
            mCoords[x, y] = 0;
            draw.QueueDraw(0, x, y);   
        }

        public void CreateMap()
        {
            //Creating the walls
            SpawnEntity(7, 0, 0);
            SpawnEntity(7, MAX_X-1, 0);
            for (int i = 1; i < MAX_X-1; i++ )
            {
                SpawnEntity(6, i, 0);
                SpawnEntity(5, i, MAX_Y-1);
            }
            for (int i = 0; i < MAX_Y; i++)
            {
                SpawnEntity(4, 0, i);
                SpawnEntity(4, MAX_X - 1, i);
            }
            //Spawn enemies
            int EnemyPos = 4;
            while(EnemyPos < 75)
            {
                for(int i = 0; i < 5; i++)
                {
                    SpawnEntity(8, EnemyPos, 3);
                    SpawnEntity(9, EnemyPos, 6);
                    SpawnEntity(10, EnemyPos++, 9);
                }
                EnemyPos++;
            }  
            //Spawn the ball
            SpawnEntity(11, 40, 11);
            //Spawns the player
            SpawnEntity(1, mPlayerX, mPlayerY);
            //SpawnEntity(2, mPlayerX, mPlayerY);
        }
    }
}
