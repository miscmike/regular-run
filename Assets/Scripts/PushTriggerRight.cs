using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushTriggerRight : MonoBehaviour
{

    public Rigidbody tower;

    private bool standing = true;

    private float pushForce = 1500000f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Car" && standing)
        {
            tower.AddForce(Vector3.right * pushForce);
            standing = !standing;
        }
    }
}
