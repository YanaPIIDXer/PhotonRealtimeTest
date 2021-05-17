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
            this.UpdateAsObservable()
                .ThrottleFirst(TimeSpan.FromSeconds(3.0f))
                .Subscribe((_) =>
                {
                    Dictionary<byte, object> Params = new Dictionary<byte, object>();
                    Params[0] = 10;
                    Params[1] = 20;
                    Params[2] = 30;
                    ConnectionCore.Instance.SendEvent(1, Params);
                    Debug.Log("Send Event");
                });
        }

        void OnDestroy()
        {
            ConnectionCore.Instance.RemoveCallbackTarget(this);
        }

        public void OnEvent(EventData photonEvent)
        {
            // ↓こっちは違うデータなので注意
            // var Params = photonEvent.parameters;
            // ↓送信した正しいデータはこっち
            var Params = (Dictionary<byte, object>)photonEvent.CustomData;
            for (byte i = 0; i < 3; i++)
            {
                var Data = (int)Params[i];
                Debug.Log(string.Format("{0} : {1}", i, Data));
            }
        }
    }
}
