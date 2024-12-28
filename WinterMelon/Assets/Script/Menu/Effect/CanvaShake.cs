using UnityEngine;

public class CanvaShake : MonoBehaviour
{
    public RectTransform canvasRectTransform; // The RectTransform of the entire Canvas
    public float duration = 1.0f;             // Total duration of the shake
    public float strength = 5.0f;             // Strength of the shake

    private Vector3 originalPosition;         // The original position of the Canvas
    private float elapsedTime;

    void Awake()
    {
        if (canvasRectTransform == null)
        {
            canvasRectTransform = GetComponent<RectTransform>();
        }
        originalPosition = canvasRectTransform.localPosition;
    }
    private void Start()
    {
        StartShake();
    }
    public void StartShake()
    {
        elapsedTime = duration;
    }

    void Update()
    {
        if (elapsedTime > 0)
        {
            // Reduce elapsed time
            elapsedTime -= Time.deltaTime;

            // Generate random shake offsets
            float offsetX = Random.Range(-1f, 1f) * strength;
            float offsetY = Random.Range(-1f, 1f) * strength;

            // Apply the offset to the Canvas's RectTransform
            canvasRectTransform.localPosition = originalPosition + new Vector3(offsetX, offsetY, 0);
        }
        else
        {
            // Reset the Canvas's position to its original position
            canvasRectTransform.localPosition = originalPosition;
        }
    }
}
