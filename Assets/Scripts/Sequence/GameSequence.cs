using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Network;
using UniRx;
using System;
using Photon.Realtime;
using ExitGames.Client.Photon;
using Game.UI;
using Game.UI.Component;

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
            Game.Network.ServerConnection.Instance.RegisterCallbackTarget(this);

            var Handler = UIManager.Instance.Show<GameHUD>("GameHUD");
            Handler.Instance.Inputs.Move.Subscribe((Value) => Debug.Log(Value.ToString()));
        }

        void OnDestroy()
        {
            Game.Network.ServerConnection.Instance.UnregisterCallbackTarget(this);
        }
    }
}
