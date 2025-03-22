using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class StreetLightController : MonoBehaviour
{
    public Light spotLight;
    public Light spotLight2;
    public float detectionRadius = 5f;
    public LayerMask detectionLayer;
    private bool isOn = false;

    private void Start()
    {
        if(spotLight == null || spotLight2 == null)
        {
            Light[] lights = GetComponentsInChildren<Light>();
            if (lights.Length >= 2)
            {
                spotLight =lights[0];
                spotLight2 =lights[1];
            
            }
            spotLight.enabled = false;
            spotLight2.enabled = false;
        }
        else
        {
            Debug.LogError("Spotlight not assigned in Inspector!");
            return;
        }

        spotLight.enabled = false;
        spotLight2.enabled = false;
    }

    

    private void Update()
    {
        Collider[] hitcolliders = Physics.OverlapSphere(transform.position, detectionRadius, detectionLayer);
        //bool isDetected = hitcolliders.Length > 0;

        bool isAnyoneNearby = false;
        foreach (Collider collider in hitcolliders)
        {
            if (collider.CompareTag("Player") || collider.CompareTag("Enemy"))
            {
                isAnyoneNearby = true;
                break;
            }

        }

        spotLight.enabled = isAnyoneNearby;

        if (Input.GetKeyDown(KeyCode.L))
        {
            ToggleLights();
        }
    }

    void ToggleLights()
    {
        isOn = !isOn;
        spotLight.enabled = isOn;
        spotLight2.enabled= isOn;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

}
