using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    [SerializeField] ParticleSystem DeathEffect;
    [SerializeField] float ReloadTime = 1f;
    [SerializeField] AudioClip crashSFX;
    bool crashed = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground" && crashed == false)
        {
            Debug.Log("Bonk");
            crashed = true;
            FindAnyObjectByType<Player>().NotMove();
            DeathEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", ReloadTime);
        }
    }
    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
