using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaBar : MonoBehaviour {

	// Use this for initialization
	[SerializeField] private Transform bar;

	// Use this for initialization
	void Start()
	{
		SetSize(0.7f);
	}

	public void SetSize(float sizeNormalized)
	{
		bar.localScale = new Vector3(sizeNormalized, 1f);
	}

}
