using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterController : MonoBehaviour
{
	private bool collided = false;
    void OnCollisionEnter(Collision collision)
	{
		if(!collided)
		{
			EndGame endGame = FindObjectOfType<EndGame>();
			endGame.FadeOut();
			collided = true;
		}
	}
}
