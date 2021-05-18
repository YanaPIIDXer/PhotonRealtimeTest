using System.Collections.Generic;
using Game.Stream;

namespace Game.Packet
{
    public class PacketPlayerEnter  : IPacket
	{
		

		/// <summary>
		///  ID
		/// </summary>
		public int Id = new int();

		/// <summary>
		///  座標
		/// </summary>
		public Vec3 Position = new Vec3();

		

		public EPacketID PacketID { get { return EPacketID.PlayerEnter; } }

		public PacketPlayerEnter()
		{
		}

		public PacketPlayerEnter(int Id, Vec3 Position)
		{
			this.Id = Id;
			this.Position = Position;
			
		}

		public bool Serialize(IStream Stream)
		{
			Stream.Serialize(ref Id);
			Position.Serialize(Stream);
			
			return true;
		}
	}
}
