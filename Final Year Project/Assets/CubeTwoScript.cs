using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTwoScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotationFunction();
    }

    void RotationFunction()
    {
        float x = Random.Range(0f, 30.0f);
        float y = Random.Range(0f, 30.0f);
        float z = Random.Range(0f, 30.0f);

        Vector3 eulerAngles = new Vector3(x, y, z) * Time.deltaTime;

        transform.Rotate(eulerAngles, Space.Self);
    }
}
