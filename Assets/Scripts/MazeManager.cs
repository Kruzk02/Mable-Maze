
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MazeManager : MonoBehaviour
{

    [SerializeField] private HoleSpawner holeSpawner;
    [SerializeField] private WallSpawner wallSpawner;
    [SerializeField] private BallSpawner ballSpawner;
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private TextMeshProUGUI timeUI;
    [SerializeField] private Button resetButton;
    [SerializeField] private float startTime = 30f;
    
    private int _counter;
    private float _timeRemaining;
    private void Start()
    {
        resetButton.onClick.AddListener(OnButtonClicked);
        resetButton.gameObject.SetActive(false);
        _timeRemaining = startTime;
        
        var mazeGenerator = new MazeGenerator(7,7);
        var cells = mazeGenerator.GetCells();
        
        holeSpawner.Initialize(cells);
        wallSpawner.Initialize(cells);
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (_timeRemaining > 0)
        {
            _timeRemaining -= Time.deltaTime;
            var seconds = Mathf.CeilToInt(_timeRemaining);
            timeUI.text = "";
            timeUI.text = seconds.ToString();
        }
        else
        {
            timeUI.text = "";
            timeUI.text = "0";
            Time.timeScale = 0;
            resetButton.gameObject.SetActive(true);
        }
    }

    private void OnButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        resetButton.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        TriggerHandler.OnCollisionEnter += HandleTriggerEnter;
    }
    
    private void OnDisable()
    {
        TriggerHandler.OnCollisionEnter -= HandleTriggerEnter;
    }

    private void HandleTriggerEnter(Collider other)
    {
        transform.rotation = Quaternion.identity;
        
        var mazeGenerator = new MazeGenerator(7,7);
        var cells = mazeGenerator.GetCells();
        
        holeSpawner.Respawn(cells);
        wallSpawner.Respawn(cells);
        ballSpawner.Respawn();
        
        scoreUI.text = "";
        _timeRemaining += 30;
        _counter++;
        scoreUI.text += _counter.ToString();
    }
}
