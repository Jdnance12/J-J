using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public Transform APos;
    public Transform BPos;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterController controller = other.GetComponent<CharacterController>();

            if (controller != null)
            {
                controller.enabled = false;

                if (gameObject.CompareTag("Portal 1"))
                {
                    other.transform.position = BPos.position;
                    other.transform.rotation = BPos.rotation;
                }
                else if (gameObject.CompareTag("Portal 2"))
                {
                    other.transform.position = APos.position;
                    other.transform.rotation = APos.rotation;
                }
                controller.enabled = true;
            }
        }
    }
}
