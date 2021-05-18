using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

namespace Game.UI.Component
{
    /// <summary>
    /// 移動用バーチャルスティック
    /// </summary>
    public class MoveInput : MonoBehaviour
    {
        /// <summary>
        /// 入力ベクトル
        /// </summary>
        private ReactiveProperty<Vector2> InputVector = new ReactiveProperty<Vector2>();

        /// <summary>
        /// 入力量
        /// </summary>
        public IObservable<Vector2> InputValue { get { return InputVector; } }

        /// <summary>
        /// スティック
        /// </summary>
        private FixedJoystick Stick = null;

        void Awake()
        {
            Stick = GetComponent<FixedJoystick>();
        }

        void Update()
        {
            Vector2 StickValue = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (StickValue.sqrMagnitude == 0.0f)
            {
                StickValue.x = Stick.Horizontal;
                StickValue.y = Stick.Vertical;
            }
            InputVector.Value = StickValue;
        }
    }
}
