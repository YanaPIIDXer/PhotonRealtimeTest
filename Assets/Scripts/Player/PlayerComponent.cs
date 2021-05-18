using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        /// Update
        /// </summary>
        public virtual void OnUpdate() { }

        /// <summary>
        /// FixedUpdate
        /// </summary>
        public virtual void OnFixedUpdate() { }
    }
}
