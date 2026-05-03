using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.InGame
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreUI;
        [SerializeField] private TextMeshProUGUI timeUI;
        [SerializeField] private TextMeshProUGUI bestScoreUI;
        [SerializeField] private Button resetButton;

        public void UpdateTime(int seconds)
        {
            timeUI.text = seconds.ToString();
        }

        public void UpdateScore(int score)
        {
            scoreUI.text = score.ToString();
        }

        public void ShowReset(bool show)
        {
            resetButton.gameObject.SetActive(show);
        }

        public void ShowBestScore(int bestScore)
        {
            bestScoreUI.text = $"Best Score: {bestScore.ToString()}";
        }

        public void SetBestScoreVisible(bool visible)
        {
            bestScoreUI.gameObject.SetActive(visible);
        }

        public void SetResetAction(UnityAction action)
        {
            resetButton.onClick.RemoveAllListeners();
            resetButton.onClick.AddListener(action);
        }
    }
}