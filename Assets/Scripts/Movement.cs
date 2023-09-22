using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour {
    public float baseJumpForce = 10f; // Basis Sprungstärke
    public float baseMoveSpeed = 10f; // Basis Bewegungsgeschwindigkeit
    public float maxJumpTime = 0.5f; // Maximale Sprungzeit
    public float fallAcceleration = 3f; // Fallbeschleunigung
    public float maxFallVelocity = 10f; // Maximale Fallgeschwindigkeit

    private float _fallVelocity; // Aktuelle Fallgeschwindigkeit
    private bool _onGround; // Bodenkontakt
    private float _jumpTime; // Sprungzeitpunkt

    private Rigidbody2D _rigidbody2D; // Physikkörper des Spielers

    // Initialisierung
    private void Start() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Fixed Update nach festem Zeitintervall aufgerufen
    private void Update() {
        // Vorwärtsbewegung
        _rigidbody2D.velocity = new Vector2(baseMoveSpeed, _rigidbody2D.velocity.y);

        Jump();
        
        if (_rigidbody2D.velocity.y < 0) {
            // Standardfallgeschwindigkeit erhöhen
            _rigidbody2D.velocity += Vector2.up * (Physics.gravity.y * _fallVelocity * Time.deltaTime);
            if (_rigidbody2D.velocity.y > maxFallVelocity) {
                //Fallgeschwindigkeit weiter beschleunigen, wenn noch nicht maximal
                StartCoroutine(Fall());
            }
        }
    }

    private void Jump() {
        // Überprüfe, ob Spieler auf Boden ist und auf Bildschirm getippt wird
        // "Fire1" = Linksklick oder Bildschirmtippen
        if (_onGround && Input.GetButtonDown("Fire1")) {
            // Sprungzeitpunkt speichern
            _jumpTime = Time.time;

            // Kraft nach oben, um Spieler springen zu lassen
            _rigidbody2D.AddForce(Vector2.up * baseJumpForce, ForceMode2D.Impulse);
            // Spieler jetzt in Luft
            _onGround = false;
            return;
        }

        if (!_onGround && (Input.GetButtonUp("Fire1") || Time.time - _jumpTime >= maxJumpTime)) {
            // Sprungzeit zurücksetzen
            _jumpTime = 0;
        }
    }

    // Aufgerufen, wenn Objekt mit anderem Collider kollidiert
    private void OnCollisionEnter2D(Collision2D collision) {
        // Überprüfe, ob Spieler mit dem Boden kollidiert
        if (collision.gameObject.CompareTag("Ground")) {
            // Spieler wieder auf dem Boden
            _onGround = true;
        }
    }

    private IEnumerator Fall() {
        yield return new WaitForSeconds(0.1f);
        // Alle 0.1 Sekunden beschleunigen
        _fallVelocity += fallAcceleration;
    }
}