using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;

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
        public static RoomEventListener Instance { get; private set; }

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
