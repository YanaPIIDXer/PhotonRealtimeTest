﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Game.Network;

namespace Game.Sequence
{
    /// <summary>
    /// マッチメイクシーケンス
    /// </summary>
    public class MatchMakeSequence : MonoBehaviour, IMatchmakingCallbacks
    {
        void Awake()
        {
            ConnectionCore.Instance.AddCallbackTarget(this);
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
            Debug.Log("OnJoinedRoom()");
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
            Debug.Log("OnLeftRoom()");
        }
        #endregion
    }
}