using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddClocks : MonoBehaviour
{
    [SerializeField]
    GameObject clockPrefab;
    [SerializeField]
    float seperation = 10f;
    [SerializeField]
    int columns = 1;
    [SerializeField]
    string[] zoneNames = new string[]{"", "", "", "", ""};
    [SerializeField]
    string[] timeZones = new string[]{};
    List<GameObject> clocks = new();

    void Start()
    {
        int i = 0;
        float initOffset = columns*seperation/4f;
        foreach(string zone in timeZones)
        {
            // Current row is the index divided by the # of columns
            int curRow = i/columns;
            // Current row is the index modulo by the # of columns (whats left of a row)
            int curColumn = i%columns;
            // This is to insure that any odd number row is centered
            if(i/columns == timeZones.Length/columns && timeZones.Length%columns!=0) {
                initOffset = columns*seperation/4f - seperation*(columns-timeZones.Length%columns)/2f;
            }
            GameObject clock = Instantiate(clockPrefab, new Vector3(curColumn*seperation - initOffset, -curRow*(seperation+5) + 10, 0) + transform.position, Quaternion.identity, transform);
            Clock clockcode = clock.GetComponent<Clock>();
            clockcode.IanaCode = zone;
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
