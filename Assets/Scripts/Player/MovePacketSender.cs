using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Operators;
using System;
using Game.Packet;

namespace Game.Player
{
    /// <summary>
    /// 移動パケット送信
    /// </summary>
    public class MovePacketSender : PlayerComponent
    {
        /// <summary>
        /// 現在の座標
        /// </summary>
        private ReactiveProperty<Vector3> CurrentPosition = new ReactiveProperty<Vector3>();

        /// <summary>
        /// 所有者のTransform
        /// </summary>
        private Transform OwnerTransform = null;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="Owner">所有者</param>
        public MovePacketSender(PlayerCharacter Owner)
            : base(Owner)
        {
            OwnerTransform = Owner.transform;

            CurrentPosition
                .ThrottleFirst(TimeSpan.FromSeconds(3.0))
                .Skip(1)
                .Subscribe((Pos) => SendPacket(new PacketPlayerMove()));
        }

        /// <summary>
        /// Update
        /// </summary>
        public override void OnUpdate()
        {
            CurrentPosition.Value = OwnerTransform.position;
        }
    }
}
