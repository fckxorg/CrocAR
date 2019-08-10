using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthContainer : MonoBehaviour {

    [SerializeField] private int health;
    [SerializeField] private GameObject HealthBar;

    [SerializeField] private ParticleSystem effectObtain;
    // Use this for initialization
    // Update is called once per frame
    void DisableEffect()
    {
        GameObject.Destroy(effectObtain);
        GameObject.Destroy(HealthBar);
    }
    void Update ()
    {
        if (health <= 0)
        {
            effectObtain.gameObject.SetActive(true);
            HealthBar.GetComponent<HealthBar>().SetSize(0f);
            Invoke("DisableEffect", 1);
        }
        else
        {
            HealthBar.GetComponent<HealthBar>().SetSize(health / 100f);
        }
    }

    public void DecreaseHealth(int value)
    {
        health -= value;
    }
}