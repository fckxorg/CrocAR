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

	public void DecreaseMana(float value)
	{
		SetSize(bar.localScale.x-value/100f);
	}
	public void IncreaseMana(float value)
	{
		if (bar.localScale.x < 1f)
		{
			if ((bar.localScale.x + value / 100f) > 1)
			{
				SetSize(1f);
			}
			else
			{
				SetSize(bar.localScale.x + value / 100f);
			}
		}
	}
	public void SetSize(float sizeNormalized)
	{
		bar.localScale = new Vector3(sizeNormalized, 1f);
	}

}
