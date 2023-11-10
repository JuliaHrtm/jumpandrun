using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    public Text scoretext;
    
    public void Setup(int score) {
        gameObject.SetActive(true);
        scoretext.text = score.ToString() + "Points";
    }
}
