using System.Collections.Generic;
using Game.Stream;

namespace Game.Packet
{
    public class PacketPlayerMove  : IPacket
	{
		

		/// <summary>
		///  座標
		/// </summary>
		public Vec3 Position = new Vec3();

		

		public EPacketID PacketID { get { return EPacketID.PlayerMove; } }

		public PacketPlayerMove()
		{
		}

		public PacketPlayerMove(Vec3 Position)
		{
			this.Position = Position;
			
		}

		public bool Serialize(IStream Stream)
		{
			Position.Serialize(Stream);
			
			return true;
		}
	}
}
