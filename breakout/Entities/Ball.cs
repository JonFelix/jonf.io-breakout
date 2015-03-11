namespace breakout.Entities
{
    class Ball
    {
        int mBallPositionX;
        int mBallPositionY;
        int mVerticalSpeed;
        int mHorizontalSpeed;
        breakout.Environment.Coordinations coords = new breakout.Environment.Coordinations();
        breakout.Environment.Dictionary dict = new breakout.Environment.Dictionary();

        public int Init()
        {
            System.Random rand = new System.Random();
            mBallPositionX = 40;
            mBallPositionY = 11;
            mVerticalSpeed = 1;
            mHorizontalSpeed = rand.Next(-1, 2);
           
            return 0;
        }

        public int Update()
        {
            if(!coords.Collision(mBallPositionX + mHorizontalSpeed, mBallPositionY + mVerticalSpeed))
            {
                coords.MoveEntity(11, mBallPositionX, mBallPositionY, mBallPositionX + mHorizontalSpeed, mBallPositionY + mVerticalSpeed);
                mBallPositionX += mHorizontalSpeed;
                mBallPositionY += mVerticalSpeed;
            }
            else
            {
                int collisionPositionX = mBallPositionX + mHorizontalSpeed;
                int collisionPositionY = mBallPositionY + mVerticalSpeed;
                
                if ((!coords.Collision(mBallPositionX + 1, mBallPositionY) || !coords.Collision(mBallPositionX - 1, mBallPositionY)) && (coords.Collision(mBallPositionX, mBallPositionY + 1) || coords.Collision(mBallPositionX, mBallPositionY - 1)))
                {
                    mVerticalSpeed *= -1;
                }
                if ((!coords.Collision(mBallPositionX, mBallPositionY + 1) || !coords.Collision(mBallPositionX, mBallPositionY - 1)) && (coords.Collision(mBallPositionX + 1, mBallPositionY) || coords.Collision(mBallPositionX - 1, mBallPositionY)))
                {
                    mHorizontalSpeed *= -1;
                }
                if (dict.isDestructible(coords.GetSpace(collisionPositionX, collisionPositionY)))
                {
                    coords.DeleteEntity(collisionPositionX, collisionPositionY);
                    breakout.Entities.Player.Player.Score = 10;
                }
                //else if(coords.GetSpace(collisionPositionX, collisionPositionY) == )
            }
            return 0;
        }
    }
}
