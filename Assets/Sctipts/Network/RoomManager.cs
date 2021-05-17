using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Game.System;
using UniRx;
using System;

namespace Game.Network
{
    /// <summary>
    /// ルームマネージャ
    /// </summary>
    public class RoomManager : MonoBehaviour, IMatchmakingCallbacks
    {
        /// <summary>
        /// Prefabのパス
        /// </summary>
        private static readonly string PrefabPath = "Prefabs/System/RoomManager";

        #region Singleton

        /// <summary>
        /// インスタンス
        /// </summary>
        public static RoomManager Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = PrefabManager.Instance.Load<RoomManager>(PrefabPath);
                }
                return _Instance;
            }
        }
        private static RoomManager _Instance = null;

        #endregion

        /// <summary>
        /// 参加Subject
        /// </summary>
        private Subject<Unit> OnJoinedSubject = new Subject<Unit>();

        /// <summary>
        /// 参加した
        /// </summary>
        public IObservable<Unit> OnJoined { get { return OnJoinedSubject; } }

        /// <summary>
        /// 離脱Subject
        /// </summary>
        private Subject<Unit> OnLeaveSubject = new Subject<Unit>();

        /// <summary>
        /// 離脱した
        /// </summary>
        public IObservable<Unit> OnLeave { get { return OnLeaveSubject; } }

        void Awake()
        {
            ConnectionCore.Instance.AddCallbackTarget(this);
            DontDestroyOnLoad(gameObject);
        }

        void OnDestroy()
        {
            ConnectionCore.Instance.RemoveCallbackTarget(this);
        }

        #region IMatchmakingCallbacks

        public void OnCreatedRoom()
        {
            Debug.Log("OnCreatedRoom()");
        }

        public void OnCreateRoomFailed(short returnCode, string message)
        {
            Debug.LogError(string.Format("OnCreatedRoomFailed({0}, {1})", returnCode, message));
        }

        public void OnFriendListUpdate(List<FriendInfo> friendList)
        {
            Debug.Log("OnFriendListUpdate()  FriendCount:" + friendList.Count);
        }

        public void OnJoinedRoom()
        {
            OnJoinedSubject.OnNext(Unit.Default);
        }

        public void OnJoinRandomFailed(short returnCode, string message)
        {
            Debug.LogError(string.Format("OnJoinRandomFailed({0}, {1})", returnCode, message));
        }

        public void OnJoinRoomFailed(short returnCode, string message)
        {
            Debug.LogError(string.Format("OnJoinRoomFailed({0}, {1})", returnCode, message));
        }

        public void OnLeftRoom()
        {
            OnLeaveSubject.OnNext(Unit.Default);
        }
        #endregion
    }
}
