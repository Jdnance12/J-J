using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    public float speed = 3f;
    private Vector3 target;
    private NavMeshAgent agent;
    private Transform player;
    private bool isPatroling = true;

    public void SetTarget(Vector3 newTarget)
    {
        target = newTarget;
        isPatroling = false;
    }

    public void ResumePatrol()
    {
        isPatroling = true;
    }


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
        //agent.SetDestination(player.position);

        if (!isPatroling)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
    }
}
