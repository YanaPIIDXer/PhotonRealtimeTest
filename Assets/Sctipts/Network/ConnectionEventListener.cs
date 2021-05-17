using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;

namespace Game.Network
{
    public class ConnectionEventListener : MonoBehaviour, IConnectionCallbacks
    {
        /// <summary>
        /// インスタンス
        /// </summary>
        public static ConnectionEventListener Instance
        {
            get
            {
                if (!ServerConnection.HasInstance)
                {
                    ServerConnection.MakeIntsance();
                }
                return _Instance;
            }
            private set { _Instance = value; }
        }
        private static ConnectionEventListener _Instance = null;

        public string Hoge = "Hoge";

        public void OnConnected()
        {
        }

        public void OnConnectedToMaster()
        {
        }

        public void OnCustomAuthenticationFailed(string debugMessage)
        {
        }

        public void OnCustomAuthenticationResponse(Dictionary<string, object> data)
        {
        }

        public void OnDisconnected(DisconnectCause cause)
        {
        }

        public void OnRegionListReceived(RegionHandler regionHandler)
        {
        }

        void Awake()
        {
            Instance = this;
        }
    }
}
