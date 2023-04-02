using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Task : MonoBehaviour
{
    public GameObject success;
    private bool hasWon = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasWon)
        {
            hasWon = !hasWon;
            success.SetActive(true);
        }
        

    }
}
