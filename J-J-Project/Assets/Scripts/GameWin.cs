using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWin : MonoBehaviour
{
    public string nextSceneName;
    public AudioClip winSound;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (winSound != null)
            {
                AudioSource.PlayClipAtPoint(winSound, transform.position);
            }

            Debug.Log("You Win! Proceeding to the next level...");

            if (!string.IsNullOrEmpty(nextSceneName))
            {

                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
}
