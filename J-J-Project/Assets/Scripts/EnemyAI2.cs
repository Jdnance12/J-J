using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyAI2 : MonoBehaviour
{

    public float roamRadius = 10f;
    public float detectionRange = 8f;
    public float investigationTime = 3f;
    public Transform player;
    public GameObject alertIcon;

    public Image healthBarImage;
    public int maxDeaths = 1;
    private int deathCount = 0;
    private float maxHealth = 1f;
    private float healthLossPerDeath = 0.33f;



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

        StopAllCoroutines();
        StartCoroutine(Roam());

    }

    IEnumerator Roam()
    {
        while(!isInvestigating)
        {
            Vector3 randomPoint = startPosition + new Vector3(Random.Range(-roamRadius, roamRadius), 0, Random.Range(-roamRadius, roamRadius));
            NavMeshHit hit;
            if(NavMesh.SamplePosition(randomPoint, out hit, roamRadius, NavMesh.AllAreas))
            {
                agent.SetDestination(hit.position);
            }

            yield return new WaitForSeconds(Random.Range(3f, 7f));
        }

        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           Debug.Log("Enemy collided with player!");

           deathCount++;

            Debug.Log("Health loss: " + deathCount);


            if (healthBarImage != null)
            {
                float health = Mathf.Clamp01(1f - deathCount * healthLossPerDeath);
                healthBarImage.fillAmount = health;
                Debug.Log("Health bar fill amount: " + health);
            }

            Debug.Log("Player spotted! Death count: " + deathCount);

            if (deathCount >= maxDeaths)
            {
                Debug.Log("Game Over! The Player has been Killed " + maxDeaths + " times.");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            } 
            else
            {
                player.transform.position = new Vector3(0, 1, 0);
                Debug.Log("Player has been killed. Resetting position...");
            }
            
        }
    }
}
