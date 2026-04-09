using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeManager : MonoBehaviour
{
    [SerializeField] private MazeController mazeController;
    [SerializeField] private UIController uiController;

    [SerializeField] private float startTime = 30f;
    [SerializeField] private float bonusTime = 30f;

    [SerializeField] private int rows = 10;
    [SerializeField] private int cols = 10;

    private int _counter;
    private float _timeRemaining;
    private bool _isGameOver;

    private void Start()
    {
        uiController.SetResetAction(RestartGame);
        uiController.ShowReset(false);

        _timeRemaining = startTime;
        uiController.UpdateScore(0);
        uiController.UpdateTime((int)startTime);
        uiController.SetBestScoreVisible(false);
        
        mazeController.Generate(rows, cols);

        Time.timeScale = 1;
    }

    private void Update()
    {
        if (_isGameOver) return;

        if (_timeRemaining > 0)
        {
            _timeRemaining -= Time.deltaTime;
            uiController.UpdateTime(Mathf.CeilToInt(_timeRemaining));
        }
        else
        {
            EndGame();
        }
    }

    private void OnEnable()
    {
        TriggerHandler.FinishHole += HandleTriggerEnter;
    }

    private void OnDisable()
    {
        TriggerHandler.FinishHole -= HandleTriggerEnter;
    }

    private void HandleTriggerEnter(Collider other)
    {
        transform.rotation = Quaternion.identity;

        mazeController.Respawn(rows, cols);

        _timeRemaining += bonusTime;
        _counter++;

        uiController.UpdateScore(_counter);
    }

    private void EndGame()
    {
        ScoreManager.SetBestScore(_counter);
        _isGameOver = true;
        uiController.UpdateTime(0);
        Time.timeScale = 0;
        uiController.ShowReset(true);
        uiController.SetBestScoreVisible(true);
        uiController.ShowBestScore(ScoreManager.GetBestScore());
    }

    private static void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}