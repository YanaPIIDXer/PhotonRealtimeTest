using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using UniRx;
using System;

namespace Game.Network
{
    /// <summary>
    /// ルームイベントリスナ
    /// </summary>
    public class RoomEventListener : MonoBehaviour, IMatchmakingCallbacks
    {
        /// <summary>
        /// インスタンス
        /// </summary>
        public static RoomEventListener Instance
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
        private static RoomEventListener _Instance = null;

        /// <summary>
        /// 入室Subject
        /// </summary>
        private Subject<Unit> JoinedRoomSubject = new Subject<Unit>();

        /// <summary>
        /// 入室した
        /// </summary>
        public IObservable<Unit> JoinedRoom => JoinedRoomSubject;

        public void OnCreatedRoom()
        {
        }

        public void OnCreateRoomFailed(short returnCode, string message)
        {
        }

        public void OnFriendListUpdate(List<FriendInfo> friendList)
        {
        }

        public void OnJoinedRoom()
        {
            JoinedRoomSubject.OnNext(Unit.Default);
        }

        public void OnJoinRandomFailed(short returnCode, string message)
        {
        }

        public void OnJoinRoomFailed(short returnCode, string message)
        {
        }

        public void OnLeftRoom()
        {
        }

        void Awake()
        {
            Instance = this;
        }
    }
}
