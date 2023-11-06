using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour {
    public void PlayGame() {
        SceneManager.LoadSceneAsync(1);
    }

    public void PlayMainMenu() {
        SceneManager.LoadSceneAsync(0);
    }
}