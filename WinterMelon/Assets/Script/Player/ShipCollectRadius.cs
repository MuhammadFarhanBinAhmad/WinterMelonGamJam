using UnityEngine;
using System.Collections;
using System;


public enum POLARITY
{
    ATTRACT,
    REPEL
}


public class ShipCollectRadius : MonoBehaviour
{
    public POLARITY ship_Polarity;
    public int ship_PolarityStrength;

    [HideInInspector]
    public CircleCollider2D ship_PolarityCollider;

    public Transform m_Circle;
    public GameObject ship_Attract;
    public GameObject ship_Repel;

    private void Start()
    {
        ship_PolarityCollider = GetComponent<CircleCollider2D>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ship_Polarity++;
            if ((int)ship_Polarity >= Enum.GetValues(typeof(POLARITY)).Length)
            {
                ship_Polarity = POLARITY.ATTRACT;
                ship_Attract.SetActive(true);
                ship_Repel.SetActive(false);
            }
            else
            {
                ship_Attract.SetActive(false);
                ship_Repel.SetActive(true);
            }
        }
    }

}
