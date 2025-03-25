using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetAlarm : MonoBehaviour
{

    public Transform street;
    public float rotationSpeed = 10f;
    public float activationRange = 10f;
    public GameObject enemy;
    public Light spotlight;
    public Light spotlight2;

    private bool isPlayerNear = false;

    private void Update()
    {
        if (isPlayerNear)
        {
            RotateStreet();

            AlertEnemy();

            ActivateSpotlights();
        } else
        {
            DeactivateSpotlights();
        }
    }

    private void ActivateSpotlights()
    {
        if (spotlight != null) 
        {
            spotlight.enabled = true;
            Debug.Log("Spotlight 1 activated.");
        } 
        if (spotlight2 != null)
        {
            spotlight2.enabled = true;
            Debug.Log("Spotlight 2 activated.");
        }
    }

    private void DeactivateSpotlights()
    {
        if (spotlight != null)
        {
            spotlight.enabled = false;
            Debug.Log("Spotlight 1 deactivated.");
        }
        if (spotlight2 != null)
        {
            spotlight2.enabled = false;
            Debug.Log("Spotlight 2 deactivated.");
        }
    }

    private void RotateStreet()
    {
        street.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    private void AlertEnemy()
    {
        if (enemy != null)
        {
            Debug.Log("Enemy is alerted to the street's movement!");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            Debug.Log("Player is near, street rotation activated.");
            Debug.Log("Player entered the area, spotlight should activate.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            Debug.Log("Player left the area, street rotation stopped.");
            Debug.Log("Player entered the area, spotlight should deactivate.");

        }
    }
}
