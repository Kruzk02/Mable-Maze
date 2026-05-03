using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI.MainMenu
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private Button playButton;
        [SerializeField] private Button quitButton;
    
        private void Start()
        {
            playButton.onClick.RemoveAllListeners();
            playButton.onClick.AddListener(PlayGame);
        
            quitButton.onClick.RemoveAllListeners();
            quitButton.onClick.AddListener(QuitGame);
        }

        private static void PlayGame()
        {
            SceneManager.LoadScene("MarbleMazeScene");
        }

        private static void QuitGame()
        {
            Application.Quit();
        }
    }
}
