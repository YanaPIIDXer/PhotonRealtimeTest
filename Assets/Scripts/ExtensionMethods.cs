using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Stream;

/// <summary>
/// 拡張メソッド
/// </summary>
public static class ExtensionMethods
{
    /// <summary>
    /// シリアライズ
    /// </summary>
    /// <param name="Stream">ストリーム</param>
    public static void Serialize(this Vector3 Self, IStream Stream)
    {
        Stream.Serialize(ref Self.x);
        Stream.Serialize(ref Self.y);
        Stream.Serialize(ref Self.z);
    }

    /// <summary>
    /// Vector3をシリアライズして返す
    /// HACK:上記の拡張メソッドでシリアライズしても正しい値が入らない（拡張メソッド内でログを吐き出しても正しい値は入っている）という問題がある。
    ///      なので止む無くこういった対応を行う事にした
    /// </summary>
    /// <param name="Stream">ストリーム</param>
    /// <returns>Vector3</returns>
    public static Vector3 SerializeVector3(IStream Stream)
    {
        Vector3 Vec = new Vector3();
        float Value = Vec.x;
        Stream.Serialize(ref Value);
        Vec.x = Value;

        Value = Vec.y;
        Stream.Serialize(ref Value);
        Vec.y = Value;

        Value = Vec.z;
        Stream.Serialize(ref Value);
        Vec.z = Value;

        return Vec;
    }
}
