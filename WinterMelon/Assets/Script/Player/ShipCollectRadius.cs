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
    private SpriteRenderer m_CircleSprite;
    public Color m_CircleAttract;
    public Color m_CircleRepel;

    public GameObject ship_Attract;
    public GameObject ship_Repel;

    public SpriteRenderer m_ship;
    public Sprite m_shipAttract;
    public Sprite m_shipRepel;

    private void Start()
    {
        ship_PolarityCollider = GetComponent<CircleCollider2D>();

        m_CircleSprite = m_Circle.GetComponent<SpriteRenderer>();
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
                m_ship.sprite = m_shipAttract;
                m_CircleSprite.color = m_CircleAttract;
            }
            else
            {
                ship_Attract.SetActive(false);
                ship_Repel.SetActive(true);
                m_ship.sprite = m_shipRepel;
                m_CircleSprite.color = m_CircleRepel;
            }
        }
    }

}
