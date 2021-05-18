using Game.Stream;

namespace Game.Packet
{
    /// <summary>
    /// パケットインタフェース
    /// </summary>
    public interface IPacket
    {
        /// <summary>
        /// パケットＩＤ
        /// </summary>
        EPacketID PacketID { get; }

        /// <summary>
        /// シリアライズ
        /// </summary>
        /// <param name="Stream">ストリーム</param>
        /// <returns>成功したらtrue</returns>
        bool Serialize(IStream Stream);
    }
}
