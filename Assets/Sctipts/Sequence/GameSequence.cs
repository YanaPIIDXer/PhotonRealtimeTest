using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using ExitGames.Client.Photon;
using Game.Network;
using UniRx;
using System;
using UniRx.Operators;
using UniRx.Triggers;

namespace Game.Sequence
{
    /// <summary>
    /// ゲームシーケンス
    /// </summary>
    public class GameSequence : MonoBehaviour, IOnEventCallback
    {
        void Awake()
        {
            ConnectionCore.Instance.AddCallbackTarget(this);
        }

        void OnDestroy()
        {
            ConnectionCore.Instance.RemoveCallbackTarget(this);
        }

        public void OnEvent(EventData photonEvent)
        {
        }
    }
}
