using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float loadDelay;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSound;
    bool hasCrashed = false;

    CircleCollider2D playerHead;

    void Start()
    {
        playerHead = GetComponent<CircleCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") && playerHead.IsTouching(other.collider) && !hasCrashed)
        {
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSound);
            Invoke("ReloadScene", loadDelay);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
