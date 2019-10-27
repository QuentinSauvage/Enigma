using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
	[SerializeField]
	private float dialogueSpeed = 0.01f;
	private Queue<DialogueItem> sentences;
	private DialogueItem displayedDialogue;
	private PlayerController characterController;
	private bool speaking = false;
	private CodeChecker codeChecker;

	public TMPro.TextMeshProUGUI dialogueText;
	public TMPro.TextMeshProUGUI dialogueName;
	public GameObject dialogueOptions;
	public GameObject dialoguePanel;
	public Color32 selectedOption, notSelectedOption;

	void Awake()
	{
		displayedDialogue = new DialogueItem();
		sentences = new Queue<DialogueItem>();
		characterController = FindObjectOfType<PlayerController>();
		codeChecker = FindObjectOfType<CodeChecker>();
	}

	public void ChangeChoice(int input)
	{
		TextMeshProUGUI lastChoice = dialogueOptions.transform.GetChild(displayedDialogue.SelectedIndex).GetComponent<TextMeshProUGUI>();
		lastChoice.color = notSelectedOption;
		displayedDialogue.ChangeIndex(input);
		TextMeshProUGUI newChoice = dialogueOptions.transform.GetChild(displayedDialogue.SelectedIndex).GetComponent<TextMeshProUGUI>();
		newChoice.color = selectedOption;
	}

	public void NextAction()
	{
		if (speaking)
		{
			DisplayNextSentence();
		}
		else
		{
			characterController.TryToInteract();
		}
	}

	public bool GetSpeaking()
	{
		return speaking;
	}

	public void StartDialogue(Dialogue dialogue)
	{
		speaking = true;
		sentences.Clear();
		foreach (DialogueItem sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}
		dialogueName.text = dialogue.name;
		dialoguePanel.SetActive(true);
		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		dialogueOptions.SetActive(false);
		if (displayedDialogue.options.Length > 0)
		{
			CheckAction(displayedDialogue.options[displayedDialogue.SelectedIndex].action);
		}
		if (sentences.Count != 0)
		{
			InitText();
		}
		else
		{
			EndDialogue();
		}
	}

	private void InitText()
	{
		displayedDialogue = sentences.Dequeue();
		displayedDialogue.SelectedIndex = 0;
		StopCoroutine("DisplaySentence");
		dialogueText.text = "";
		StartCoroutine("DisplaySentence");
		DisplayOptions();
	}

	private IEnumerator DisplaySentence()
	{
		for (int i = 0; i < displayedDialogue.sentence.Length; i++)
		{
			dialogueText.text += displayedDialogue.sentence[i];
			yield return new WaitForSeconds(dialogueSpeed);
		}
		yield return null;
	}

	private void DisplayOptions()
	{
		if (displayedDialogue.options.Length > 0 && displayedDialogue.options.Length <= 3)
		{
			dialogueOptions.SetActive(true);
			for (int i = 0; i < displayedDialogue.options.Length; i++)
			{
				TextMeshProUGUI option = dialogueOptions.transform.GetChild(i).GetComponent<TextMeshProUGUI>();
				option.text = displayedDialogue.options[i].text;
				if (i > 0)
				{
					option.color = notSelectedOption;
				}
				else
				{
					option.color = selectedOption;
				}
			}
		}
	}

	private void CheckAction(string action)
	{
		Invoke(action, 0);
	}

	private void Verify()
	{
		codeChecker.Verify();
	}

	private void DoNothing() { }

	private void EndDialogue()
	{
		speaking = false;
		displayedDialogue = new DialogueItem();
		dialoguePanel.SetActive(false);
		GameObject teleporter = GameObject.Find("Teleporter");
		if (teleporter != null)
		{
			GameObject door = GameObject.Find("Door");
			door.SetActive(false);
		}
	}
}
