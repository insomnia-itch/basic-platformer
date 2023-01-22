using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Text cherriesText;
    [SerializeField] private AudioSource collectSFX;
    private int cherries = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            Destroy(collision.gameObject);
            collectSFX.Play();
            cherries++;
            cherriesText.text = "Cherries: " + cherries.ToString();
        }        
    }
}
