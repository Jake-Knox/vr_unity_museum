using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTeleport : MonoBehaviour
{

    public GameObject target;
    //public GameObject ground;

    // Update is called once per frame
    void Update()
    {
        Transform camera = Camera.main.transform;
        Ray ray;
        RaycastHit hit;
        if (Input.GetButtonDown("Fire1"))
        {
            // start searching
            target.SetActive(true);
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            // done searching, teleport player
            target.SetActive(false);
            transform.position = target.transform.position + (Vector3.up * 1.6f);
        }
        else if (target.activeSelf)
        {
            ray = new Ray(camera.position, camera.rotation * Vector3.forward);

            // changed from can't look at ground to has to look at ground
            if (Physics.Raycast(ray, out hit) && (hit.collider.gameObject.tag == "Floor"))
            {
                // move target to look at poisition
                target.transform.position = hit.point;
            }
            else if (Physics.Raycast(ray, out hit) && (hit.collider.gameObject.name == "LookTeleport"))
            {
                // looking at teleporter, do nothing
                
            }
            else
            {
                // not looking at ground, reset target to player position
                target.transform.position = transform.position - (Vector3.up * 1.6f);
            }
        }
    }
}
