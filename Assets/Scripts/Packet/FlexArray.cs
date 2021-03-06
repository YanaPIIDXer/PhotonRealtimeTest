using System.Collections.Generic;
using Game.Stream;

namespace Game.Packet
{
    /// <summary>
    /// シリアライズ用動的配列
    /// </summary>
    /// <typeparam name="T">扱う型</typeparam>
    public class FlexArray<T> : List<T>, ISerializable
        where T : ISerializable, new()
    {
        /// <summary>
        /// シリアライズ
        /// </summary>
        /// <param name="Stream">ストリーム</param>
        /// <returns>成功したらtrueを返す</returns>
        public bool Serialize(IStream Stream)
        {
            int Len = Count;
            if (!Stream.Serialize(ref Len)) { return false; }

            if (Len > Count)
            {
                T[] InsertArray = new T[Len - Count];
                for (int i = 0; i < Len - Count; i++)
                {
                    InsertArray[i] = new T();
                }
                AddRange(InsertArray);
            }

            for (int i = 0; i < Len; i++)
            {
                this[i].Serialize(Stream);
            }

            return true;
        }
    }
}
