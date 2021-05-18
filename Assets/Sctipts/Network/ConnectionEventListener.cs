using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using UniRx;
using System;

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

        /// <summary>
        /// 接続時Subect
        /// </summary>
        private Subject<Unit> ConnectedSubject = new Subject<Unit>();

        /// <summary>
        /// 接続された
        /// </summary>
        public IObservable<Unit> Connected { get { return ConnectedSubject; } }

        /// <summary>
        /// 切断時Subject
        /// </summary>
        private Subject<DisconnectCause> DisconnectedSubject = new Subject<DisconnectCause>();

        /// <summary>
        /// 切断された
        /// </summary>
        /// <value></value>
        public IObservable<DisconnectCause> Disconnected { get { return DisconnectedSubject; } }

        public void OnConnected()
        {
        }

        public void OnConnectedToMaster()
        {
            ConnectedSubject.OnNext(Unit.Default);
        }

        public void OnCustomAuthenticationFailed(string debugMessage)
        {
        }

        public void OnCustomAuthenticationResponse(Dictionary<string, object> data)
        {
        }

        public void OnDisconnected(DisconnectCause cause)
        {
            DisconnectedSubject.OnNext(cause);
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
