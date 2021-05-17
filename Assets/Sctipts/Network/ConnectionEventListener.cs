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

        public void OnConnected()
        {
            Debug.Log("Connected");
        }

        public void OnConnectedToMaster()
        {
            Debug.Log("ConnectedToMaster");
        }

        public void OnCustomAuthenticationFailed(string debugMessage)
        {
        }

        public void OnCustomAuthenticationResponse(Dictionary<string, object> data)
        {
        }

        public void OnDisconnected(DisconnectCause cause)
        {
            Debug.Log("Disconnected. Reason:" + cause.ToString());
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
