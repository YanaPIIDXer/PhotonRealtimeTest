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
        /// 移動速度
        /// </summary>
        private static readonly float MoveSpeed = 2.0f;

        /// <summary>
        /// 移動ベクトル更新Subject
        /// </summary>
        private Subject<Vector3> UpdateMoveVectorSubject = new Subject<Vector3>();

        /// <summary>
        /// 移動ベクトル更新
        /// </summary>
        public IObservable<Vector3> OnUpdateMoveVector { get { return UpdateMoveVectorSubject; } }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="Body">Rigidbody</param>
        /// <param name="MoveObservable">移動入力のObservable</param>
        public LocalPlayerMove(PlayerCharacter Owner, IObservable<Vector2> MoveObservable)
            : base(Owner)
        {
            Body = Owner.GetComponent<Rigidbody>();
            MoveObservable
                .Subscribe((Direction) =>
                {
                    MoveDirection = Direction;
                    UpdateMoveVectorSubject.OnNext(new Vector3(Direction.x, 0.0f, Direction.y) * MoveSpeed);
                });
        }

        /// <summary>
        /// FixedUpdate
        /// </summary>
        public override void OnFixedUpdate()
        {
            Body.velocity = new Vector3(MoveDirection.x, 0.0f, MoveDirection.y) * MoveSpeed;
        }
    }
}
