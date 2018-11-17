using UnityEngine;
using UnityEngine.UI;

namespace Voldakk.GS
{
    [RequireComponent(typeof(Button))]
    public class ExitGameButton : MonoBehaviour
    {
        void Awake()
        {
            GetComponent<Button>().onClick.AddListener(() =>
            {
                Application.Quit();
            });
        }
    }
}