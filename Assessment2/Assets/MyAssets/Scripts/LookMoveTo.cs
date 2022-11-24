using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LookMoveTo : MonoBehaviour
{

    public GameObject ground;

    public GameObject lookBubble;
    public Transform infoBubble;
    private Text infoText;
    public GameObject player;

    public GameObject reticle;

    float distance = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        if(infoBubble != null)
        {
            infoText = infoBubble.Find("Text").GetComponent<Text>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerSettings.helpBubble == true)
        {
            //Debug.Log("help bubble on");

            Transform camera = Camera.main.transform;
            Ray ray;
            RaycastHit hit;
            GameObject hitObject;
            //Debug.DrawRay(camera.position, camera.rotation * Vector3.forward * 100);
            ray = new Ray(camera.position, camera.rotation * Vector3.forward * 0.1f);
            if (Physics.Raycast(ray, out hit))
            {
                hitObject = hit.collider.gameObject;

                //Debug.Log("Hit Something");

                //Debug.Log(hitObject.tag);

                if (hitObject.CompareTag("Exhibit"))
                {
                    if (lookBubble.activeInHierarchy == false)
                    {
                        lookBubble.SetActive(true);
                    }
                    if (reticle.activeInHierarchy == true)
                    {
                        reticle.SetActive(false);
                    }

                    switch (hitObject.name)
                    {

                        case "vase-egypt1":
                        case "vase-egypt2":
                        case "vase-egypt3":
                        case "vase-egypt4":
                        case "vase-egypt5":
                            infoText.text = "Egyptian Vase";
                            break;
                        case "vase-greek1":
                        case "vase-greek2":
                        case "vase-greek3":
                            infoText.text = "Greek Vase";
                            break;
                        case "PlatformCowboy":
                            infoText.text = "Cowboy Hat";
                            break;
                        case "PlatformHardhat":
                            infoText.text = "Hard Hat";
                            break;
                        case "PlatformPolice":
                            infoText.text = "Police Hat";
                            break;
                        case "PlatformSombrero":
                            infoText.text = "Sombrero";
                            break;
                        case "PlatformViking":
                            infoText.text = "Viking Helmet";
                            break;

                        case "SunBall":
                            infoText.text = "Sun \nMass: 333,000 Earths \nRotates in 27 Earth days";
                            break;
                        case "MercuryBall":
                            infoText.text = "Mercury \nMass: 0.055 Earths \nOrbit: 88 Earth days";
                            break;
                        case "VenusBall":
                            infoText.text = "Venus \nMass: 0.815 Earths \nOrbit: 255 Earth days";
                            break;
                        case "EarthBall":
                            infoText.text = "Earth \nMass: 1 Earths \nOrbit: 365 Earth days";
                            break;
                        case "MarsBall":
                            infoText.text = "Mars \nMass: 0.107 Earths \nOrbit: 687 Earth days";
                            break;
                        case "JupiterBall":
                            infoText.text = "Jupiter \nMass: 318 Earths \nOrbit: 12 Earth years";
                            break;
                        case "SaturnBall":
                            infoText.text = "Saturn \nMass: 95 Earths \nOrbit: 29 Earth days";
                            break;
                        case "UranusBall":
                            infoText.text = "Urans \nMass: 14 Earths \nOrbit: 84 Earth years";
                            break;
                        case "NeptuneBall":
                            infoText.text = "Neptune \nMass: 17 Earths \nOrbit: 165 Earth years";
                            break;

                        default:
                            break;
                    }

                    infoBubble.position = hit.point - Camera.main.transform.forward * distance;
                    //infoText.text = "X: " + hit.point.x.ToString("F2") + "Z: " + hit.point.z.ToString("F2");
                    infoBubble.LookAt(camera.position);
                    infoBubble.Rotate(0, 180f, 0);

                }
                else if (hitObject.CompareTag("Painting"))
                {
                    if (lookBubble.activeInHierarchy == false)
                    {
                        lookBubble.SetActive(true);
                    }
                    if (reticle.activeInHierarchy == true)
                    {
                        reticle.SetActive(false);
                    }

                    switch (hitObject.name)
                    {
                        case "Painting 1":
                            infoText.text = "The Night Watch\nRembrandt van Rijn\n1642\nBaroque, Dutch Golden Age";
                            break;
                        case "Painting 2":
                            infoText.text = "The Starry Night\nVincent van Gogh\n1889\nPost-Impressionism";
                            break;
                        case "Painting 3":
                            infoText.text = "The Japanese Footbridge\nClaude Monet\n1899\nImpressionism";
                            break;
                        case "Painting 4":
                            infoText.text = "Lighthouse Hill\nEdward Hopper\n1927\nAmerican Realism";
                            break;
                        case "Painting 5":
                            infoText.text = "The Skiff\nPieree-Auguste Renoire\n1875\nImpressionism";
                            break;
                        case "Painting 6":
                            infoText.text = "Mona Lisa\nLeonardo da Vinci\n1503-06\nRenaissance";
                            break;
                        case "Painting 7":
                            infoText.text = "Convergence\nJackson Pollock\n1952\nAbstract Expressionism";
                            break;
                        case "Painting 8":
                            infoText.text = "Guernica\nPablo Picasso\n1937\nCubism, Surrealism";
                            break;
                        case "Painting 9":
                            infoText.text = "The Absynth Drinker\nEdgar Degas\n1875-76\nImpressionism";
                            break;
                        case "Painting 10":
                            infoText.text = "A Sunday Afternoon on the Island of La Grande Jatte\nGeorges Seurat\n1884-86\nPointillism";
                            break;
                        case "Painting 11":
                            infoText.text = "The Dog\nFrancisco Goya\n1819-23\nRomanticism";
                            break;
                        case "Painting 12":
                            infoText.text = "American Gothic\nGrant Wood\n1930\nRegionalism";
                            break;
                        case "Painting 13":
                            infoText.text = "The Persistence of Memory\nSalvador Dali\n1931\nSurrealism";
                            break;
                        default:
                            break;
                    }                    
                    infoBubble.position = hit.point - Camera.main.transform.forward* distance;
                    infoBubble.LookAt(camera.position);
                    infoBubble.Rotate(0, 180f, 0);
                }
                else
                {
                    if (lookBubble.activeInHierarchy)
                    {
                        lookBubble.SetActive(false);
                    }
                    if (reticle.activeInHierarchy == false)
                    {
                        reticle.SetActive(true);
                    }
                }
            }
        }        
    }
}
