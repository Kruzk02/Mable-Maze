using UnityEngine;
using UnityEngine.Serialization;

public class MazeManager : MonoBehaviour
{

    [SerializeField] private HoleSpawner holeSpawner;
    [SerializeField] private WallSpawner wallSpawner;
    [SerializeField] private BallSpawner ballSpawner;
    
    private void Start()
    {
        var mazeGenerator = new MazeGenerator(7,7);
        var cells = mazeGenerator.GetCells();
        
        holeSpawner.Initialize(cells);
        wallSpawner.Initialize(cells);
    }
}
