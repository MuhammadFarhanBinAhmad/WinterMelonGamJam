using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{

    bool ship_InStore;
    bool ship_OpenStore;

    public List<int> cost_Radius = new List<int>();
    public List<int> cost_PolarityForce = new List<int>();
    public List<int> cost_ShipThrust = new List<int>();
    public List<int> cost_ShipMaxSpeed = new List<int>();

    public List<int> value_Radius = new List<int>();
    public List<int> value_PolarityForce = new List<int>();
    public List<int> value_ThrustForce = new List<int>();
    public List<int> value_ShipMaxSpeed = new List<int>();

    ShipMovementControl _ShipMovementControl;
    ShipCollectRadius _ShipCollectRadius;
    ShipStatsManager _ShipStatsManager;

    public GameObject store_UI;
    public GameObject ship_PromptStoreText;

    private void Start()
    {
        _ShipMovementControl = FindAnyObjectByType<ShipMovementControl>();
        _ShipCollectRadius = FindAnyObjectByType<ShipCollectRadius>();
        _ShipStatsManager = FindAnyObjectByType<ShipStatsManager>();
    }
    private void Update()
    {
        if (ship_InStore)
        {
            ship_PromptStoreText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (ship_OpenStore)
                {
                    ship_OpenStore = false;

                }
                else
                {
                    _ShipMovementControl._rb.linearVelocity = Vector2.zero;
                    _ShipMovementControl._rb.angularVelocity = 0;
                    ship_OpenStore = true;
                }
            }
        }
        else
        {
            ship_PromptStoreText.SetActive(false);
        }

        if (ship_OpenStore)
        {
            store_UI.SetActive(true);
        }
        else
        {
            store_UI.SetActive(false);
        }

    }

    public void UpdatePolarityRadius()
    {
        if (_ShipStatsManager.level_Radius < cost_Radius.Count-1)
        {
            if (_ShipStatsManager._TotalMoney >= cost_Radius[_ShipStatsManager.level_Radius])
            {
                _ShipStatsManager.level_Radius++;
                _ShipStatsManager._TotalMoney -= cost_Radius[_ShipStatsManager.level_Radius];
                _ShipCollectRadius.ship_PolarityCollider.radius = value_Radius[_ShipStatsManager.level_Radius];
            }
        }
    }
    public void UpdateAttractForce()
    {
        if (_ShipStatsManager.level_PolarityForce < cost_PolarityForce.Count-1)
        {
            if (_ShipStatsManager._TotalMoney >= cost_PolarityForce[_ShipStatsManager.level_PolarityForce])
            {
                _ShipStatsManager.level_PolarityForce++;
                _ShipStatsManager._TotalMoney -= cost_PolarityForce[_ShipStatsManager.level_PolarityForce];
                _ShipCollectRadius.ship_PolarityStrength = value_PolarityForce[_ShipStatsManager.level_PolarityForce];
            }
        }

    }

    public void UpdateShipThrustForce()
    {
        if (_ShipStatsManager.level_ThrustForce < cost_ShipThrust.Count - 1)
        {
            if (_ShipStatsManager._TotalMoney >= cost_ShipThrust[_ShipStatsManager.level_ThrustForce])
            {
                _ShipStatsManager.level_ThrustForce++;
                _ShipStatsManager._TotalMoney -= cost_ShipThrust[_ShipStatsManager.level_ThrustForce];
                _ShipMovementControl.ship_ThrustForce = value_ThrustForce[_ShipStatsManager.level_ThrustForce];
            }
        }

    }
    public void UpdateShipMaxSpeed()
    {
        if (_ShipStatsManager.level_ShipMaxSpeed < cost_ShipMaxSpeed.Count-1)
        {
            if (_ShipStatsManager._TotalMoney >= cost_ShipMaxSpeed[_ShipStatsManager.level_ShipMaxSpeed])
            {
                _ShipStatsManager.level_ShipMaxSpeed++;
                _ShipStatsManager._TotalMoney -= cost_ShipMaxSpeed[_ShipStatsManager.level_ShipMaxSpeed];
                _ShipMovementControl.ship_MaxSpeed = value_ShipMaxSpeed[_ShipStatsManager.level_ShipMaxSpeed];
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<ShipMovementControl>() != null)
        {
            ship_InStore = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<ShipMovementControl>() != null)
        {
            ship_InStore = false;
        }
    }
}
