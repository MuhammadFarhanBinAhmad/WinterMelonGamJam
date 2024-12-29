using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentTime = (_Min * 60) + _Sec; //min * 60s + number of secs
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
            if (_currentTime <= 0.0f)
            {
                isTimerRunning = false;
                _currentTime = 0.0f;
            }
        }
    }
}
