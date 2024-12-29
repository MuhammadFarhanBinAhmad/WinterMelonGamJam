using UnityEngine;

public class UIFollowShip : MonoBehaviour
{
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position = target.position;
            transform.rotation = Camera.main.transform.rotation;
        }
        
    }
}
