using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] List <GameObject> cubes;

    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        CubeRotation();
    }

    private void CubeRotation()
    {
        foreach (var item in cubes)
        {
            float randX = Random.Range(0.01f, 0.2f);
            float randY = Random.Range(0.01f, 0.2f);
            float randZ = Random.Range(0.01f, 0.2f);
            item.transform.Rotate(new Vector3(randX, randY, randZ));
        } 
    }
}
