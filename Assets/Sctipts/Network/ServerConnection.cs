using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.System;
using Photon.Realtime;
using Game.Enviroment;
using UniRx;
using System;

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
                AppIdRealtime = Environments.Instance.ApplicationKey,
                FixedRegion = "jp"
            }))
            {
                Debug.LogError("Connection Failed.");
            }
        }

        /// <summary>
        /// ロビーに入る
        /// </summary>
        public void JoinLobby()
        {
            Client.OpJoinLobby(TypedLobby.Default);
        }

        /// <summary>
        /// ルーム作成
        /// </summary>
        /// <param name="RoomName">ルーム名</param>
        public void CreateRoom(string RoomName)
        {
            EnterRoomParams Params = new EnterRoomParams();
            Params.RoomName = RoomName;
            Params.RoomOptions = new RoomOptions();
            Params.RoomOptions.MaxPlayers = 50;
            Client.OpCreateRoom(Params);
        }

        /// <summary>
        /// ルームに参加
        /// </summary>
        /// <param name="RoomName">ルーム名</param>
        public void JoinRoom(string RoomName)
        {
            EnterRoomParams Params = new EnterRoomParams();
            Params.RoomName = RoomName;
            Client.OpJoinRoom(Params);
        }

        /// <summary>
        /// コールバック対象に登録
        /// </summary>
        /// <param name="Target">対象</param>
        public void RegisterCallbackTarget(object Target)
        {
            Client.AddCallbackTarget(Target);
        }

        /// <summary>
        /// コールバック対象から外す
        /// </summary>
        /// <param name="Target">対象</param>
        public void UnregisterCallbackTarget(object Target)
        {
            Client.RemoveCallbackTarget(Target);
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
