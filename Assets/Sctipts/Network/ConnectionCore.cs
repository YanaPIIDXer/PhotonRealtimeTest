using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.System;

namespace Game.Network
{
    /// <summary>
    /// サーバとの接続管理
    /// </summary>
    public class ConnectionCore : MonoBehaviour
    {
        /// <summary>
        /// インスタンス
        /// </summary>
        /// <value></value>
        public static ConnectionCore Instance
        {
            get
            {
                _Instance = PrefabManager.Instance.Load<ConnectionCore>("Prefabs/System/ConnectionCore");
                return _Instance;
            }
        }
        private static ConnectionCore _Instance = null;

        void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
