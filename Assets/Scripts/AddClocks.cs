using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddClocks : MonoBehaviour
{
    [SerializeField]
    GameObject funny;
    [SerializeField]
    float seperation = 10f;
    [SerializeField]
    int columns = 1;
    [SerializeField]
    string[] zoneNames = new string[]{"", "", "", "", ""};
    [SerializeField]
    float[] timeZones = new float[]{0, -5, 6, 4, 2 };
    List<GameObject> clocks = new();
    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        float initOffset = columns*seperation/4f;
        foreach(float zone in timeZones)
        {
            int curRow = i/columns;
            int curColumn = i%columns;
            GameObject clock = Instantiate(funny, new Vector3(curColumn*seperation - initOffset, -curRow*(seperation+5) + 10, 0), Quaternion.identity, this.transform);
            Clock clockcode = clock.GetComponent<Clock>();
            clockcode.UtcOffset = zone;
            clockcode.text = zoneNames[i];
            clocks.Add(clock);
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
