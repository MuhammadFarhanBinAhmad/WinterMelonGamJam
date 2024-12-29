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


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ship_Polarity++;
            if ((int)ship_Polarity >= Enum.GetValues(typeof(POLARITY)).Length)
            {
                ship_Polarity = POLARITY.ATTRACT;
            }
        }
    }

}
