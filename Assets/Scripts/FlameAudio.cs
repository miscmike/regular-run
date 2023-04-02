using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameAudio : MonoBehaviour
{
    public AudioSource flameAudio;

    // Start is called before the first frame update
    void Start()
    {
        flameAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Car") {
        
            flameAudio.Play();

            
        }
    }

}
