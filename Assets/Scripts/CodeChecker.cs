using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeChecker : MonoBehaviour
{

	public enum Buttons { UP, DOWN, LEFT, RIGHT, B, A };
	public Buttons[] codeSequence;

	private  GameObject codeButtons;
	private GameObject teleporter;
	private DoorTrigger doorTrigger;

	void Awake()
	{
		codeButtons = GameObject.Find("Code Buttons");
		doorTrigger = FindObjectOfType<DoorTrigger>();
		teleporter = GameObject.Find("Teleporter");
		teleporter.SetActive(false);
	}

    public void Verify()
	{
		CodeButton codeButton;
		for (int i = 0; i < codeButtons.transform.childCount; i++)
		{
			codeButton = codeButtons.transform.GetChild(i).GetComponent<CodeButton>();
			if (codeButton.GetIndex() != (int) codeSequence[i])
			{
				doorTrigger.TriggerDialogue(false);
				return;
			}
		}
		teleporter.SetActive(true);
		doorTrigger.TriggerDialogue(true);
	}
}
