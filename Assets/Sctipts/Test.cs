using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using Game.Network;
using UnityEngine.UI;

/// <summary>
/// テスト用
/// 後で消す
/// </summary>
public class Test : MonoBehaviour
{
    void Awake()
    {
        GetComponent<Button>().OnClickAsObservable()
            .Subscribe((_) => ServerConnection.Instance.Connect());
    }
}
