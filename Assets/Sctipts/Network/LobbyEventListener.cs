using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using UniRx;
using System;

namespace Game.Network
{
    /// <summary>
    /// ロビーイベントリスナ
    /// </summary>
    public class LobbyEventListener : MonoBehaviour, ILobbyCallbacks
    {
        /// <summary>
        /// インスタンス
        /// </summary>
        public static LobbyEventListener Instance
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
        private static LobbyEventListener _Instance = null;

        /// <summary>
        /// ロビーに入った時のSubject1
        /// </summary>
        private Subject<Unit> JoinedLobbySubject = new Subject<Unit>();

        /// <summary>
        /// ロビーに入った
        /// </summary>
        /// <value></value>
        public IObservable<Unit> JoinedLobby { get { return JoinedLobbySubject; } }

        /// <summary>
        /// ルームリストが更新された時のSubject
        /// </summary>
        private Subject<List<RoomInfo>> RoomListUpdateSubject = new Subject<List<RoomInfo>>();

        /// <summary>
        /// ルームリストが更新された
        /// </summary>
        public IObservable<List<RoomInfo>> RoomListUpdate => RoomListUpdateSubject;

        public void OnJoinedLobby()
        {
            JoinedLobbySubject.OnNext(Unit.Default);
        }

        public void OnLeftLobby()
        {
        }

        public void OnLobbyStatisticsUpdate(List<TypedLobbyInfo> lobbyStatistics)
        {
        }

        public void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            RoomListUpdateSubject.OnNext(roomList);
        }

        void Awake()
        {
            Instance = this;
        }
    }
}
