using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using Game.Network;
using Game.UI;
using Game.UI.Component;
using UniRx.Operators;

namespace Game.Sequence
{
    /// <summary>
    /// タイトルシーケンス
    /// </summary>
    public class TitleSequence : MonoBehaviour
    {
        void Awake()
        {
            ConnectionEventListener.Instance.Connected
                .Subscribe((_) =>
                {
                    ServerConnection.Instance.JoinLobby();
                });

            LobbyEventListener.Instance.RoomListUpdate
                .Subscribe((Rooms) =>
                {
                    // ↓Select使いたかったけど、ルームに入る時にルーム名が要求されるのでリストのまま
                    if (Rooms.Count > 0)
                    {
                        // 既存のルームへ
                        ServerConnection.Instance.JoinRoom(Rooms[0].Name);
                    }
                    else
                    {
                        // ルーム作成
                        ServerConnection.Instance.CreateRoom("Hoge");
                    }
                });

            RoomEventListener.Instance.JoinedRoom
                .Subscribe((_) => Debug.Log("げぇむ　すたぁと"));

            UIManager.Instance.Show<TitleScreen>("TitleScreen");
        }
    }
}
