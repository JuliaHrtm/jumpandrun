using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {
    private Rigidbody2D _rigidbody2D;
    
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
    }
    
}
