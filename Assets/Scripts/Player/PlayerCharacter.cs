using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.UI;
using Game.Packet;
using UniRx;
using System;

namespace Game.Player
{
    /// <summary>
    /// プレイヤーキャラ
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerCharacter : MonoBehaviour
    {
        /// <summary>
        /// コンポーネントリスト
        /// </summary>
        private List<PlayerComponent> Components = new List<PlayerComponent>();

        /// <summary>
        /// パケットを受信した
        /// </summary>
        private Subject<IPacket> OnRecvPacketSubject = new Subject<IPacket>();

        /// <summary>
        /// 自キャラとしてセットアップ
        /// </summary>
        /// <param name="Input">各種入力</param>
        public void SetupAsLocalPlayer(InputObservables Input)
        {
            LocalPlayerMove Move = new LocalPlayerMove(this, Input.Move);
            RegisterPlayerComponent(Move);
        }

        /// <summary>
        /// 他人としてセットアップ
        /// </summary>
        public void SetupAsOtherPlayer()
        {
        }

        /// <summary>
        /// パケットを受信した
        /// </summary>
        /// <param name="Packet">パケット</param>
        public void OnRecvPacket(IPacket Packet)
        {
            OnRecvPacketSubject.OnNext(Packet);
        }

        /// <summary>
        /// PlayerComponentを登録
        /// </summary>
        /// <param name="Component">PlayerComponent</param>
        private void RegisterPlayerComponent(PlayerComponent Component)
        {
            Components.Add(Component);
        }

        void Update()
        {
            foreach (var Component in Components)
            {
                Component.OnUpdate();
            }
        }

        void FixedUpdate()
        {
            foreach (var Component in Components)
            {
                Component.OnFixedUpdate();
            }
        }
    }
}
