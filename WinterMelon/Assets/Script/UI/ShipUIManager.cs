using UnityEngine;
using TMPro;

public class ShipUIManager : MonoBehaviour
{
    public TextMeshProUGUI ship_CurrentSpeed,ship_TotalMoney,ship_TimeLeft;

    ShipMovementControl _shipMovementControl;
    ShipStatsManager _shipStatsManager;

    private void Start()
    {
        _shipMovementControl = FindAnyObjectByType<ShipMovementControl>();
        _shipStatsManager = FindAnyObjectByType<ShipStatsManager>();
    }

    private void FixedUpdate()
    {
        ship_TimeLeft.text = "Time Left: ";
        ship_CurrentSpeed.text = "Speed: " + _shipMovementControl._rb.linearVelocity.magnitude.ToString("F0") + '/' + _shipMovementControl.ship_MaxSpeed;
    }
    public void UpdateMoneyUI()
    {
        ship_TotalMoney.text = "Money: $" + ship_TotalMoney;
    }
}
