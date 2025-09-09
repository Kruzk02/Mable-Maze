using UnityEngine;
using UnityEngine.Serialization;

public class BallSpawner : MonoBehaviour
{
    [FormerlySerializedAs("_ball"), SerializeField] private GameObject ballPrefab;

    private GameObject Ball { get; set; }
    private void Start()
    {
        Ball = Instantiate(ballPrefab, new Vector3(0, 2.0f, 0), Quaternion.identity);
    }

    public void Respawn()
    {
        Destroy(Ball);
        Ball = Instantiate(ballPrefab, new Vector3(0, 2.0f, 0), Quaternion.identity);
    }
}
