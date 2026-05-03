using GamePlay.Spawning;
using UnityEngine;

namespace GamePlay.Maze
{
    public class MazeController : MonoBehaviour
    {
        [SerializeField] private HoleSpawner holeSpawner;
        [SerializeField] private WallSpawner wallSpawner;
        [SerializeField] private BallSpawner ballSpawner;

        public void Generate(int rows, int cols)
        {
            var mazeGenerator = new MazeGenerator(rows, cols);
            var cells = mazeGenerator.GetCells();

            holeSpawner.Initialize(cells);
            wallSpawner.Initialize(cells);
        }

        public void Respawn(int rows, int cols)
        {
            var mazeGenerator = new MazeGenerator(rows, cols);
            var cells = mazeGenerator.GetCells();

            holeSpawner.Respawn(cells);
            wallSpawner.Respawn(cells);
            ballSpawner.Respawn();
        }
    }
}