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
    /// 他人の移動
    /// </summary>
    public class OtherPlayerMove : PlayerComponent
    {
        /// <summary>
        /// 所有者のTransform
        /// </summary>
        private Transform OwnerTransform = null;

        /// <summary>
        /// 以前の座標
        /// </summary>
        private Vector3 PrevPos = Vector3.zero;

        /// <summary>
        /// 移動先
        /// </summary>
        private Vector3 DestPos = Vector3.zero;

        /// <summary>
        /// 残り移動時間
        /// </summary>
        private float LastTime = 0.0f;

        /// <summary>
        /// 移動時間
        /// </summary>
        private static readonly float MoveTime = 1.0f;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="Owner">所有者</param>
        /// <param name="PacketObservable">パケット受信Observable</param>
        public OtherPlayerMove(PlayerCharacter Owner, IObservable<PacketProtocol> PacketObservable)
            : base(Owner)
        {
            OwnerTransform = Owner.transform;
            PacketObservable
                .Where((Recv) => Recv.Packet.PacketID == EPacketID.PlayerMove)
                .Select((Recv) => Recv.Position)
                .Subscribe((Pos) =>
                {
                    PrevPos = OwnerTransform.position;
                    DestPos = Pos;
                    LastTime = MoveTime;
                });
        }

        /// <summary>
        /// Update
        /// </summary>
        public override void OnUpdate()
        {
            if (LastTime <= 0.0f) { return; }

            LastTime = Mathf.Max(0.0f, LastTime - Time.deltaTime);
            float Ratio = 1.0f - (LastTime / MoveTime);
            OwnerTransform.position = Vector3.Lerp(PrevPos, DestPos, Ratio);
        }
    }
}
