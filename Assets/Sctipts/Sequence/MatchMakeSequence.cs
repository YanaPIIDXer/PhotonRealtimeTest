using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Game.Network;
using Game.UI;
using UniRx;
using System;
using UnityEngine.SceneManagement;

namespace Game.Sequence
{
    /// <summary>
    /// マッチメイクシーケンス
    /// </summary>
    public class MatchMakeSequence : MonoBehaviour
    {
        void Awake()
        {
            var Handler = UIManager.Instance.Show<MatchMakeInterface>("MatchMakeInterface");
            Handler.Instance.OnCreateRoom
                .Subscribe((RoomName) => ConnectionCore.Instance.CreateRoom(RoomName, 2));

            RoomManager.Instance.OnJoined
                .Subscribe((_) =>
                {
                    SceneManager.LoadScene("Game");
                }).AddTo(gameObject);
        }
    }
}
