using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyGameOver : MonoBehaviour
{

    public string playerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over! Player spotted!");

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
