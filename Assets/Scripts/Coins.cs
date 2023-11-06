using UnityEngine;

public class Coins : MonoBehaviour {
    public int value;

    private void OnTriggerEnter2D(Collider2D other) {
        if (!other.gameObject.CompareTag("Player")) return;

        Destroy(gameObject);
        CoinCounter.Instance.IncreaseCoin(value);
    }
}