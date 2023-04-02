using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public GameObject car;
    public Rigidbody carRB;
    public AudioSource flameDeath;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Car")
        {
            car.transform.position = new Vector3(-38.2299995f, 0.388999999f, 0);
            carRB = car.GetComponent<Rigidbody>();

            carRB.velocity = Vector3.zero;
            carRB.rotation = Quaternion.identity;
            flameDeath.Play();
        }
        

    }
}
