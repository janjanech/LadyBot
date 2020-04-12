namespace LadyBot.Implementation
{
	internal abstract class LadyBotAnimation
	{
		public class Rotation : LadyBotAnimation
		{
			public Rotation(int oldRotation, int newRotation)
			{
				if (oldRotation > 180 && newRotation == 0)
					newRotation = 360;
				if (newRotation > 180 && oldRotation == 0)
					newRotation -= 360;

				this.OldRotation = oldRotation;
				this.NewRotation = newRotation;
			}

			public int OldRotation { get; }

			public int NewRotation { get; }
		}


		public class Translation : LadyBotAnimation
		{
			public Translation(int newX, int newY)
			{
				this.NewX = newX;
				this.NewY = newY;
			}

			public int NewX { get; }
			public int NewY { get; }
		}
	}
}
