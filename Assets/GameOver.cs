using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    public Text scoretext;
    
    public void setup(int score) {
        gameObject.SetActive(true);
        scoretext.text = score.ToString() + "Points";
    }
}
