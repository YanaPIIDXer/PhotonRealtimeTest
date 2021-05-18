using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

namespace Game.UI
{
    /// <summary>
    /// 各種入力Observable
    /// </summary>
    public class InputObservables
    {
        /// <summary>
        /// 移動
        /// </summary>
        public IObservable<Vector2> Move = Observable.Never<Vector2>();
    }

    namespace Component
    {
        /// <summary>
        /// ゲームHUD
        /// </summary>
        public class GameHUD : UIComponent
        {
            /// <summary>
            /// ZOrder
            /// </summary>
            public override EZOrder ZOrder => EZOrder.MainHUD;

            /// <summary>
            /// 移動スティック
            /// </summary>
            [SerializeField]
            private MoveInput MoveStick = null;

            /// <summary>
            /// 各種入力のObservable
            /// </summary>
            public InputObservables Inputs
            {
                get
                {
                    if (_Inputs == null)
                    {
                        _Inputs = new InputObservables();
                        _Inputs.Move = MoveStick.InputValue;
                    }
                    return _Inputs;
                }
            }
            private InputObservables _Inputs = null;
        }
    }
}
