using System.Collections;
using UnityEngine;
public class LoopBackScrap : MonoBehaviour
{
    public Transform loop_Position;

    IEnumerator Respawn(Transform scrap)
    {
        scrap.gameObject.SetActive(false);
        scrap.transform.position = new Vector3(loop_Position.position.x,
                                        scrap.transform.position.y,
                                        scrap.transform.position.z);
        yield return new WaitForSeconds(.5f);
        scrap.gameObject.SetActive(true);

        Rigidbody2D _rb;

        int thrustforce = Random.Range(5000, 7500);
        int rotforce = Random.Range(50, 100);
        _rb = scrap.gameObject.GetComponent<Rigidbody2D>();
        Vector2 force = -transform.right * thrustforce;
        _rb.AddForce(force);
        _rb.angularVelocity = rotforce;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<MenuScrap>() != null)
        {
            StartCoroutine(Respawn(other.transform));

        }

    }
}
