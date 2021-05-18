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
        /// コンストラクタ
        /// </summary>
        public PlayerComponent()
        {
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
