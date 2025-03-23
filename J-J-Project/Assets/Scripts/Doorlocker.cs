using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorlocker : MonoBehaviour
{

    public static bool HasKey = false;
    public Animator doorAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && HasKey)
        {
            OpenDoor();
        }
    }

    void OpenDoor()
    {
        if (doorAnimator != null)
        {
            doorAnimator.SetTrigger("Open");
        }

        else
        {
            Destroy(gameObject);
        }

    }
}
