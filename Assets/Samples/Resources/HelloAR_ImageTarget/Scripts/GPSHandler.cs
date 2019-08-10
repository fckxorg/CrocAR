using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class GPSHandler : MonoBehaviour
{
    private Text text;
 
    void Start()
    {
        text = gameObject.GetComponent<Text>();
        Input.location.Start();
    }
 
    private void Update()
    {
        if (Input.location.isEnabledByUser)
        {
            float lat = Input.location.lastData.latitude;
            float lon = Input.location.lastData.longitude;
           
            text.text = "Depart lat: " + lat + "lon: " + lon;
 
        }
        else
            text.text = "gps off";
    }
}