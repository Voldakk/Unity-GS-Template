using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace Voldakk.GS
{
    [RequireComponent(typeof(Look))]
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(FirstPersonController))]
    public class Player : NetworkObject
    {
        [SerializeField]
        private GameObject model;
        [SerializeField]
        private GameObject camaraHolder;

        void Start()
        {
            GameManager.Instance().SetPlayer(this, owner);
            Initialize();
        }

        public void Initialize()
        {
            if (isOwner)
                model.SetActive(false);
            else
            {
                camaraHolder.SetActive(false);

                GetComponent<Look>().enabled = false;
                GetComponent<CharacterController>().enabled = false;
                GetComponent<FirstPersonController>().enabled = false;
            }
        }
    }
}