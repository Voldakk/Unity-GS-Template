using UnityEngine;
using System.Collections.Generic;

namespace Voldakk.GS
{
    public class NetworkPrefabs : MonoBehaviour
    {
        public static NetworkPrefabs instance;

        public List<GameObject> prefabs;

        void Awake()
        {
            instance = this;
        }
    }
}