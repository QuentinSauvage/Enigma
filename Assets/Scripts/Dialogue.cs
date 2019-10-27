using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
	public DialogueItem[] sentences;
	public string name;
}

[System.Serializable]
public class DialogueItem
{
	public string name;
	public string sentence;
	public Option[] options;
	private int selectedIndex = 0;
	private static int idCpt = 0;
	public int id;

	public DialogueItem()
	{
		id = idCpt++;
		sentence = "";
		options = new Option[0];
	}

	public int SelectedIndex
	{
		get { return selectedIndex; }
		set { selectedIndex = value; }
	}

	public void ChangeIndex(int input)
	{
		if (options.Length > 0)
		{
			selectedIndex = (selectedIndex + input + options.Length) % options.Length;
		}
	}
}

[System.Serializable]
public class Option
{
	public string text;
	public string action;
}