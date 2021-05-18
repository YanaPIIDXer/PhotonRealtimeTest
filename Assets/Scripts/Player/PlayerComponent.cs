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
        /// <param name="Onwer">所有者</param>
        public PlayerComponent(PlayerCharacter Owner)
        {
            this.Owner = Owner;
        }

        /// <summary>
        /// GetComponentでMonoBehaviour派生のComponentを取得
        /// </summary>
        /// <typeparam name="T">MonoBehaviour派生Component</typeparam>
        /// <returns>Component</returns>
        protected T GetMonoBehaviourComponent<T>()
            where T : MonoBehaviour
        {
            return Owner.GetComponent<T>();
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
