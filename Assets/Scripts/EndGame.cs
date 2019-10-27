using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{

	public Animator animator;

	public void FadeOut()
	{
		animator.SetTrigger("FadeOut");
	}

	void OnFadeComplete()
	{
		SceneManager.LoadScene(1);
	}
}
