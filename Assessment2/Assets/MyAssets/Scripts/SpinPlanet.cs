using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPlanet : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject planet;
    public float dayLength = 10.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        planet.transform.Rotate(Vector3.up, dayLength * Time.deltaTime);


    }
}
