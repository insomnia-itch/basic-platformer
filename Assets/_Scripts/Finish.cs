using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private float loadTime = 1.2f;
    private AudioSource finishSFX;
    private bool levelCompleted = false;

    void Start()
    {
        finishSFX = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !levelCompleted)
        {
            finishSFX.Play();
            // CompleteLevel();
            levelCompleted = true;
            Invoke("CompleteLevel", loadTime);
        }
    }

    private void CompleteLevel() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
