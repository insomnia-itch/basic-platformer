using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSFX;
    void Start()
    {
        finishSFX = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            finishSFX.Play();
            CompleteLevel();
        }
    }

    private void CompleteLevel() {
        
    }
}
