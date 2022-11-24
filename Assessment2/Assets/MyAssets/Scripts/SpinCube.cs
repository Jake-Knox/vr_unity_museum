using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinCube : MonoBehaviour
{

    public float speed = 500f;
    bool rotateOn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rotateOn)
        {
            transform.Rotate(Vector3.up, speed * Time.deltaTime);
        }
    }    
    public void spinCubeOn()
    {
        rotateOn = true;
    }
    public void spinCubeOff()
    {
        rotateOn = false;
    }
}
