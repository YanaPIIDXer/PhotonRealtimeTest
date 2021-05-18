using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

namespace Game.Player
{
    /// <summary>
    /// アニメーション関係Observable群
    /// </summary>
    public class AnimationObservables
    {
        /// <summary>
        /// 動いているか？
        /// </summary>
        public IObservable<bool> IsMoving = Observable.Never<bool>();
    }

    /// <summary>
    /// プレイヤーアニメーション
    /// </summary>
    public class PlayerAnimation : PlayerComponent
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="Owner">所有者</param>
        /// <param name="Observables">Observable群</param>
        public PlayerAnimation(PlayerCharacter Owner, AnimationObservables Observables)
            : base(Owner)
        {
            var Anim = Owner.GetComponent<Animator>();
            Observables.IsMoving
                .Subscribe((Moving) => Anim.SetBool("IsMoving", Moving));
        }
    }
}
