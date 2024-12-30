using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipStatsManager : MonoBehaviour
{
    [Header("Stats")]
    public int level_Radius;
    public int level_PolarityForce;
    public int level_ThrustForce;
    public int level_ShipMaxSpeed;

    [Header("Money")]
    public int _TotalMoney;

    [Header("Timer")]
    //public float _Time = 60.0f;
    public int _Min = 1;
    public int _Sec = 30;

    [HideInInspector]
    public float _currentTime = 0.0f;
    [HideInInspector]
    public bool isTimerRunning = false; //might pause for stores?

    private float _totalTime = 0.0f;

    [Header("Timer Bar UI Components")]
    public Image timerBarFill; // Drag TimerBarFill Image here
    public Gradient timerGradient; // Drag Gradient Asset here
    //public float maxTime = 60f; // Maximum time in seconds
    //private float currentTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentTime = (_Min * 60) + _Sec; //min * 60s + number of secs
        _totalTime = _currentTime;
        isTimerRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        TimerCountdown();
    }

    private void TimerCountdown()
    {
        if (isTimerRunning)
        {
            _currentTime -= Time.deltaTime;
            float fillAmount = _currentTime / _totalTime;
            timerBarFill.fillAmount = fillAmount;
            timerBarFill.color = timerGradient.Evaluate(fillAmount);

            if (_currentTime <= 0.0f)
            {
                // GAME OVER
                isTimerRunning = false;
                _currentTime = 0.0f;
                GameObject.Find("Win/LoseScreen").GetComponent<Animator>().SetTrigger("EndScreen");
                FindFirstObjectByType<ScoreManager>().UpgradeFinalGrade();
            }
        }
    }
}
