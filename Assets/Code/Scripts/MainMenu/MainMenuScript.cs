using UnityEngine;
using UnityEngine.SceneManagement;

namespace Brackeys2026
{
    public class MainMenuScript : MonoBehaviour
    {

        public void LoadFirstLevel() {
            SceneManager.LoadScene("MetroidvaniaScene");
        }
        public void ExitGame() {
            Application.Quit();
        }
    }
}
