using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10f;
    public float jumpHeight = 20f;
    public float baseFallMultiplier = 5f;
    public float terminalVelocity = 5f;
    public float fallAcceleration = 3f;

    private Rigidbody2D _rb;
    private float _fallMultiplier;

    // Start is called before the first frame update
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _fallMultiplier = baseFallMultiplier;
    }

    // Update is called once per frame
    private void Update()
    {
        _rb.velocity = new Vector2(speed, _rb.velocity.y);
        Jump();

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = new Vector2(0, 0);
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _rb.velocity = new Vector2(_rb.velocity.x, 0);
            _rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
        }
        else if (_rb.velocity.y < 0)
        {
            _rb.velocity += Vector2.up * (Physics.gravity.y * _fallMultiplier * Time.deltaTime);
            if (_rb.velocity.y > terminalVelocity)
            {
                StartCoroutine(FallFaster());
            }
        }
        else if (_rb.velocity.y >= 0)
        {
            _fallMultiplier = baseFallMultiplier;
        }
    }

    IEnumerator FallFaster()
    {
        yield return new WaitForSeconds(0.1f);
        _fallMultiplier += fallAcceleration;
    }
}