using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField]
    GameObject clock;
    [SerializeField]
    GameObject hoursHand;
    [SerializeField]
    GameObject minutesHand;
    [SerializeField]
    Transform hoursPivot;
    [SerializeField]
    Transform minutePivot;
    [SerializeField]
    Transform secondPivot;
    [SerializeField]
    private TextMeshPro nameText;
    public string IanaCode = "UTC";
    public string text;
    float hoursToDegree = -30f, minutesToDegrees = -6f, secondsToDegrees = -6f;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        DateTime time = DateTime.UtcNow;
        TimeZoneInfo current = TimeZoneInfo.FindSystemTimeZoneById(IanaCode);
        time = TimeZoneInfo.ConvertTime(time, current);
        TimeSpan timeSpan = time.TimeOfDay;
        hoursPivot.localRotation = Quaternion.Euler(0f, 0f, hoursToDegree * (float)timeSpan.TotalHours);
        minutePivot.localRotation = Quaternion.Euler(0f, 0f, minutesToDegrees * (float)timeSpan.TotalMinutes);
        secondPivot.localRotation = Quaternion.Euler(0f, 0f, secondsToDegrees * (float)timeSpan.TotalSeconds);
        nameText.text = text + "\n" + (timeSpan.Hours/10==0? "0"+timeSpan.Hours : timeSpan.Hours) + 
            ":" + (timeSpan.Minutes/10==0 ? "0"+timeSpan.Minutes : timeSpan.Minutes) + 
            ":" + (timeSpan.Seconds/10==0 ? "0" + timeSpan.Seconds : timeSpan.Seconds);
        if (timeSpan.TotalHours> 0 && timeSpan.TotalHours < 6 || timeSpan.TotalHours > 20)
        {
            clock.GetComponent<MeshRenderer>().material.color = Color.black;
            hoursHand.GetComponent<MeshRenderer>().material.color = Color.white;
            minutesHand.GetComponent<MeshRenderer>().material.color = Color.white;
        } else {
            clock.GetComponent<MeshRenderer>().material.color = Color.white;
            hoursHand.GetComponent<MeshRenderer>().material.color = Color.black;
            minutesHand.GetComponent<MeshRenderer>().material.color = Color.black;
        }
    }
}
