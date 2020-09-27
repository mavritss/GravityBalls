using System;

namespace GravityBalls
{
	public class WorldModel
	{
		public double BallX;
		public double BallY;
		public double BallRadius;
		public double WorldWidth;
		public double WorldHeight;
		public double Vy0 = 50;
		public double Vx0 = 25;

		const double Gravity = 9.8;
		const double K = 0.01; //сопротивление воздуха, как пример
		const double Weight = 0.84;

		public void SimulateTimeframe(double dt)
		{
			Vy0 = Vy0 + Weight * Gravity - K * Vy0;

			BallY = SpeedBall(BallY, Vy0, dt, WorldHeight);
			if (BallY == 10) Vy0 = -Vy0;
			if (BallY == WorldHeight - 10) Vy0 = -Vy0;

			BallX = SpeedBall(BallX, Vx0, dt, WorldWidth);
			if (BallX == 10) Vx0 = -Vx0;
			if (BallX == WorldWidth - 10) Vx0 = -Vx0;

		}

		public double SpeedBall (double ballDirection, double speed,  double dt, double size)
		{
			return Math.Max(Math.Min(ballDirection + speed * dt, size - BallRadius), 0 + BallRadius);
		}

	}
}
