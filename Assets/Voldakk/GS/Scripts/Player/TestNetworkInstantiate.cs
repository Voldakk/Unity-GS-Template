using UnityEngine;

namespace Voldakk.GS
{
    public class TestNetworkInstantiate : MonoBehaviour
    {
        public GameObject prefab;

        public string button;
        public Transform position;

        void Update()
        {
            if (Input.GetButtonDown(button) && GetComponent<Player>().owner == GameSparksManager.PeerId())
            {
                NetworkManager.NetworkInstantiate(prefab, position: position.position);
            }
        }
    }
}