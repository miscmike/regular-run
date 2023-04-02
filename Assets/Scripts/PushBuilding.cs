using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBuilding : MonoBehaviour
{
    // Start is called before the first frame update
    public float pushForce = 1f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.left * pushForce);
        }
    }
}
