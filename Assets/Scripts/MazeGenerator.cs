
using System;
using System.Collections.Generic;
using NUnit.Framework;

public class MazeGenerator
{
    private readonly int _rows, _cols;
    private int[,] _grid;
    private readonly bool[,] _visited;
    private readonly int _goalX, _goalZ;
    private readonly Random _random = new();
    
    private readonly int[] _directionX = { -1, 0, 1, 0 };
    private readonly int[] _directionZ = { 0, 1, 0, -1 };
    
    public MazeGenerator(int rows, int cols)
    {
        _rows = rows;
        _cols = cols;
        
        _visited = new  bool[_rows, _cols];
        _grid = new int[_rows, _cols];
        Generate(_random.Next(_rows), _random.Next(_cols));
    }

    private void Generate(int x, int z)
    {
        _visited[x, z] = true;

        var dirs = new List<int>{0, 1, 2, 3};
        Shuffle(dirs);

        foreach (var dir in dirs)
        {
            var newX = x + _directionX[dir];
            var newZ = z + _directionZ[dir];

            if (!IsValid(newX, newZ)) continue;
            
            _visited[newX, newZ] = true;
            Generate(newX, newZ);
        }
    }

    private bool IsValid(int x, int z)
    {
        return x >= 0 && z >= 0 && x < _rows && z < _cols && !_visited[x,z];
    }

    private void Shuffle(List<int> list)
    {
        for (var i = list.Count - 1; i > 0; i--)
        {
            var j = _random.Next(i + 1);
            (list[i], list[j]) = (list[j], list[i]);
        }
    }
}