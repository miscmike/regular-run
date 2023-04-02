using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAudio : MonoBehaviour
{
    // Start is called before the first frame update

    public float audioPitch;
    private AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = audioPitch; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
