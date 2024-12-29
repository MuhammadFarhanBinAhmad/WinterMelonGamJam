using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ShipMovementControl : MonoBehaviour
{

    public int ship_ThrustForce;
    public int ship_RotationSpeed;
    public int ship_MaxSpeed;

    Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Rotate the ship
        RotateShip();
    }

    private void FixedUpdate()
    {
        // Apply thrust force
        ApplyThrust();
        // Limit maximum velocity
        LimitVelocity();
    }

    private void RotateShip()
    {
        // Rotate the ship using horizontal input
        float rotationInput = -Input.GetAxis("Horizontal"); // Invert for intuitive control
        float rotationAmount = rotationInput * ship_RotationSpeed * Time.deltaTime;
        transform.Rotate(0, 0, rotationAmount);
    }

    private void ApplyThrust()
    {
        Vector2 force = Input.GetAxis("Vertical") * transform.up * ship_ThrustForce;
        _rb.AddForce(force);
    }

    private void LimitVelocity()
    {
        // Clamp the velocity to the maximum speed
        if (_rb.linearVelocity.magnitude > ship_MaxSpeed)
        {
            _rb.linearVelocity = _rb.linearVelocity.normalized * ship_MaxSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Explosion>() != null)
        {
            gameObject.SetActive(false);
        }
    }
}