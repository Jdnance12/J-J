using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyAI2 : MonoBehaviour
{

    public float roamRadius = 10f;
    public float detectionRange = 8f;
    public float investigationTime = 3f;
    public Transform player;
    public GameObject alertIcon;

    private NavMeshAgent agent;
    private Vector3 startPosition;
    private bool isInvestigating = false;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        startPosition = transform.position;
        alertIcon.SetActive(false);
        StartCoroutine(Roam());

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < detectionRange)
        {
            AlertAndInvestigate();
        }
    }

    void AlertAndInvestigate()
    {
        StopAllCoroutines();
        alertIcon.SetActive(true);
        isInvestigating=true;
        agent.SetDestination(player.position);
        StartCoroutine(Investigate());
    }

    IEnumerator Investigate()
    {
        yield return new WaitForSeconds(investigationTime);
        alertIcon.SetActive(false);
        isInvestigating = false;
        StartCoroutine(Roam());

    }

    IEnumerator Roam()
    {
        while (!isInvestigating)
        {
            Vector3 randomPoint = startPosition + new Vector3(Random.Range(-roamRadius, roamRadius), 0, Random.Range(-roamRadius, roamRadius));
            NavMeshHit hit;
            if(NavMesh.SamplePosition(randomPoint, out hit, roamRadius, NavMesh.AllAreas))
            {
                agent.SetDestination(hit.position);
            }
        }

        yield return new WaitForSeconds(Random.Range(3f, 7f));
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Game Over! Player spotted!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
