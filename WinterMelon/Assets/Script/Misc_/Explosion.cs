using UnityEngine;

public class Explosion : MonoBehaviour
{

    public float camshake_Duration;
    public float camshake_Strength;

    private void Start()
    {
        FindAnyObjectByType<CameraShake>().StartShake(camshake_Duration,camshake_Strength);
    }
}
