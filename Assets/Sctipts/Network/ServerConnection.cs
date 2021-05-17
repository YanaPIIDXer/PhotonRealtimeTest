using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.System;
using Photon.Realtime;

namespace Game.Network
{
    /// <summary>
    /// サーバとの接続
    /// </summary>
    [RequireComponent(typeof(LobbyEventListener))]
    [RequireComponent(typeof(RoomEventListener))]
    public class ServerConnection : MonoBehaviour, IConnectionCallbacks
    {
        /// <summary>
        /// インスタンス
        /// </summary>
        public static ServerConnection Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = PrefabManager.Instance.Load<ServerConnection>("Prefabs/System/ServerConnection");
                }
                return _Instance;
            }
        }
        private static ServerConnection _Instance = null;

        /// <summary>
        /// クライアント
        /// </summary>
        private LoadBalancingClient Client = new LoadBalancingClient();

        void Awake()
        {
            DontDestroyOnLoad(gameObject);
            Client.AddCallbackTarget(this);
            Client.AddCallbackTarget(GetComponent<LobbyEventListener>());
            Client.AddCallbackTarget(GetComponent<RoomEventListener>());
        }

        void OnDestroy()
        {
            Client.RemoveCallbackTarget(this);
            Client.RemoveCallbackTarget(GetComponent<LobbyEventListener>());
            Client.RemoveCallbackTarget(GetComponent<RoomEventListener>());
        }

        public void OnConnected()
        {
        }

        public void OnConnectedToMaster()
        {
        }

        public void OnDisconnected(DisconnectCause cause)
        {
        }

        public void OnRegionListReceived(RegionHandler regionHandler)
        {
        }

        public void OnCustomAuthenticationResponse(Dictionary<string, object> data)
        {
        }

        public void OnCustomAuthenticationFailed(string debugMessage)
        {
        }
    }
}
