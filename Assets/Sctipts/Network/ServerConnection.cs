using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.System;
using Photon.Realtime;
using Game.Enviroment;

namespace Game.Network
{
    /// <summary>
    /// サーバとの接続
    /// </summary>
    [RequireComponent(typeof(ConnectionEventListener))]
    [RequireComponent(typeof(LobbyEventListener))]
    [RequireComponent(typeof(RoomEventListener))]
    public class ServerConnection : MonoBehaviour
    {
        /// <summary>
        /// インスタンス
        /// </summary>
        public static ServerConnection Instance
        {
            get
            {
                MakeIntsance();
                return _Instance;
            }
        }
        private static ServerConnection _Instance = null;

        /// <summary>
        /// インスタンス化されているか？
        /// </summary>
        public static bool HasInstance { get { return _Instance != null; } }

        /// <summary>
        /// インスタンス生成
        /// </summary>
        public static void MakeIntsance()
        {
            if (_Instance == null)
            {
                _Instance = PrefabManager.Instance.Load<ServerConnection>("Prefabs/System/ServerConnection");
            }
        }

        /// <summary>
        /// クライアント
        /// </summary>
        private LoadBalancingClient Client = new LoadBalancingClient();

        /// <summary>
        /// 接続
        /// </summary>
        public void Connect()
        {
            if (!Client.ConnectUsingSettings(new AppSettings()
            {
                AppIdRealtime = Environments.Instance.AppliactionKey,
                FixedRegion = "jp"
            }))
            {
                Debug.LogError("Connection Failed.");
            }
        }

        void Awake()
        {
            DontDestroyOnLoad(gameObject);
            Client.AddCallbackTarget(GetComponent<ConnectionEventListener>());
            Client.AddCallbackTarget(GetComponent<LobbyEventListener>());
            Client.AddCallbackTarget(GetComponent<RoomEventListener>());
        }

        void OnDestroy()
        {
            Client.RemoveCallbackTarget(GetComponent<ConnectionEventListener>());
            Client.RemoveCallbackTarget(GetComponent<LobbyEventListener>());
            Client.RemoveCallbackTarget(GetComponent<RoomEventListener>());
        }

        void Update()
        {
            Client.Service();
        }
    }
}
