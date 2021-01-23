using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeOneMovement : MonoBehaviour
{
    public bool IsColliding;
    private bool Towards = true;
    public Vector3 origin = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        IsColliding = false;
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
    }

    void RotationFunction()
    {
        float x = Random.Range(0f, 30.0f);
        float y = Random.Range(0f, 30.0f);
        float z = Random.Range(0f, 30.0f);

        Vector3 eulerAngles = new Vector3(x, y, z) * Time.deltaTime;

        transform.Rotate(eulerAngles, Space.Self);
    }

    void MovementFunction()
    {
        if(Vector3.Distance(transform.position, origin) < 0.5f)
        {
            Towards = false;
        }
        if (Vector3.Distance(transform.position, origin) > 5f)
        {
            Towards = true;
        }
        if (Towards)
        {
            transform.position = Vector3.MoveTowards(transform.position, origin, 1 * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, origin, -1 * Time.deltaTime);
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
