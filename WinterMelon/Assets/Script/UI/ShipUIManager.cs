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

        //_countdownTimer.isRunning = true;
    }

    private void FixedUpdate()
    {
        //ship_TimeLeft.text = "Time Left: ";
        ship_CurrentSpeed.text = "Speed: " + _shipMovementControl._rb.linearVelocity.magnitude.ToString("F0") + '/' + _shipMovementControl.ship_MaxSpeed;
        UpdateTimer();
        UpdateMoneyUI();
    }

    public void UpdateTimer()
    {
        int min = Mathf.FloorToInt(_shipStatsManager._currentTime / 60);
        int sec = Mathf.FloorToInt(_shipStatsManager._currentTime % 60);
        ship_TimeLeft.text = "Time Left: " + $"{min:0}:{sec:00}";
    }

    public void UpdateMoneyUI()
    {
        ship_TotalMoney.text = "$" + _shipStatsManager._TotalMoney;
    }

    public void ShowUIOpenStore()
    {
        
    }
}
