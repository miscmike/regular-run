using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushTrigger : MonoBehaviour
{

    public Rigidbody tower;
    public Transform pushPoint;

    private float pushForce = 10000f;

    private void OnTriggerEnter(Collider other)
    {
        tower.AddForce(Vector3.left * pushForce);
        //tower.AddForceAtPosition(Vector3.left * pushForce, pushPoint.position);
    }
}
