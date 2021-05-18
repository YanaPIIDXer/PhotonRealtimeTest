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
using Game.System;
using Game.Player;
using Game.Stream;
using Game.Packet;

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
        private Dictionary<int, PlayerCharacter> OtherPlayers = new Dictionary<int, PlayerCharacter>();

        public void OnEvent(EventData photonEvent)
        {
            Debug.Log("OnEvent Code:" + photonEvent.Code);
            IPacket Packet = null;
            switch ((EPacketID)photonEvent.Code)
            {
                case EPacketID.PlayerMove:

                    Packet = new PacketPlayerMove();
                    break;

                default:
                    throw new Exception("Invalid Packet Code:" + photonEvent.Code);
            }

            DictionaryStreamReader Reader = new DictionaryStreamReader((Dictionary<byte, object>)photonEvent.CustomData);
            Packet.Serialize(Reader);

            if (!OtherPlayers.ContainsKey(photonEvent.Sender))
            {
                // 知らない人からのパケットを受信した場合、その人を生成する
                var Player = PrefabManager.Instance.Load<PlayerCharacter>("Prefabs/System/Player");
                Player.SetupAsOtherPlayer();
                Vector3 Position = new Vector3();
                Position.Serialize(Reader);
                Player.transform.position = Position;
                OtherPlayers.Add(photonEvent.Sender, Player);
            }

            OtherPlayers[photonEvent.Sender].OnRecvPacket(Packet);
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
