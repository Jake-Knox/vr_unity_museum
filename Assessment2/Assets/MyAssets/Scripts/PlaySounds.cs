using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySounds : MonoBehaviour
{

    public float timeToSelect = 2.0f;
    private float countDown;

    // Start is called before the first frame update
    void Start()
    {
        countDown = timeToSelect;
    }

    // Update is called once per frame
    void Update()
    {
        Transform camera = Camera.main.transform;
        Ray ray = new Ray(camera.position, camera.rotation *
        Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && (hit.collider.gameObject.CompareTag("Animal")))
        {
            if (countDown > 0.0f)
            {
                // on target
                countDown -= Time.deltaTime;
                // print (countDown);

            }
            else
            {
                // killed
                hit.collider.gameObject.SendMessage("playSound");
                countDown = timeToSelect;
            }
        }
        else
        {
            if (countDown != timeToSelect)
            {
                countDown = timeToSelect;
            }
        }
    }
}
        
       
    
