using System.Collections.Generic;
using Game.Stream;

namespace Game.Packet
{
    public class Vec3  : ISerializable
	{
		

		/// <summary>
		///  X
		/// </summary>
		public float X = new float();

		/// <summary>
		///  Y
		/// </summary>
		public float Y = new float();

		/// <summary>
		///  Z
		/// </summary>
		public float Z = new float();

		

		

		public Vec3()
		{
		}

		public Vec3(float X, float Y, float Z)
		{
			this.X = X;
			this.Y = Y;
			this.Z = Z;
			
		}

		public bool Serialize(IStream Stream)
		{
			Stream.Serialize(ref X);
			Stream.Serialize(ref Y);
			Stream.Serialize(ref Z);
			
			return true;
		}
	}
}
