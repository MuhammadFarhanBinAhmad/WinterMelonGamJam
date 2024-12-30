using UnityEngine;

public class MenuScrap : MonoBehaviour
{
    Rigidbody2D _rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int thrustforce = Random.Range(5000, 7500);
        int rotforce = Random.Range(50, 100);
        _rb = GetComponent<Rigidbody2D>();
        Vector2 force =  -transform.right * thrustforce;
        _rb.AddForce(force);
        _rb.angularVelocity = rotforce;
    }
}
