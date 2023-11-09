using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour {
    private Rigidbody2D _rigidbody2D;

    public GameObject blackBackground;
    public AudioSource audioSource;
    public AudioClip audioClip;
    

    private void Start() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Traps")) {
            Die();
            Console.WriteLine("Funktioniert");
        }
    }

    private void Die() {
        _rigidbody2D.bodyType = RigidbodyType2D.Static;
        blackBackground.SetActive(true);
        audioSource.Stop();
        audioSource.PlayOneShot(audioClip);
        StartCoroutine(LoadDeathScreen());
    }

    private IEnumerator LoadDeathScreen() {
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(1);
    }
}