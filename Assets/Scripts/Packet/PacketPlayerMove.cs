using System.Collections.Generic;
using Game.Stream;

namespace Game.Packet
{
    public class PacketPlayerMove  : IPacket
	{
		

		

		public EPacketID PacketID { get { return EPacketID.PlayerMove; } }

		public PacketPlayerMove()
		{
		}

		

		public bool Serialize(IStream Stream)
		{
			
			return true;
		}
	}
}
