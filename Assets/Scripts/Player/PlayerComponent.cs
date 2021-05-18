using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Packet;
using Game.Network;

namespace Game.Player
{
    /// <summary>
    /// プレイヤーコンポーネント
    /// </summary>
    public abstract class PlayerComponent
    {
        /// <summary>
        /// 所有者
        /// </summary>
        private PlayerCharacter Owner = null;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="Owner">所有者</param>
        public PlayerComponent(PlayerCharacter Owner)
        {
            this.Owner = Owner;
        }

        /// <summary>
        /// パケット送信
        /// </summary>
        /// <param name="Packet">パケット</param>
        protected void SendPacket(IPacket Packet)
        {
            ServerConnection.Instance.SendPacket(Owner.transform.position, Packet);
        }

        /// <summary>
        /// Update
        /// </summary>
        public virtual void OnUpdate() { }

        /// <summary>
        /// FixedUpdate
        /// </summary>
        public virtual void OnFixedUpdate() { }
    }
}
