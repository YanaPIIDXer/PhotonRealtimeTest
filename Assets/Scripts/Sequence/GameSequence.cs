using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Network;
using UniRx;
using System;
using Photon.Realtime;
using ExitGames.Client.Photon;
using Game.UI;
using Game.UI.Component;
using Game.Player;
using Game.Stream;
using Game.Packet;
using Game.System;

namespace Game.Sequence
{
    /// <summary>
    /// ゲームシーケンス
    /// </summary>
    public class GameSequence : MonoBehaviour, IOnEventCallback
    {
        /// <summary>
        /// 他人リスト
        /// </summary>
        private Dictionary<int, PlayerHandler> OtherPlayers = new Dictionary<int, PlayerHandler>();

        #region これどこかに定数定義無いの？

        /// <summary>
        /// プレイヤー入場イベントコード
        /// </summary>
        private const byte PlayerJoinCode = 255;

        /// <summary>
        /// プレイヤー退場イベントコード
        /// </summary>
        private const byte PlayerLeaveCode = 254;

        #endregion

        public void OnEvent(EventData photonEvent)
        {
            switch (photonEvent.Code)
            {
                case PlayerJoinCode:

                    // 入場
                    OtherPlayers.Add(photonEvent.Sender, new PlayerHandler());
                    break;

                case PlayerLeaveCode:

                    // 退場
                    if (OtherPlayers.ContainsKey(photonEvent.Sender))
                    {
                        OtherPlayers[photonEvent.Sender].Destroy();
                        OtherPlayers.Remove(photonEvent.Sender);
                    }
                    break;

                default:

                    // その他パケット
                    OnRecvPacket(photonEvent);
                    break;
            }
        }

        /// <summary>
        /// パケットを受信した
        /// </summary>
        /// <param name="Data">データ</param>
        private void OnRecvPacket(EventData Data)
        {
            IPacket Packet = null;
            switch ((EPacketID)Data.Code)
            {
                case EPacketID.PlayerMove:

                    Packet = new PacketPlayerMove();
                    break;

                default:
                    throw new Exception("Invalid Packet Code:" + Data.Code);
            }

            DictionaryStreamReader Reader = new DictionaryStreamReader((Dictionary<byte, object>)Data.CustomData);
            Packet.Serialize(Reader);

            Vector3 Position = new Vector3();
            Position.Serialize(Reader);

            if (!OtherPlayers.ContainsKey(Data.Sender))
            {
                // 知らない人からのパケットを受信した場合、その人を生成する
                // ※入退場はPhotonのシステムで通知されるけど、既にルームにいる人はそうでもないらしい
                OtherPlayers.Add(Data.Sender, new PlayerHandler());
            }

            if (!OtherPlayers[Data.Sender].IsActive)
            {
                // 座標が確定するので生成
                OtherPlayers[Data.Sender].Spawn(Position);
            }

            OtherPlayers[Data.Sender].OnRecvPacket(Position, Packet);
        }

        void Awake()
        {
            Game.Network.ServerConnection.Instance.RegisterCallbackTarget(this);

            var Handler = UIManager.Instance.Show<GameHUD>("GameHUD");
            var Player = PrefabManager.Instance.Load<PlayerCharacter>("Prefabs/System/Player");
            Player.SetupAsLocalPlayer(Handler.Instance.Inputs);
        }

        void OnDestroy()
        {
            Game.Network.ServerConnection.Instance.UnregisterCallbackTarget(this);
        }
    }
}
