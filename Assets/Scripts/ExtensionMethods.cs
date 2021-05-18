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
}
