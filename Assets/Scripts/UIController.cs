using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private TextMeshProUGUI timeUI;
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
    
    public void SetResetAction(UnityAction action)
    {
        resetButton.onClick.RemoveAllListeners();
        resetButton.onClick.AddListener(action);
    }
}
