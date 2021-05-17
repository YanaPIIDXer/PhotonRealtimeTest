using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Enviroment
{
    /// <summary>
    /// 環境変数
    /// </summary>
    public partial class Environments
    {
        /// <summary>
        /// アプリケーションキー
        /// </summary>
        public string ApplicationKey { get; private set; }

        #region Singleton
        public static Environments Instance { get { return _Instance; } }
        private static Environments _Instance = new Environments();
        #endregion
    }
}
