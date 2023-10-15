using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Script : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void PlayMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
