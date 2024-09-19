using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TenCubes : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject cubePrefab;
    public int numCubes = 8;
    public List<GameObject> cubeList;
    public float cubeStart = 0f;
    public float cubeSpacing = 2f;

    // Start is called before the first frame update
    void Start()
    {
        cubeList = new List<GameObject>();
        for (int i = 0; i < numCubes; i++)
        {
            for (int j = 0; j < numCubes; j++)
            {
                GameObject currentCube = Instantiate<GameObject>(cubePrefab);
                Vector3 pos = Vector3.zero;
                pos.x = cubeStart + (cubeSpacing * j);
                pos.z = cubeStart + (cubeSpacing * i);
                currentCube.transform.position = pos;
                cubeList.Add(currentCube);
            }
            
        }
    }

}
