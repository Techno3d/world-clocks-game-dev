using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField]
    GameObject clock;
    [SerializeField]
    Transform hoursPivot;
    [SerializeField]
    Transform minutePivot;
    [SerializeField]
    Transform secondPivot;
    [SerializeField]
    public float UtcOffset = 0;
    float hoursToDegree = -30f, minutesToDegrees = -6f, secondsToDegrees = -6f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimeSpan time = DateTime.UtcNow.TimeOfDay;
        hoursPivot.localRotation = Quaternion.Euler(0f, 0f, hoursToDegree * (float)(time.TotalHours+UtcOffset));
        minutePivot.localRotation = Quaternion.Euler(0f, 0f, minutesToDegrees * (float)time.TotalMinutes);
        secondPivot.localRotation = Quaternion.Euler(0f, 0f, secondsToDegrees * (float)time.TotalSeconds);
        if (time.TotalHours + UtcOffset > 12)
        {
            
        }
    }
}
