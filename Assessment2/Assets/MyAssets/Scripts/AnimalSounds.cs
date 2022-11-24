using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSounds : MonoBehaviour
{
    // Start is called before the first frame update

    AudioSource animalSound;


    private void Start()
    {
        animalSound = GetComponent<AudioSource>();
    }

    public void playSound()
    {
        animalSound.Play();
    }
}
