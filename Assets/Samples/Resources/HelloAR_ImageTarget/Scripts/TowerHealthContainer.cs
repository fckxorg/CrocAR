using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealthContainer : MonoBehaviour
{
	[SerializeField] private int health;

	[SerializeField] private GameObject HealthBar;

	[SerializeField] private GameObject alternateTower;
	// Use this for initialization
	// Update is called once per frame
	void Update ()
	{
		if (health <= 0)
		{
			gameObject.SetActive(false);
			alternateTower.SetActive(true);
			health = 100;
		}
		HealthBar.GetComponent<HealthBar>().SetSize(health / 100f);
	}

	public void DecreaseHealth(int value)
	{
		health -= value;
	}
}
