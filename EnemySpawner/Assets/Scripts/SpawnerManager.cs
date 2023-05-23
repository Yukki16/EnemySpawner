using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnerManager : MonoBehaviour
{
    //public Vector3 size = new Vector3(1,1,1);

    public List<Vector3> areaSize = new List<Vector3>();

    public enum TypeOfSpawner
    {
        Cubic,
        Spherical,
        Custom
    }
    public Dictionary<TypeOfSpawner, Vector3> spawners = new Dictionary<TypeOfSpawner, Vector3>();

    public Vector3 GetPoint(int pointIndex)
    {
        if (pointIndex < 0 || pointIndex >= spawners.Count)
        {
            Debug.Log("SpawnerManager.cs: WARNING: pointIndex out of range: " + pointIndex + " curve length: " + spawners.Count);
            return Vector3.zero;
        }
        return transform.TransformPoint(spawners.ElementAt(pointIndex).Value);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
