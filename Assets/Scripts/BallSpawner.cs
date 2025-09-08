using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

public class BallSpawner : MonoBehaviour
{
    [FormerlySerializedAs("_gloryHole"), SerializeField] private GameObject hole;
    
    private const float CellSpacing = 0.55f;
    private const float WallOffset = 5.0f;
    private readonly Random _random = new();
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        var mazeGenerator = new MazeGenerator(7, 7);
        var maze = mazeGenerator.GetCells();
        
        CreateHole(maze);
    }

    private void CreateHole(Cell[,] cells)
    {
        var cellRows = cells.GetLength(0);
        var cellCols = cells.GetLength(1);

        int x, z;

        do
        {
            x = _random.Next(cellRows);
            z = _random.Next(cellCols);
        } while (cells[x, z].Top && cells[x, z].Bottom && cells[x, z].Left && cells[x, z].Right);

        var pos = new Vector3(x * CellSpacing, 0.1f, z * CellSpacing - WallOffset);
        Instantiate(hole, pos, Quaternion.identity, transform);
    }
}
