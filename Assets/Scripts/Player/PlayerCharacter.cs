using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{
    /// <summary>
    /// プレイヤーキャラ
    /// </summary>
    public class PlayerCharacter : MonoBehaviour
    {
        /// <summary>
        /// コンポーネントリスト
        /// </summary>
        private List<PlayerComponent> Components = new List<PlayerComponent>();

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
