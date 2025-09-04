using UnityEngine;
using UnityEngine.Serialization;

public class MazeGenerator : MonoBehaviour
{
    // [FormerlySerializedAs("_wallPrefabX"), SerializeField]private GameObject wallPrefabX;
    // [FormerlySerializedAs("_wallPrefabZ"), SerializeField] private GameObject wallPrefabZ;
    [FormerlySerializedAs("_floor"), SerializeField] private GameObject floor;
    [FormerlySerializedAs("_outerWall"), SerializeField] private GameObject outerWall;

    // private readonly float _width = 10.0f;
    // private readonly float _height = 10.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var floorTransform = floor.transform;
        print(floorTransform.localScale);
        
        var outerWallTransform = outerWall.transform;
        print(outerWallTransform.GetChild(0).localPosition);
        print(outerWallTransform.GetChild(1).localPosition);
        print(outerWallTransform.GetChild(2).localPosition);
        print(outerWallTransform.GetChild(3).localPosition);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
