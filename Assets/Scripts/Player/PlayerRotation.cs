using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Operators;
using System;

namespace Game.Player
{
    /// <summary>
    /// プレイヤーの回転
    /// </summary>
    public class PlayerRotation : PlayerComponent
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="Owner">所有者</param>
        /// <param name="MoveVecObservable">移動ベクトルObservable</param>
        public PlayerRotation(PlayerCharacter Owner, IObservable<Vector3> MoveVecObservable)
            : base(Owner)
        {
            MoveVecObservable
                .Where((Vec) => Vec.sqrMagnitude >= 0.0f)
                .Subscribe(Vec => Owner.transform.LookAt(Owner.transform.position + Vec));
        }
    }
}
