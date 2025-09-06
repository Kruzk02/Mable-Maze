
using UnityEngine;
using UnityEngine.Serialization;

public class MazeScript : MonoBehaviour
{

    [FormerlySerializedAs("_wallPrefab"), SerializeReference] private GameObject wallPrefab;

    private const float WallOffset = 5.0f;
    private const float CellSpacing = 0.55f;
    private const float HalfCell = 0.5f;
    private const int MazeBoundaryLimit = 5;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var mazeGenerator = new MazeGenerator(10, 10);
        var maze = mazeGenerator.GetCells();
        DrawMaze(maze);
    }

    private void DrawMaze(Cell[,] cells)
    {
        var cellRows = cells.GetLength(0);
        var cellCols = cells.GetLength(1);

        for (var x = 0; x < cellRows; x++)
        {
            for (var z = 0; z < cellCols; z++)
            {
                var cell = cells[x, z];
             
                var pos = new Vector3(x * CellSpacing, 0, z * CellSpacing);
                
                if (cell.Top) CreateWall(pos + new Vector3(x - WallOffset, HalfCell, z - HalfCell - WallOffset), Quaternion.identity);
                if (cell.Bottom) CreateWall(pos + new Vector3(x - WallOffset, HalfCell, z + HalfCell - WallOffset), Quaternion.identity);
                if (cell.Left) CreateWall(pos + new Vector3(x - HalfCell - WallOffset, HalfCell, z - WallOffset), Quaternion.Euler(0, 90, 0));
                if (cell.Right) CreateWall(pos + new Vector3(x + HalfCell - WallOffset, HalfCell, z - WallOffset), Quaternion.Euler(0, 90, 0));
            }
        }
    }

    void CreateWall(Vector3 position, Quaternion rotation)
    {
        var wall = Instantiate(wallPrefab, position, rotation, transform);
        if (
            wall.transform.position.x <= -MazeBoundaryLimit || wall.transform.position.x >= MazeBoundaryLimit || 
            wall.transform.position.z <= -MazeBoundaryLimit || wall.transform.position.z >= MazeBoundaryLimit) Destroy(wall);   
    }


    // Update is called once per frame
    void Update()
    {

    }
}
