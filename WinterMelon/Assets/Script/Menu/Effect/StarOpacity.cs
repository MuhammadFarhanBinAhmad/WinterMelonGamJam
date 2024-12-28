using UnityEngine;
using UnityEngine.UI;

public class StarOpacity : MonoBehaviour
{
    public Image targetImage; // The Image component to modify
    public float lerpSpeed = 1f; // Speed of the opacity transition

    private float targetAlpha; // The target alpha value
    private float currentAlpha; // The current alpha value

    private void Start()
    {
        // Initialize the current alpha with the image's initial alpha
        currentAlpha = targetImage.color.a;

        // Set the first target alpha to a random value
        targetAlpha = Random.Range(0f, 1f);
    }

    private void Update()
    {
        // Smoothly transition the current alpha to the target alpha
        currentAlpha = Mathf.Lerp(currentAlpha, targetAlpha, Time.deltaTime * lerpSpeed);

        // Apply the updated alpha to the image's color
        Color imageColor = targetImage.color;
        imageColor.a = currentAlpha;
        targetImage.color = imageColor;

        // If close enough to the target alpha, pick a new random target alpha
        if (Mathf.Abs(currentAlpha - targetAlpha) < 0.01f)
        {
            targetAlpha = Random.Range(0f, 1f);
        }
    }
}
