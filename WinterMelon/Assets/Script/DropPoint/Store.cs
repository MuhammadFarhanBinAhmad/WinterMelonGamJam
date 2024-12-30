using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    ShipStickRadius _ShipStickRadius;

    public GameObject store_UI;
    public GameObject ship_PromptStoreText;
    public GameObject ship_PromptSellText;

    public List<Button> m_Buttons;
    public List<TextMeshProUGUI> m_Texts;

    private void Start()
    {
        _ShipMovementControl = FindAnyObjectByType<ShipMovementControl>();
        _ShipCollectRadius = FindAnyObjectByType<ShipCollectRadius>();
        _ShipStatsManager = FindAnyObjectByType<ShipStatsManager>();
        _ShipStickRadius = FindAnyObjectByType<ShipStickRadius>();

        m_Texts[0].text = "$" + cost_Radius[0].ToString() + " Radius+";
        m_Texts[1].text = "$" + cost_PolarityForce[0].ToString() + " Force+";
        m_Texts[2].text = "$" + cost_ShipThrust[0].ToString() + " Thrust+";
        m_Texts[3].text = "$" + cost_ShipMaxSpeed[0].ToString() + " Max Speed+";
    }
    private void Update()
    {
        if (ship_InStore)
        {
            if (_ShipStatsManager._TotalMoney > 0) {
                ship_PromptStoreText.SetActive(true);
            }
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

        if (ship_InStore && _ShipStickRadius.HasScrap()) {
            ship_PromptSellText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R)) {
                _ShipStatsManager._TotalMoney += _ShipStickRadius.SellScrap();
            }
        }
        else {
            ship_PromptSellText.SetActive(false);
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
                _ShipStatsManager._TotalMoney -= cost_Radius[_ShipStatsManager.level_Radius];
                _ShipStatsManager.level_Radius++;

                float radius = (float)value_Radius[_ShipStatsManager.level_Radius];
                _ShipCollectRadius.ship_PolarityCollider.radius = radius - 0.5f;
                _ShipCollectRadius.m_Circle.localScale = new Vector3(radius * 2.0f, radius * 2.0f, 1);
                _ShipCollectRadius.ship_Attract.transform.localScale = new Vector3(radius / 2.0f, radius / 2.0f, 1);
                _ShipCollectRadius.ship_Repel.transform.localScale = new Vector3(radius / 2.0f, radius / 2.0f, 1);

                if (_ShipStatsManager.level_Radius == cost_Radius.Count - 1) {
                    m_Buttons[0].interactable = false;
                }
                else {
                    m_Texts[0].text = "$" + cost_Radius[_ShipStatsManager.level_Radius].ToString() + " Radius+";
                }
            }
        }
    }
    public void UpdateAttractForce()
    {
        if (_ShipStatsManager.level_PolarityForce < cost_PolarityForce.Count-1)
        {
            if (_ShipStatsManager._TotalMoney >= cost_PolarityForce[_ShipStatsManager.level_PolarityForce])
            {
                _ShipStatsManager._TotalMoney -= cost_PolarityForce[_ShipStatsManager.level_PolarityForce];
                _ShipStatsManager.level_PolarityForce++;
                _ShipCollectRadius.ship_PolarityStrength = value_PolarityForce[_ShipStatsManager.level_PolarityForce];

                if (_ShipStatsManager.level_PolarityForce == cost_PolarityForce.Count - 1) {
                    m_Buttons[1].interactable = false;
                }
                else {
                    m_Texts[1].text = "$" + cost_PolarityForce[_ShipStatsManager.level_PolarityForce].ToString() + " Force+";
                }
            }
        }

    }

    public void UpdateShipThrustForce()
    {
        if (_ShipStatsManager.level_ThrustForce < cost_ShipThrust.Count - 1)
        {
            if (_ShipStatsManager._TotalMoney >= cost_ShipThrust[_ShipStatsManager.level_ThrustForce]) {
                _ShipStatsManager._TotalMoney -= cost_ShipThrust[_ShipStatsManager.level_ThrustForce];
                _ShipStatsManager.level_ThrustForce++;
                _ShipMovementControl.ship_ThrustForce = value_ThrustForce[_ShipStatsManager.level_ThrustForce];

                if (_ShipStatsManager.level_ThrustForce == cost_ShipThrust.Count - 1) {
                    m_Buttons[2].interactable = false;
                }
                else {
                    m_Texts[2].text = "$" + cost_ShipThrust[_ShipStatsManager.level_ThrustForce].ToString() + " Thrust+";
                }
            }
        }

    }
    public void UpdateShipMaxSpeed()
    {
        if (_ShipStatsManager.level_ShipMaxSpeed < cost_ShipMaxSpeed.Count-1)
        {
            if (_ShipStatsManager._TotalMoney >= cost_ShipMaxSpeed[_ShipStatsManager.level_ShipMaxSpeed])
            {
                _ShipStatsManager._TotalMoney -= cost_ShipMaxSpeed[_ShipStatsManager.level_ShipMaxSpeed];
                _ShipStatsManager.level_ShipMaxSpeed++;
                _ShipMovementControl.ship_MaxSpeed = value_ShipMaxSpeed[_ShipStatsManager.level_ShipMaxSpeed];

                if (_ShipStatsManager.level_ShipMaxSpeed == cost_ShipMaxSpeed.Count - 1) {
                    m_Buttons[3].interactable = false;
                }
                else {
                    m_Texts[3].text = "$" + cost_ShipMaxSpeed[_ShipStatsManager.level_ShipMaxSpeed].ToString() + " Max Speed+";
                }
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
