using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

	private DialogueManager dialogueManager;
	private PlayerController playerController;

	void Awake()
	{
		dialogueManager = FindObjectOfType<DialogueManager>();
		playerController = FindObjectOfType<PlayerController>();
	}

	void Update()
	{
		//dialogue inputs
		if (Input.GetKeyDown(KeyCode.Return))
		{
			dialogueManager.NextAction();
		}
		else if (dialogueManager.GetSpeaking())
		{
			if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				dialogueManager.ChangeChoice(1);
			}
			else if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				dialogueManager.ChangeChoice(-1);
			}
		}
		else
		{
			playerController.TryToMove();
		}
	}
}
