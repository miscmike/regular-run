using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Task : MonoBehaviour
{
    public TextMeshProUGUI success;
    private bool hasWon = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasWon)
        {
            hasWon = !hasWon;
            success.enabled = !success.enabled;
        }
        

    }
}
