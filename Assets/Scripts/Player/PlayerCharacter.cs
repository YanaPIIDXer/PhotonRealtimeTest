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
    /// パケットプロトコル
    /// </summary>
    public struct PacketProtocol
    {
        /// <summary>
        /// 座標
        /// </summary>
        public Vector3 Position;

        /// <summary>
        /// パケット
        /// </summary>
        public IPacket Packet;
    }

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
        private Subject<PacketProtocol> OnRecvPacketSubject = new Subject<PacketProtocol>();

        /// <summary>
        /// 自キャラとしてセットアップ
        /// </summary>
        /// <param name="Input">各種入力</param>
        public void SetupAsLocalPlayer(InputObservables Input)
        {
            LocalPlayerMove Move = new LocalPlayerMove(this, Input.Move);
            MovePacketSender MoveSender = new MovePacketSender(this);

            RegisterPlayerComponent(Move);
            RegisterPlayerComponent(MoveSender);
        }

        /// <summary>
        /// 他人としてセットアップ
        /// </summary>
        public void SetupAsOtherPlayer()
        {
            OtherPlayerMove Move = new OtherPlayerMove(this, OnRecvPacketSubject);

            RegisterPlayerComponent(Move);
        }

        /// <summary>
        /// パケットを受信した
        /// </summary>
        /// <param name="Position">受信した時点での座標</param>
        /// <param name="Packet">パケット</param>
        public void OnRecvPacket(Vector3 Position, IPacket Packet)
        {
            PacketProtocol Protocol = new PacketProtocol()
            {
                Position = Position,
                Packet = Packet
            };
            OnRecvPacketSubject.OnNext(Protocol);
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
