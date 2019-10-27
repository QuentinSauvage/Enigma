using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
	public Dialogue dialogue;
	protected DialogueManager dialogueManager;

	void Awake()
	{
		dialogueManager = FindObjectOfType<DialogueManager>();
	}

	public void TriggerDialogue()
	{
		dialogueManager.StartDialogue(dialogue);
	}
}
