using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using Game.Network;
using Game.UI;
using Game.UI.Component;

namespace Game.Sequence
{
    /// <summary>
    /// タイトルシーケンス
    /// </summary>
    public class TitleSequence : MonoBehaviour
    {
        void Awake()
        {
            ConnectionEventListener.Instance.Connected
                .Subscribe((_) =>
                {
                    Debug.Log("ここで次のシーンへ");
                });

            UIManager.Instance.Show<TitleScreen>("TitleScreen");
        }
    }
}
