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
        // Calculate the new position
        Vector3 newPosition = Vector3.MoveTowards(
            movingImage.position,            // Current position
            targetImage.position,            // Target position
            moveSpeed * Time.deltaTime       // Distance to move this frame
        );

        // Update the position of the moving image
        movingImage.position = newPosition;

        // Optional: Stop moving if it's close enough to the target
        if (Vector3.Distance(movingImage.position, targetImage.position) < 0.1f)
        {
            movingImage.gameObject.SetActive(false);
            targetImage.gameObject.SetActive(false);
            GameObject.Find("ButtonFlash").GetComponent<Animator>().SetTrigger("Flash");
            Debug.Log("Reached the target!");
        }
    }
}
