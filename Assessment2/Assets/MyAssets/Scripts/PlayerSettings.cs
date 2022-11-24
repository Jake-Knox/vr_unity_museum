using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSettings : MonoBehaviour
{

    public Canvas menuCanvas;
    private bool inMenuArea = true;

    public GameObject plane;    

    public Text motionText1;
    public Text motionText2;
    public Text motionText3;
    public GameObject fixedTeleportSpheres;
    public GameObject lookTeleportSphere;

    public Text songText1;
    public Text songText2;
    public Text songText3;

    public AudioClip song1;
    public AudioClip song2;
    public AudioClip song3;

    public static bool helpBubble = false;
    public Material bubbleMaterial;


    // Start is called before the first frame update
    void Start()
    {
        // set starting options - look teleport

        //this.GetComponent<MyMotion2>().enabled = true;
        this.GetComponent<LookTeleport>().enabled = true;
        //this.GetComponent<LookSpawnTeleport>().enabled = true;

        //motionText1.color = Color.green;
        motionText2.color = Color.green;
        //motionText3.color = Color.green;

        songText1.color = Color.green;

        helpBubble = false;
        bubbleMaterial.SetColor("_Color", Color.gray);

    }

    // Update is called once per frame
    void Update()
    {        
        if(inMenuArea)
        {
            Transform camera = Camera.main.transform;
            Ray ray;
            RaycastHit hit;
            if (Input.GetButtonUp("Fire1"))
            {
                
                ray = new Ray(camera.position, camera.rotation * Vector3.forward);

                // changed from can't look at ground to has to look at ground
                if (Physics.Raycast(ray, out hit) && (hit.collider.gameObject.name == "LookMoveBody"))
                {
                    //Debug.Log("Clicked on Look Move.");
                    this.GetComponent<MyMotion2>().enabled = true;
                    this.GetComponent<LookTeleport>().enabled = false;
                    this.GetComponent<LookSpawnTeleport>().enabled = false;

                    motionText1.color = Color.green;
                    motionText2.color = Color.white;
                    motionText3.color = Color.white;

                    fixedTeleportSpheres.SetActive(false);
                    if(lookTeleportSphere.activeInHierarchy==true)
                    {
                        lookTeleportSphere.SetActive(false);
                    }

                }
                else if (Physics.Raycast(ray, out hit) && (hit.collider.gameObject.name == "LookTeleportBody"))
                {
                    //Debug.Log("Clicked on Look Teleport.");
                    this.GetComponent<MyMotion2>().enabled = false;
                    this.GetComponent<LookTeleport>().enabled = true;
                    this.GetComponent<LookSpawnTeleport>().enabled = false;

                    motionText1.color = Color.white;
                    motionText2.color = Color.green;
                    motionText3.color = Color.white;

                    fixedTeleportSpheres.SetActive(false);

                }
                else if (Physics.Raycast(ray, out hit) && (hit.collider.gameObject.name == "FixedTeleportBody"))
                {
                    //Debug.Log("Clicked on Fixed Teleport.");
                    this.GetComponent<MyMotion2>().enabled = false;
                    this.GetComponent<LookTeleport>().enabled = false;
                    this.GetComponent<LookSpawnTeleport>().enabled = true;

                    motionText1.color = Color.white;
                    motionText2.color = Color.white;
                    motionText3.color = Color.green;

                    fixedTeleportSpheres.SetActive(true);
                    if (lookTeleportSphere.activeInHierarchy == true)
                    {
                        lookTeleportSphere.SetActive(false);
                    }

                }
                else if (Physics.Raycast(ray, out hit) && (hit.collider.gameObject.name == "Song1Body"))
                {
                    //Debug.Log("Clicked on Song 1.");

                    songText1.color = Color.green;
                    songText2.color = Color.white;
                    songText3.color = Color.white;

                    plane.GetComponent<AudioSource>().clip = song1;
                    plane.GetComponent<AudioSource>().Play();
                }
                else if (Physics.Raycast(ray, out hit) && (hit.collider.gameObject.name == "Song2Body"))
                {
                    //Debug.Log("Clicked on Song 2.");
                    songText1.color = Color.white;
                    songText2.color = Color.green;
                    songText3.color = Color.white;

                    plane.GetComponent<AudioSource>().clip = song2;
                    plane.GetComponent<AudioSource>().Play();
                }
                else if (Physics.Raycast(ray, out hit) && (hit.collider.gameObject.name == "Song3Body"))
                {
                    //Debug.Log("Clicked on Song 3.");
                    songText1.color = Color.white;
                    songText2.color = Color.white;
                    songText3.color = Color.green;

                    plane.GetComponent<AudioSource>().clip = song3;
                    plane.GetComponent<AudioSource>().Play();

                }
                else if (Physics.Raycast(ray, out hit) && (hit.collider.gameObject.name == "BubbleToggle"))
                {
                    //Debug.Log("Clicked on Bubble Toggle.");
                    if(helpBubble)
                    {
                        helpBubble = false;
                        //change colour - grey
                        bubbleMaterial.SetColor("_Color",Color.gray);
                    }
                    else
                    {
                        helpBubble = true;
                        //change colour - green
                        bubbleMaterial.SetColor("_Color", Color.green);
                    }
                }
                else if (Physics.Raycast(ray, out hit))
                {
                   //Debug.Log("Something being hit.");
                }
                else
                {
                    //Debug.Log("Ray miss.");
                }

            }            
        }     
    }

     void OnTriggerEnter(Collider col)
    {        
        if(col.gameObject.tag == "Menu")
        {
            inMenuArea = true;
            //Debug.Log("Walked into menu.");           
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Menu")
        {
            inMenuArea = false;
            //Debug.Log("Walked out of menu.");           
        }
    }
}
