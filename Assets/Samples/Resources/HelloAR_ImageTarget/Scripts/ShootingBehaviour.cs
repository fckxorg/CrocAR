using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingBehaviour : MonoBehaviour
{
	[SerializeField] private GameObject fireball;
	[SerializeField] private GameObject iceball;
	[SerializeField] private Button fireball_cast;
	[SerializeField] private Button iceball_cast;
	[SerializeField] private SpriteRenderer aim;
	[SerializeField] private GameObject purpleTower;
	[SerializeField] private GameObject redTower;
	[SerializeField] private GameObject ManaBar;
	private float speed = 100;
	private Vector3 target;

	private GameObject bulletObject;
	// Use this for initialization
	void Start () {
		fireball_cast.onClick.AddListener(delegate (){ ShootObject(fireball); });
		iceball_cast.onClick.AddListener(delegate() {ShootObject(iceball);  });
	}

	private void ShootObject(GameObject bullet)
	{
		if (bulletObject == null)
		{
			var position = aim.gameObject.transform.position;
			position.x += 1;
			target = position;
			target.z += 100;
			if (redTower.active| purpleTower.active)
			{
				speed = 10;
				if (redTower.active)
				{
					target = redTower.transform.position;
				}

				if (purpleTower.active)
				{
					target = purpleTower.transform.position;
				}
			}
			else
			{
				speed = 100;
			}
			var rotation = Quaternion.Euler(0f, 0f, 0f);
			bulletObject = Instantiate(bullet, position, rotation);
			ManaBar.GetComponent<ManaBar>().DecreaseMana(10);
		}

	}
	void Update() {
		if (Time.frameCount % 100 == 0)
		{
			ManaBar.GetComponent<ManaBar>().IncreaseMana(5);
		}

		if (bulletObject != null)
		{
			if (bulletObject.transform.position.z >= target.z)
			{
				if (redTower.active)
				{
					redTower.GetComponent<TowerHealthContainer>().DecreaseHealth(20);
				}

				if (purpleTower.active)
				{
					purpleTower.GetComponent<TowerHealthContainer>().DecreaseHealth(20);
				}
				GameObject.Destroy(bulletObject);
			}
			else
			{
				float step = speed * Time.deltaTime;
				bulletObject.transform.position = Vector3.MoveTowards(bulletObject.transform.position, target, step);
			}
		}
	}
	// Update is called once per fram
}
