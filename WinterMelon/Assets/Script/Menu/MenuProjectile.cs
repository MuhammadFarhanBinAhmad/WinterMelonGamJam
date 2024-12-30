using UnityEngine;

public class MenuProjectile : MonoBehaviour
{
    RectTransform movingImage; // The image that moves
    public RectTransform targetImage; // The target image to move toward
    public float moveSpeed; // Speed of movement in units per second

    private void Start()
    {
        movingImage = GetComponent<RectTransform>();
    }

    private void Update()
    {
        // Optional: Stop moving if it's close enough to the target
        if (Vector3.Distance(movingImage.position, targetImage.position) < 0.1f)
        {
            movingImage.gameObject.SetActive(false);
            GameObject bf = GameObject.Find("Flash");
            bf.GetComponent<AudioSource>().Play();
            print("hit");
        }
    }
}
