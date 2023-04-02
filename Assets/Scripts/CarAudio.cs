using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCarSound : MonoBehaviour
    {
        AudioSource carEngine;
        public float minPitch = 1f;
        public float maxPitch = 10f;
        private float pitchFromCar;

        // Start is called before the first frame update
        void Start()
        {
        carEngine = GetComponent<AudioSource>();
        carEngine.pitch = minPitch;
        }

    // Update is called once per frame
    void Update()
    {
        carEngine.pitch = 1+CarController.cc.carCurrentSpeed/30;


       
    }
    }
