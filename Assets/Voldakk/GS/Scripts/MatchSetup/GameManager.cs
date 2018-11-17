using UnityEngine;

namespace Voldakk.GS
{
    public class GameManager : MonoBehaviour
    {
        public GameObject playerPrefab;

        public Countdown matchStartCountdown;
        public GameObject inGameUi;
        public GameObject topCamera;

        private GameObject[] spawnPoints;
        private Player[] playerList;

        public Player[] GetAllPlayers()
        {
            return playerList;
        }

        public void SetPlayer(Player player, int owner)
        {
            playerList[owner - 1] = player;
        }

        public Player Player()
        {
            for (int i = 0; i < playerList.Length; i++)
            {
                if (playerList[i].owner == GameSparksManager.PeerId())
                {
                    return playerList[i];
                }
            }

            return null;
        }

        public bool IsHost
        {
            get
            {
                return GameSparksManager.PeerId() == 1;
            }
        }

        private static GameManager instance;

        public static GameManager Instance()
        {
            return instance;
        }

        public int NumPlayers()
        {
            return playerList.Length;
        }

        void Awake()
        {
            inGameUi.SetActive(false);
            instance = this;

            playerList = new Player[GameSparksManager.Instance().GetSessionInfo().GetPlayerList().Count];
        }

        public void SetMatchStartTimer(float time)
        {
            Debug.Log("GameManager::SetMatchStartTimer - Match timer:" + time);

            if (matchStartCountdown != null)
                matchStartCountdown.SetCountdown(time);
        }

        public void StartMatch()
        {
            matchStartCountdown.gameObject.SetActive(false);
            inGameUi.SetActive(true);
            topCamera.SetActive(false);

            if (!IsHost)
                return;

            spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

            for (int i = 0; i < playerList.Length; i++)
            {
                int peerId = GameSparksManager.Instance().GetSessionInfo().GetPlayerList()[i].peerId;
                Vector3 spawnPos = spawnPoints[i].transform.position;
                Quaternion spawnRot = spawnPoints[i].transform.rotation;

                playerList[i] = NetworkManager.NetworkInstantiate(playerPrefab, peerId, spawnPos, spawnRot).GetComponent<Player>();
            }
        }
    }
}