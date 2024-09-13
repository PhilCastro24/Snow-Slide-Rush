using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSound;


    void Start()
    {
        
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            Debug.Log("Bumped into Snow");
            Invoke(nameof(ReloadScene), 1f);
            GetComponent<AudioSource>().PlayOneShot(crashSound);
        }
    }

    void ReloadScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentScene);
    }

}
