using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] ParticleSystem finishEffect;

    // AudioSource winSound; // you don't need AudioSource

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            finishEffect.Play();
            Debug.Log("Finish!");
            Invoke(nameof(LoadNextScene), 2f);
            GetComponent<AudioSource>().Play();
        }
    }
    void LoadNextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        int nextScene = currentScene + 1;

        if (nextScene < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            Debug.Log("No more Scenes To load");
        }
    }
}
