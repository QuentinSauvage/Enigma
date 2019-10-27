using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : DialogueTrigger
{
	public Dialogue startDialogue;
	public Dialogue failDialogue;
	public Dialogue winDialogue;

	void Start()
	{
		dialogueManager.StartDialogue(startDialogue);
	}

	public void TriggerDialogue(bool win)
	{
		if(win)
		{
			dialogueManager.StartDialogue(winDialogue);
		} else
		{
			dialogueManager.StartDialogue(failDialogue);
		}
	}
}
