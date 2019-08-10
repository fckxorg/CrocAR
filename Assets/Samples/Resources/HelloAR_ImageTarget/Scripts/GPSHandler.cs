using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
 
public class GPSHandler : MonoBehaviour
{
    private Text text;
    public float angle;
    private float targetLatitude = 55.70911f;
    private float targetLongitude = 37.71966f;
    [SerializeField] private GameObject healthBar;
    void Start()
    {
        text = gameObject.GetComponent<Text>();
        Input.location.Start();
        Input.compass.enabled = true;
    }

    private float GetTargetDirection(double lat1, double lng1, double lat2, double lng2) {

        double PI = Math.PI;
        double dTeta = Math.Log(Math.Tan((lat2/2)+(PI/4))/Math.Tan((lat1/2)+(PI/4)));
        double dLon = Math.Abs(lng1-lng2);
        double teta = Math.Atan2(dLon,dTeta);
        double direction = Math.Round(teta*(180.0 / Math.PI));
        return (float)direction; //direction in degree
    }
    private void Update()
    {
        if (Input.location.isEnabledByUser)
        {
            
            float lat = Input.location.lastData.latitude;
            float lon = Input.location.lastData.longitude;
            float heading = Input.compass.magneticHeading;
            angle = GetTargetDirection((double) lat, (double) lon, (double) targetLatitude, (double) targetLongitude);
            
            if (Math.Abs(heading - angle) <= 20)
            {
                healthBar.SetActive(true);
            }
            else
            {
                healthBar.SetActive(false);
            }
            text.text = "Depart lat: " + lat + " lon: " + lon +" magnetic: "+heading;
            
        }
        else
            text.text = "gps off";
    }
    
}