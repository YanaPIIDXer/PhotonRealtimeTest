﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.UI;
using Game.Network;
using UniRx;

namespace Game.Sequence
{
    /// <summary>
    /// タイトルシーケンス
    /// </summary>
    public class TitleSequence : MonoBehaviour
    {
        void Awake()
        {
            var ButtonHandler = UIManager.Instance.Show<LogInButton>("LogInButton");
            ButtonHandler.Instance.OnPressed
                .Subscribe((_) =>
                {
                    ConnectionCore.Instance.Connect();
                    ButtonHandler.Destroy();
                }).AddTo(gameObject);
        }
    }
}
