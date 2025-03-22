using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    public float speed = 3f;
    private NavMeshAgent agent;
    private Transform player;


    // Start is called before the first frame update
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (!agent.isOnNavMesh)
        {
            Debug.LogError("Enemy is not on a NavMesh!");
        }
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    private void Update()
    {
        agent.speed = speed;
        agent.SetDestination(player.position);
    }
}
