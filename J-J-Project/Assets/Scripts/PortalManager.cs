using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public Transform APos;
    public Transform BPos;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Portal 1"))
        {
            CharacterController cc = GetComponent<CharacterController>();

            cc.enabled = false;
            transform.position = BPos.transform.position;
            transform.rotation = new Quaternion(transform.rotation.x, BPos.rotation.y, transform.rotation.z, transform.rotation.w);

            cc.enabled = true;
        }

        if (other.CompareTag("Portal 2"))
        {
            CharacterController cc = GetComponent<CharacterController>();

            cc.enabled = false;
            transform.position = BPos.transform.position;
            transform.rotation = new Quaternion(transform.rotation.x, APos.rotation.y, transform.rotation.z, transform.rotation.w);

            cc.enabled = true;

        }
    }
}
