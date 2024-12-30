using UnityEngine;

// This class tries to maintain a position in front of the ship depending on the ship's velocity
public class ShipLead : MonoBehaviour
{
    [SerializeField]
    private Transform m_ship;

    private Rigidbody2D m_shipRB;
    private Vector3 m_target;

    private void Start() {
        m_shipRB = m_ship.GetComponent<Rigidbody2D>();
    }

    private void Update() {
        m_target = m_ship.position + (Vector3)m_shipRB.linearVelocity * 2f;
        transform.position = Vector3.Lerp(transform.position, m_target, Time.deltaTime);
    }
}
