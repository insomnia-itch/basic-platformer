using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private AudioSource deathSFX;
    private Animator anim;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Trap"))
        {
            Die();
            rb.bodyType = RigidbodyType2D.Static;
        }
    }

    private void Die() {
        anim.SetTrigger("death");
        deathSFX.Play();
    }

    private void RestartLevel() {
        string currentLevel = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentLevel);
    }
}
