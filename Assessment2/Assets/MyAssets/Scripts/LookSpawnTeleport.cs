using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookSpawnTeleport : MonoBehaviour
{

    private Color saveColor;
    private GameObject currentTarget;

    // Update is called once per frame
    void Update()
    {
        Transform camera = Camera.main.transform;
        Ray ray;
        RaycastHit hit;
        GameObject hitTarget;
        ray = new Ray(camera.position, camera.rotation * Vector3.forward);

        if(Physics.Raycast(ray, out hit, 10f, LayerMask.GetMask("TeleportSpawn")))
        {
            hitTarget = hit.collider.gameObject;
            if(hitTarget != currentTarget)
            {
                Unhighlight();
                Highlight(hitTarget);
            }
            if(Input.GetButtonDown("Fire1"))
            {
                transform.position = new Vector3(hitTarget.transform.position.x, 1.6f, hitTarget.transform.position.z);
            }
        }
        else if (currentTarget != null)
        {
            Unhighlight();
        }
    }


    private void Highlight(GameObject target)
    {
        Material material = target.GetComponent<Renderer>().material;
        saveColor = material.color;
        Color hiColor = material.color;
        hiColor.a = 0.8f; // more opaque
        material.color = hiColor;
        currentTarget = target;
    }
    private void Unhighlight()
    {
        if (currentTarget != null)
        {
            Material material = currentTarget.GetComponent<Renderer>().material;
            material.color = saveColor;
            currentTarget = null;
        }
    }


}


