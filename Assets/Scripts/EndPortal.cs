using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPortal : MonoBehaviour {
    public void OnTriggerEnter2D(Collider2D other) {
        SceneManager.LoadSceneAsync(0);
    }
}