using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class MazeManager : MonoBehaviour
{

    [SerializeField] private HoleSpawner holeSpawner;
    [SerializeField] private WallSpawner wallSpawner;
    [SerializeField] private BallSpawner ballSpawner;
    [SerializeField] private TextMeshProUGUI scoreUI;

    private int _counter;
    private void Start()
    {
        var mazeGenerator = new MazeGenerator(7,7);
        var cells = mazeGenerator.GetCells();
        
        holeSpawner.Initialize(cells);
        wallSpawner.Initialize(cells);
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
        _counter++;
        scoreUI.text += _counter.ToString();
    }
}
