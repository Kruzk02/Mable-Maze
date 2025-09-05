
using System;
using System.Collections.Generic;

public class MazeGenerator
{
    private readonly int _rows, _cols;
    private readonly int _goalX, _goalZ;
    private readonly Random _random = new();
    
    private readonly int[] _directionX = { -1, 0, 1, 0 };
    private readonly int[] _directionZ = { 0, 1, 0, -1 };

    private readonly Cell[,] _cell;
    
    public MazeGenerator(int rows, int cols)
    {
        _rows = rows;
        _cols = cols;
        
        _cell = new Cell[rows, cols];

        for (var x = 0; x < rows; x++)
        {
            for (var z = 0; z < cols; z++)
            {
                _cell[x, z] = new Cell(x, z);
            }
        }
        
        Generate(_random.Next(_rows), _random.Next(_cols));
    }

    private void Generate(int x, int z)
    {
        var current = _cell[x, z];
        current.Visited = true;

        var dirs = new List<int>{0, 1, 2, 3};
        Shuffle(dirs);

        foreach (var dir in dirs)
        {
            var newX = x + _directionX[dir];
            var newZ = z + _directionZ[dir];
            
            if (IsValid(newX, newZ))
            {
                RemoveWall(current, _cell[newX, newZ]);
                Generate(newX, newZ);
            }
        }
    }

    private bool IsValid(int x, int z)
    {
        return x >= 0 && z >= 0 && x < _rows && z < _cols && !_cell[x,z].Visited;
    }

    private static void RemoveWall(Cell a, Cell b)
    {
        if (b.X == a.X - 1) { a.Top = false; b.Bottom = false; }
        if (b.X == a.X + 1) { a.Bottom = false; b.Top = false; }
        if (b.Z == a.Z - 1) { a.Left = false; b.Right = false; }
        if (b.Z == a.Z + 1) { a.Right = false; b.Left = false; }
    }

    private void Shuffle(List<int> list)
    {
        for (var i = list.Count - 1; i > 0; i--)
        {
            var j = _random.Next(i + 1);
            (list[i], list[j]) = (list[j], list[i]);
        }
    }

    public Cell[,] GetCells() => _cell;
}