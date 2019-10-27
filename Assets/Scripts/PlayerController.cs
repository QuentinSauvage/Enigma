using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField]
	private float rotationSpeed = 10f, moveSpeed = 10f;

	[SerializeField]
	private int speakDistance = 5;
	private Rigidbody rb;
	private DialogueManager dialogueManager;

	void Awake()
	{
		rb = transform.GetComponent<Rigidbody>();
		dialogueManager = FindObjectOfType<DialogueManager>();
	}

	public void TryToMove()
	{
		transform.Translate(0, 0, Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
		transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime, 0);
	}

	public void TryToInteract()
	{
		RaycastHit hit;
		if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, speakDistance))
		{
			DialogueTrigger dialogueTrigger = hit.transform.GetComponent<DialogueTrigger>();
			if(dialogueTrigger != null) {
				dialogueTrigger.TriggerDialogue();
			} else
			{
				CodeButton codeButton = hit.transform.GetComponent<CodeButton>();
				codeButton?.ModifyTexture();
			}
		}
	}
}
