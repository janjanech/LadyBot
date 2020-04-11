using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace LadyBot.Implementation
{
	internal abstract class LadyBotAnimation
	{
		public class Rotation : LadyBotAnimation
		{
			public Rotation(int oldRotation, int newRotation)
			{
				if ((newRotation - oldRotation + 360) % 360 > 180)
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
