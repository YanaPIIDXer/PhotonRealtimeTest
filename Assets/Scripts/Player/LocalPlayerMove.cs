using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

namespace Game.Player
{
    /// <summary>
    /// 自キャラの移動
    /// </summary>
    public class LocalPlayerMove : PlayerComponent
    {
        /// <summary>
        /// Rigidboy
        /// </summary>
        private Rigidbody Body = null;

        /// <summary>
        /// 移動ベクトル
        /// </summary>
        private Vector2 MoveDirection = Vector2.zero;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="Body">Rigidbody</param>
        /// <param name="MoveObservable">移動入力のObservable</param>
        public LocalPlayerMove(Rigidbody Body, IObservable<Vector2> MoveObservable)
        {
            this.Body = Body;
            MoveObservable
                .Subscribe((Direction) => MoveDirection = Direction);
        }

        /// <summary>
        /// FixedUpdate
        /// </summary>
        public override void OnFixedUpdate()
        {
            Body.velocity = new Vector3(MoveDirection.x, 0.0f, MoveDirection.y);
        }
    }
}
