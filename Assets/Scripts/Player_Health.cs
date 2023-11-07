using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
   private Rigidbody2D _rigidbody2D;
   private void Start()
   {
      _rigidbody2D = GetComponent<Rigidbody2D>();
   }

   private void OnCollisionEnter2D(Collision2D collision)
   {
      if (collision.gameObject.CompareTag("Trap"))
      {
         Die();
      }
   }

   private void Die()
   {
      _rigidbody2D.bodyType = RigidbodyType2D.Static;
      LevelManager.instance.GameOver();
   }
}
