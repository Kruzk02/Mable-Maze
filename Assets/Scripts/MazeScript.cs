
using UnityEngine;
using UnityEngine.Serialization;

public class MazeScript : MonoBehaviour
{
    [FormerlySerializedAs("_ball"), SerializeField] private GameObject ballPrefab;
    private void Start()
    {
        Instantiate(ballPrefab, new Vector3(0, 2.0f, 0), Quaternion.identity);
    }
}
