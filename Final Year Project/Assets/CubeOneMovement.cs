using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeOneMovement : MonoBehaviour
{
    public bool IsColliding;
    private bool isGrowing;
    private bool Towards = true;
    public Vector3 origin = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        IsColliding = false;
        isGrowing = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsColliding)
        {
            Debug.Log("Currently colliding");
        }
        RotationFunction();
        MovementFunction();
        ScaleFunction();
    }

    void RotationFunction()
    {
        float x = Random.Range(0f, 30.0f);
        float y = Random.Range(0f, 30.0f);
        float z = Random.Range(0f, 30.0f);

        Vector3 eulerAngles = new Vector3(x, y, z) * Time.deltaTime;

        transform.Rotate(eulerAngles, Space.Self);
        transform.RotateAround(origin, Vector3.up, 30 * Time.deltaTime);
    }

    void MovementFunction()
    {
        if(Vector3.Distance(transform.position, origin) < 0.5f)
        {
            Towards = false;
        }
        if (Vector3.Distance(transform.position, origin) > 2.5f)
        {
            Towards = true;
        }
        if (Towards)
        {
            transform.position = Vector3.MoveTowards(transform.position, origin, 0.5f * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, origin, -0.5f * Time.deltaTime);
        }
    }

    void ScaleFunction()
    {
        //float scaleX = Random.Range(0.1f, 1f);
        //float scaleY = Random.Range(0.1f, 1f);
        //float scaleZ = Random.Range(0.1f, 1f);

        //Vector3 scaleChange = new Vector3(scaleX, scaleY, scaleZ);
        Vector3 scaleChange = new Vector3(0.2f, 0.2f, 0.2f); 

        if (transform.localScale.x > 2.5f || transform.localScale.x < 0.1f)
        {
            isGrowing = !isGrowing;
        }

        if (isGrowing)
        {
            transform.localScale += scaleChange * Time.deltaTime;
        }
        else
        {
            transform.localScale += -scaleChange * Time.deltaTime;
        }
        
    }


    void OnTriggerEnter(Collider otherCollider)
    {
        IsColliding = true;
    }
    void OnTriggerExit(Collider otherCollider)
    {
        IsColliding = false;
    }
}
