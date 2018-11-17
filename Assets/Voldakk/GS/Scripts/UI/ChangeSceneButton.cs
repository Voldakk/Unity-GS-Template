using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Voldakk.GS
{
    [RequireComponent(typeof(Button))]
    public class ChangeSceneButton : MonoBehaviour
    {
        public string sceneName;

        void Awake()
        {
            GetComponent<Button>().onClick.AddListener(() =>
            {
                SceneManager.LoadScene(sceneName);
            });
        }
    }
}