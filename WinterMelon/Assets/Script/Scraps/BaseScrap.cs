using System.Threading;
using UnityEngine;

public class BaseScrap : MonoBehaviour
{
    bool in_ShipRadius;

    Rigidbody2D _rb;
    ShipCollectRadius s_ShipCollectRadius;

    [Header("Sticking Settings")]
    public float stickRadius = 0.5f; // Distance at which the scrap sticks to the ship

    private void Start()
    {
        s_ShipCollectRadius = FindAnyObjectByType<ShipCollectRadius>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (in_ShipRadius)
        {
            Vector2 direction = (s_ShipCollectRadius.transform.position - transform.position).normalized;
            float distance = Vector2.Distance(transform.position, s_ShipCollectRadius.transform.position);

            switch (s_ShipCollectRadius.ship_Polarity)
            {
                case POLARITY.ATTRACT:
                    {
                        // Apply force to move towards the ship
                        if (distance > stickRadius)
                        {
                            Vector2 attractionForce = direction * s_ShipCollectRadius.ship_PolarityStrength;
                            _rb.AddForce(attractionForce);
                        }
                        else
                        {
                            StickToShip(); // Stick the scrap to the ship
                        }
                        break;
                    }
                case POLARITY.REPEL:
                    {
                        // Apply force to move away from the ship
                        Vector2 repulsionForce = -direction * s_ShipCollectRadius.ship_PolarityStrength;
                        _rb.AddForce(repulsionForce);
                        break;
                    }
            }
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<ShipCollectRadius>() != null)
            in_ShipRadius = true;

        if (other.GetComponent<Explosion>() != null)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<ShipCollectRadius>() != null)
            in_ShipRadius = false;
    }

    private void StickToShip()
    {
        // Disable Rigidbody2D for sticking behavior
        _rb.linearVelocity = Vector2.zero;
        _rb.bodyType = RigidbodyType2D.Kinematic;

        // Parent the scrap to the ship
        transform.SetParent(s_ShipCollectRadius.transform);

        // Optionally, disable further processing
        enabled = false;
    }
}
