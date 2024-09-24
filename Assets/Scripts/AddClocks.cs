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
    int rows = 1;
    [SerializeField]
    float[] timeZones = new float[]{0, -5, 6, 4, 2 };
    List<GameObject> clocks = new();
    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        int cols = timeZones.Length / rows + 1;
        float initOffset = seperation*((float)timeZones.Length)/-2f - 10f - seperation;
        foreach(float zone in timeZones)
        {
            i++;
            GameObject clock = Instantiate(funny, new Vector3(-1f*timeZones.Length/2f*seperation + i%cols * seperation, -i/cols*seperation, 0), Quaternion.identity, this.transform);
            Clock clockcode = clock.GetComponent<Clock>();
            clockcode.UtcOffset = zone;
            clocks.Add(clock);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
