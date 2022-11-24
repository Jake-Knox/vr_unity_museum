using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{

    public float masterVolume;
    public float musicVolume;

    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;
    public GameObject ground;


    // Start is called before the first frame update
    void Start()
    {
        masterVolume = 1;
        musicVolume = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateMasterVolume()
    {

        masterVolume = masterVolumeSlider.value;
        musicVolume = musicVolumeSlider.value;

        Debug.Log("Master volume is... " + masterVolume);
        Debug.Log("Music volume is... " + masterVolume * musicVolume);


        AudioSource AS = ground.GetComponent<AudioSource>();
        AS.volume = (musicVolume * masterVolume);
        // https://www.youtube.com/watch?v=x0CAZYvrzGM

    }



}
