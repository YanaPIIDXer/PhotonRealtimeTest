﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.System;
using Photon.Realtime;
using Game.Enviroment;
using UniRx;
using System;
using ExitGames.Client.Photon;

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
                if (_Instance == null)
                {
                    _Instance = PrefabManager.Instance.Load<ConnectionCore>("Prefabs/System/ConnectionCore");
                }
                return _Instance;
            }
        }
        private static ConnectionCore _Instance = null;
        #endregion

        /// <summary>
        /// クライアント
        /// </summary>
        private LoadBalancingClient Client = new LoadBalancingClient();

        /// <summary>
        /// 接続Subject
        /// </summary>
        private Subject<Unit> OnConnectedSubject = new Subject<Unit>();

        /// <summary>
        /// サーバに接続された
        /// </summary>
        /// <value></value>
        public IObservable<Unit> OnConnectedToServer { get { return OnConnectedSubject; } }

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
        /// コールバックを受け取るオブジェクトを設定
        /// </summary>
        /// <param name="Obj">コールバックを受け取るオブジェクト</param>
        public void AddCallbackTarget(object Obj)
        {
            Client.AddCallbackTarget(Obj);
        }

        /// <summary>
        /// コールバックを受け取りを解除
        /// </summary>
        /// <param name="Obj">コールバックを受け取っていたオブジェクト</param>
        public void RemoveCallbackTarget(object Obj)
        {
            Client.RemoveCallbackTarget(Obj);
        }

        /// <summary>
        /// ルームを作成
        /// </summary>
        /// <param name="RoomName">ルーム名</param>
        /// <param name="MaxPlayers">最大プレイヤー数</param>
        public void CreateRoom(string RoomName, byte MaxPlayers)
        {
            EnterRoomParams Param = new EnterRoomParams();
            Param.RoomName = RoomName;
            Param.RoomOptions = new RoomOptions();
            Param.RoomOptions.MaxPlayers = MaxPlayers;
            Client.OpCreateRoom(Param);
        }

        /// <summary>
        /// ゲーム中のイベント送信
        /// ※多分これPhotonServerと同じような仕組みなんじゃないかな・・・？
        /// 　だとすればPhotonServerTestで使ってるパケットが丸々使えることになるが。
        /// 　そうなったらこのメソッドはリストラになる
        /// </summary>
        /// <param name="Code">コード</param>
        /// <param name="Params">パラメータ</param>
        public void SendEvent(byte Code, Dictionary<byte, object> Params)
        {
            Client.OpRaiseEvent(Code, Params, RaiseEventOptions.Default, new SendOptions());
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
            OnConnectedSubject.OnNext(Unit.Default);
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
