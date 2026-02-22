using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Brackeys2026
{
    public class MainMenuScript : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void LoadFirstLevel() {
            SceneManager.LoadScene("MetroidvaniaScene");
        }
		public void ExitGame() {
			Application.Quit();
		}
	}
}
