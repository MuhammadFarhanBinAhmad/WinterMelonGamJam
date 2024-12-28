using UnityEngine;

public class CameraShake : MonoBehaviour
{

    RectTransform _RectTransform;

    private Vector3 originalRotation;
    private Vector3 originalPosition;

    // Camera Shake
    private float elapsedTime = 0.0f; // Tracks time since the shake started
    public float duration = 1.0f;     // Total duration of the shake
    public float strength = 1.0f;     // Shake strength/magnitude
    private float trauma;
    private int seed = 42069;         // Seed to ensure repeatable randomness
    private int seedOffset = 0;

    private float maxOffsetZ = 1.0f;

    private System.Random random;    // .NET random generator for reproducible results

    void Awake()
    {
        random = new System.Random(seed);
        _RectTransform = GetComponent<RectTransform>();
    }

    public void StartShake()
    {
        originalRotation = _RectTransform.transform.localEulerAngles;
        originalPosition = _RectTransform.transform.localPosition;
        elapsedTime = duration;
        seedOffset = 0;
    }

    public void StartShake(float shakeDuration, float shakeStrength)
    {
        originalRotation = _RectTransform.transform.localEulerAngles;
        originalPosition = _RectTransform.transform.localPosition;
        elapsedTime = shakeDuration;
        strength = shakeStrength;
        seedOffset = 0;
    }

    Vector3 UpdateShake()
    {
        // Reduce trauma over time
        trauma = Mathf.Pow(strength, 3);

        if (seedOffset > 8)
        {
            seedOffset = 0;
        }
        else
        {
            seedOffset++;
        }

        // Generate a random value for shake
        float noiseValue = (float)random.NextDouble();
        float perlinValue = Mathf.PerlinNoise(elapsedTime, noiseValue);

        // Alternate max offset direction
        if (seedOffset % 2 == 0)
        {
            maxOffsetZ *= -1;
        }

        // Calculate roll angle
        float roll = maxOffsetZ * trauma * perlinValue;

        // Decrease elapsed time and trauma
        trauma = strength * elapsedTime;
        elapsedTime -= Time.deltaTime;

        return new Vector3(0, 0, roll);
    }

    void Update()
    {
        if (elapsedTime > 0)
        {
            // Handle camera shake
            Vector3 shakeOffset = UpdateShake();

            // Apply shake to the camera
            transform.localEulerAngles = originalRotation + shakeOffset;
            transform.localPosition = originalPosition + shakeOffset;
        }
        else
        {
            // Reset to original rotation when shake is over
            transform.localEulerAngles = originalRotation;
            transform.localPosition = originalPosition;
        }
    }
}
