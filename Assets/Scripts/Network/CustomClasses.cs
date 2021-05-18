using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Stream;

namespace Game.Network
{
    /// <summary>
    /// カスタムクラスのシリアライズ・デシリアライズ
    /// </summary>
    public static class CustomClasses
    {
        /// <summary>
        /// Vector3のシリアライズ
        /// </summary>
        /// <param name="Obj">Vector3</param>
        /// <returns>バイトデータ</returns>
        public static byte[] SerializeVector3(object Obj)
        {
            Vector3 Src = (Vector3)Obj;
            MemoryStreamWriter Writer = new MemoryStreamWriter();
            Writer.Serialize(ref Src.x);
            Writer.Serialize(ref Src.y);
            Writer.Serialize(ref Src.z);
            return Writer.Buffer.ToArray();
        }

        /// <summary>
        /// Vector3のデシリアライズ
        /// </summary>
        /// <param name="data">バイトデータ</param>
        /// <returns>Vector3</returns>
        public static object DeserializeVector3(byte[] Data)
        {
            MemoryStreamReader Reader = new MemoryStreamReader(Data);
            Vector3 Dest = Vector3.zero;
            Reader.Serialize(ref Dest.x);
            Reader.Serialize(ref Dest.y);
            Reader.Serialize(ref Dest.z);
            return Dest;
        }
    }
}
