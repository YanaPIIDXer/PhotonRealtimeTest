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
        /// コンストラクタ
        /// </summary>
        /// <param name="Owner">所有者</param>
        public MovePacketSender(PlayerCharacter Owner)
            : base(Owner)
        {
            Observable.Interval(TimeSpan.FromSeconds(1.0))
                .Subscribe((Pos) => SendPacket(new PacketPlayerMove()));
        }
    }
}
