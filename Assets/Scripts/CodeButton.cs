using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeButton : MonoBehaviour
{
	public static Material[] buttonMaterials;

	private Material buttonMaterial;
	private ButtonsTexture buttonsTexture;
	private Renderer buttonRenderer;
	private int index = 5;

    void Start()
	{
		buttonRenderer = GetComponent<Renderer>();
		buttonsTexture = FindObjectOfType<ButtonsTexture>().GetInstance();
		buttonRenderer.material = buttonsTexture.materials[index];
	}

    public void ModifyTexture()
	{
		index = (index + 1) % buttonsTexture.materials.Length;
		buttonRenderer.material = buttonsTexture.materials[index];
	}

	public int GetIndex()
	{
		return index;
	}
}
