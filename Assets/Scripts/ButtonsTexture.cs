using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsTexture : MonoBehaviour
{
	private static ButtonsTexture instance;

	public Material[] materials;

	void Awake()
	{
		if(instance == null)
		{
			instance = this;
		}
	}

	public ButtonsTexture GetInstance()
	{
		return instance;
	}
}
