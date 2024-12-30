using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShipUIManager : MonoBehaviour
{
    public TextMeshProUGUI ship_CurrentSpeed,ship_TotalMoney,ship_TimeLeft;

    ShipMovementControl _shipMovementControl;
    ShipStatsManager _shipStatsManager;

    public Image ship_SpeedbarFill;
    public RectTransform ship_SpeedbarBaseRect;
    public RectTransform ship_SpeedbarRect;
    private float minBarWidth = 250.0f;
    private float maxBarWidth = 350.0f;
    [Header("Gradient Colors")]
    public Color lowSpeedColor = Color.green; // Color at minimum speed
    public Color highSpeedColor = Color.red; // Color at maximum speed

    public float currentSpeed = 0.0f;
    public float maxSpeed = 100.0f;

    private void Start()
    {
        _shipMovementControl = FindAnyObjectByType<ShipMovementControl>();
        _shipStatsManager = FindAnyObjectByType<ShipStatsManager>();
        ship_SpeedbarFill = GameObject.Find("SpeedBar").GetComponent<Image>();
        ship_SpeedbarFill.fillAmount = 0.0f;
        ship_SpeedbarBaseRect = GameObject.Find("SpeedBarBase").GetComponent<RectTransform>();
        ship_SpeedbarRect = GameObject.Find("SpeedBar").GetComponent<RectTransform>();

        //_countdownTimer.isRunning = true;
    }

    private void FixedUpdate()
    {
        //ship_TimeLeft.text = "Time Left: ";
        ship_CurrentSpeed.text = "Speed: " + _shipMovementControl._rb.linearVelocity.magnitude.ToString("F0") + '/' + _shipMovementControl.ship_MaxSpeed;
       
        //Update whatever the ship need
        UpdateTimer();
        UpdateMoneyUI();
        UpdateMaxSpeed();
        UpdateSpeedBar();
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

    public void UpdateSpeedBar()
    {
        currentSpeed = _shipMovementControl._rb.linearVelocity.magnitude;
        maxSpeed = _shipMovementControl.ship_MaxSpeed;

        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
        float fillBar = currentSpeed / maxSpeed;
        ship_SpeedbarFill.fillAmount = fillBar;
        ship_SpeedbarFill.color = Color.Lerp(lowSpeedColor, highSpeedColor, fillBar);
        // For checking
        //Debug.Log("Fill Bar:" + ship_SpeedbarFill.fillAmount);
        //Debug.Log("Curr Speed:" + currentSpeed);
        //Debug.Log("Max Speed:" + maxSpeed);
    }

    public void UpdateMaxSpeed() //This function helps to update max speed as it constantly changing when player purchases upgrades
    {
        maxSpeed = _shipMovementControl.ship_MaxSpeed;

		float newWidth = Mathf.Clamp(maxSpeed * 50f, minBarWidth, maxBarWidth); //technically width because i rotate
        float currHeight = ship_SpeedbarBaseRect.rect.height;
        ship_SpeedbarBaseRect.sizeDelta = new Vector2(newWidth, currHeight);
        ship_SpeedbarRect.sizeDelta = new Vector2(newWidth, currHeight);

    }
}
