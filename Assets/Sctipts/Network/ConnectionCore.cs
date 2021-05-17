using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.System;
using Photon.Realtime;
using Game.Enviroment;

namespace Game.Network
{
    /// <summary>
    /// サーバとの接続管理
    /// </summary>
    public class ConnectionCore : MonoBehaviour, IConnectionCallbacks
    {
        #region Instance
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
        #endregion



        /// <summary>
        /// クライアント
        /// </summary>
        private LoadBalancingClient Client = new LoadBalancingClient();

        void Awake()
        {
            DontDestroyOnLoad(gameObject);
            Client.AddCallbackTarget(this);
            Client.StateChanged += OnStateChange;
        }

        void Update()
        {
            Client.Service();
        }

        void OnDestroy()
        {
            Disconnect();
            Client.RemoveCallbackTarget(this);
        }

        /// <summary>
        /// 接続
        /// </summary>
        public void Connect()
        {
            var Settings = new AppSettings()
            {
                AppIdRealtime = Environments.Instance.AppliactionKey,
                FixedRegion = "jp"
            };
            Client.ConnectUsingSettings(Settings);
        }

        /// <summary>
        /// 切断
        /// </summary>
        public void Disconnect()
        {
            if (Client.IsConnected)
            {
                Client.Disconnect();
            }
        }

        /// <summary>
        /// クライアントの状態が遷移した
        /// </summary>
        /// <param name="Prev">前</param>
        /// <param name="Next">次</param>
        private void OnStateChange(ClientState Prev, ClientState Next)
        {
            Debug.Log("ClientStateChange:  " + Prev.ToString() + " => " + Next.ToString());
        }

        #region IConnectionCallbacks

        public void OnConnected()
        {
            Debug.Log("OnConnected()");
        }

        public void OnConnectedToMaster()
        {
            Debug.Log("OnConnectedToMaster()");
        }

        public void OnDisconnected(DisconnectCause cause)
        {
            Debug.Log("OnDisconnected(" + cause.ToString() + ")");
        }

        public void OnRegionListReceived(RegionHandler regionHandler)
        {
            Debug.Log("OnRegionListReceived()");
        }

        public void OnCustomAuthenticationResponse(Dictionary<string, object> data)
        {
            Debug.Log("OnCustomAuthenticationResponse()");
        }

        public void OnCustomAuthenticationFailed(string debugMessage)
        {
            Debug.LogError("OnCustomAuthenticationFailed()");
            Debug.LogError(debugMessage);
        }

        #endregion
    }
}
