using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealthContainer : MonoBehaviour
{
	[SerializeField] private int health;

	[SerializeField] private GameObject HealthBar;
	[SerializeField] private ParticleSystem effectObtain;
	[SerializeField] private GameObject alternateTower;
	// Use this for initialization
	// Update is called once per frame
	void DisableEffect()
	{
		effectObtain.gameObject.SetActive(false);
	}
	void Update ()
	{
		if (health <= 0)
		{
			effectObtain.gameObject.SetActive(true);
			gameObject.SetActive(false);
			alternateTower.SetActive(true);
			Invoke("DisableEffect", 1);
			health = 100;
		}
		HealthBar.GetComponent<HealthBar>().SetSize(health / 100f);
	}

	public void DecreaseHealth(int value)
	{
		health -= value;
	}
}
