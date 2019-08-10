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
	private float speed = 100;
	private float acceleration = 1;
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
			target.z += 200;
			var rotation = Quaternion.Euler(0f, 0f, 0f);
			bulletObject = Instantiate(bullet, position, rotation);
		}

	}
	void Update() {
		if (bulletObject != null)
		{
			if (bulletObject.transform.position.z >= target.z)
			{
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
