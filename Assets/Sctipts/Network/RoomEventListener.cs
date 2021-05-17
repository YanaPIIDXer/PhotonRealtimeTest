﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Network
{
    /// <summary>
    /// ルームイベントリスナ
    /// </summary>
    public class RoomEventListener : MonoBehaviour
    {
        /// <summary>
        /// インスタンス
        /// </summary>
        public static RoomEventListener Instance { get; private set; }

        void Awake()
        {
            Instance = this;
        }
    }
}