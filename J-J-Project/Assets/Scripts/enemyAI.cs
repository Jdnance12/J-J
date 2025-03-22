using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAI : MonoBehaviour
{

    public Transform target;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if(agent == null)
        {
            Debug.LogError("No NavMeshAgent found!");
            return;
        }

        if (!agent.isOnNavMesh)
        {
            Debug.LogError("Agent is not on a NavMesh!");
            return;
        }
        agent.SetDestination(target.position);
    }

}
