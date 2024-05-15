using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] float ReloadTime = 1f;
    [SerializeField] ParticleSystem FinishEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        FinishEffect.Play();
        GetComponent<AudioSource>().Play();
        Invoke("ReloadScene", ReloadTime);
    }
    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
