
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class MazeScript : MonoBehaviour
{

    public GameObject wallPrefab;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var mazeGenerator = new MazeGenerator(7, 7);
        var maze = mazeGenerator.GetCells();
        DrawMaze(maze);
    }

    private void DrawMaze(Cell[,] cells)
    {
        var rows = cells.GetLength(0);
        var cols = cells.GetLength(1);

        for (var x = 0; x < rows; x++)
        {
            for (var z = 0; z < cols; z++)
            {
                var cell = cells[x, z];
             
                var pos = new Vector3(x * 0.55f, 0, z * 0.55f);
                
                if (cell.Top) CreateWall( pos + new Vector3(x - 5.0f, 0.5f, z - 0.5f - 5.0f), Quaternion.identity);
                if (cell.Bottom) CreateWall(pos + new Vector3(x - 5.0f, 0.5f, z + 0.5f - 5.0f), Quaternion.identity);
                if (cell.Left) CreateWall(pos + new Vector3(x - 0.5f - 5.0f, 0.5f, z - 5.0f), Quaternion.Euler(0, 90, 0));
                if (cell.Right) CreateWall(pos + new Vector3(x + 0.5f - 5.0f, 0.5f, z - 5.0f), Quaternion.Euler(0, 90, 0));
            }
        }
    }

    void CreateWall(Vector3 position, Quaternion rotation)
    {
        var wall = Instantiate(wallPrefab, position, rotation, transform);
        if (wall.transform.position.x < -5 ||  wall.transform.position.x > 5 || wall.transform.position.z < -5 || wall.transform.position.z > 5) Destroy(wall);   
    }


    // Update is called once per frame
    void Update()
    {

    }
}
