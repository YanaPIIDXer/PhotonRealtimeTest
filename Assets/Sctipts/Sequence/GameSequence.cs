using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Network;
using UniRx;
using System;
using Photon.Realtime;
using ExitGames.Client.Photon;

namespace Game.Sequence
{
    /// <summary>
    /// ゲームシーケンス
    /// </summary>
    public class GameSequence : MonoBehaviour, IOnEventCallback
    {
        public void OnEvent(EventData photonEvent)
        {
        }

        void Awake()
        {
            ServerConnection.Instance.RegisterCallbackTarget(this);
        }

        void OnDestroy()
        {
            ServerConnection.Instance.UnregisterCallbackTarget(this);
        }
    }
}
