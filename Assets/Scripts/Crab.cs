using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : MonoBehaviour
{
	[SerializeField] private string dialogueName;
	

	private Dialogue dialogue;
	void Start() 
	{
		dialogue = FindObjectOfType<Dialogue>();
	}

	void OnTriggerEnter2D()
	{
		dialogue.Activate(dialogueName);
	}

	void OnTriggerExit2D()
	{
		dialogue.Deactivate();
	}

	
}
