using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Network
{
    /// <summary>
    /// ロビーイベントリスナ
    /// </summary>
    public class LobbyEventListener : MonoBehaviour
    {
        /// <summary>
        /// インスタンス
        /// </summary>
        public static LobbyEventListener Instance { get; private set; }

        void Awake()
        {
            Instance = this;
        }
    }
}
