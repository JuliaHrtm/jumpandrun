using UnityEngine;

public class Movement : MonoBehaviour {
    public float baseJumpForce = 1f; // Basis Sprungstärke
    public float baseMoveSpeed = 10f; // Basis Bewegungsgeschwindigkeit
    public float maxJumpTime = 0.3f; // Maximale Sprungzeit
    public float minJumpTime = 0.1f; // Minmale Sprungzeit
    public float fallAcceleration = 3f; // Fallbeschleunigung

    private bool _onGround; // Bodenkontakt
    private bool _isJumping; // Springt
    private float _jumpTime; // Sprungzeitpunkt

    private Rigidbody2D _rigidbody2D; // Physikkörper des Spielers

    // Initialisierung
    private void Start() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.gravityScale = fallAcceleration;
    }

    // Update jeden Frame aufgerufen (genutzt für Steuerung)
    private void Update() {
        // Vorwärtsbewegung
        _rigidbody2D.velocity = new Vector2(baseMoveSpeed, _rigidbody2D.velocity.y);

        if (Input.GetButton("Fire1") && _onGround) // Springen, wenn auf Boden und Bildschirmtipp
            StartJump();
        if (!Input.GetButton("Fire1") && _jumpTime > minJumpTime) // Aufhören zu springen, wenn Bildschirm zu lang gehalten oder losgelassen
            EndJump();
    }

    // Aufruf in festen Zeitintervallen (genutzt für Physik)
    private void FixedUpdate() {
        // Spieler springt
        if (_isJumping) {
            // Aktuelle Sprungdauer erhöhen
            _jumpTime += Time.fixedDeltaTime;
            // Maximale Sprungdauer bereits überschritten?
            if (_jumpTime < maxJumpTime) {
                // Spieler noch höher springen lassen
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, baseJumpForce);
            }
        }
    }

    private void StartJump() {
        if (!_isJumping) {
            _isJumping = true; // Spieler springt
            _jumpTime = 0f;
        }
    }

    private void EndJump() {
        if (_isJumping) {
            _isJumping = false; // Spieler springt nicht mehr
            _jumpTime = 0;
        }
    }

    // Aufgerufen, wenn Objekt mit anderem Collider kollidiert
    private void OnCollisionEnter2D(Collision2D other) {
        // Kolldiiert Spieler mit Boden?
        if (other.gameObject.CompareTag("Ground")) {
            // Spieler auf Boden
            _onGround = true;
        }
    }

    // Aufgerufen, wenn Objekt anderen Collider nicht mehr berührt
    private void OnCollisionExit2D(Collision2D other) {
        // Verlässt Spieler Boden?
        if (other.gameObject.CompareTag("Ground")) {
            // Spieler in der Luft
            _onGround = false;
        }
    }
}