using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.System;
using Game.Packet;

namespace Game.Player
{
    /// <summary>
    /// プレイヤーハンドラ
    /// </summary>
    public class PlayerHandler
    {
        /// <summary>
        /// プレイヤー
        /// </summary>
        private PlayerCharacter Player = null;

        /// <summary>
        /// 生成されているか？
        /// </summary>
        public bool IsActive { get { return Player != null; } }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PlayerHandler()
        {
        }

        /// <summary>
        /// 生成
        /// </summary>
        /// <param name="Position">座標</param>
        public void Spawn(Vector3 Position)
        {
            if (IsActive) { return; }

            Player = PrefabManager.Instance.Load<PlayerCharacter>("Prefabs/System/Player");
            Player.transform.position = Position;
            Player.SetupAsOtherPlayer();
        }

        /// <summary>
        /// 破棄
        /// </summary>
        public void Destroy()
        {
            GameObject.Destroy(Player.gameObject);
            Player = null;
        }

        /// <summary>
        /// パケットを受信した
        /// </summary>
        /// <param name="Position">座標</param>
        /// <param name="Packet">パケット</param>
        public void OnRecvPacket(Vector3 Position, IPacket Packet)
        {
            if (!IsActive) { return; }
            Player.OnRecvPacket(Position, Packet);
        }
    }
}
