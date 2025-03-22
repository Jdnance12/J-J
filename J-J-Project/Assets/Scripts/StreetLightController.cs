using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StreetLightController : MonoBehaviour
{
    public Light streetLight;
    public Light pointLight;
    public Light spotLight;
    public float detectionRadius = 5f;
    public LayerMask detectionLayer;

    public GameObject enemy;
    public float normalEnemySpeed = 3f;
    public float alertedEnemySpeed = 6f;

    private EnemyMovement enemyMovement;

    private void Start()
    {
        if (streetLight != null)
        {
            streetLight.enabled = false;
        }

        if (enemy != null)
        {
            enemyMovement = enemy.GetComponent<EnemyMovement>();
        }

        pointLight.enabled = false;
        spotLight.enabled = false;
    }


    private void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius, detectionLayer);
        bool isDetected = hitColliders.Length > 0;

        bool playerNearby = false;
        bool enemyNearby = false;

        pointLight.enabled = isDetected;
        spotLight.enabled = isDetected;

        foreach (Collider collider in hitColliders)
        {
            if (collider.CompareTag("Player"))
            {
                playerNearby = true;
            } 
            if (collider.CompareTag("Enemy"))
            {
                enemyNearby = true;
            }

        }

        streetLight.enabled = playerNearby || enemyNearby;

        if(enemyMovement != null)
        {
            enemyMovement.speed = playerNearby ? alertedEnemySpeed : normalEnemySpeed;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
