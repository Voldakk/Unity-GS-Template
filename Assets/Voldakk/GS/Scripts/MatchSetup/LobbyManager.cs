using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

namespace Voldakk.GS
{
    public class LobbyManager : MonoBehaviour
    {
        public Button readyButton;

        public static LobbyManager instance;

        public GameObject PlayerPanelPrefab;
        public RectTransform playerList;

        List<Transform> playerPanels;

        void Awake()
        {
            instance = this;
        }

        void Start()
        {
            readyButton.onClick.AddListener(() =>
            {
                OnReadyButton();
                SetPlayerReady(GameSparksManager.PeerId());
            });

            // Player list
            var players = GameSparksManager.Instance().GetSessionInfo().GetPlayerList();
            playerPanels = new List<Transform>();
            foreach (var player in players)
            {
                Transform playerPanel = Instantiate(PlayerPanelPrefab, playerList, false).transform;
                playerPanel.Find("DisplayName").GetComponent<TMP_Text>().text = player.displayName;
                playerPanel.Find("ReadyIcon").GetComponent<Image>().enabled = false;

                playerPanels.Add(playerPanel);
            }
        }

        void OnReadyButton()
        {
            GameSparksManager.Instance().SetPlayerReady(true);
            readyButton.interactable = false;
        }

        public void SetPlayerReady(int peerId)
        {
            playerPanels[peerId - 1].Find("ReadyIcon").GetComponent<Image>().enabled = true;
        }
    }
}