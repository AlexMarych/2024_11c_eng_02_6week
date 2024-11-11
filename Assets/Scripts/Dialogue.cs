using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Dialogue : MonoBehaviour
{
	private static Dictionary<string, string[]> dialogue = new();
	static Dialogue() 
	{
		dialogue.Add("crab_cannon", new string[]{
			"sup",
			"Now that you found me let me tell you something about that cannon you grabbed just now...",
			"You can shoot which will blast you in the oposite direction if you stand close to the explosion!",
			"After shooting you should spin your mouse around your character to reload!"
		});
	}

    private bool isSpeaking;

    private string[] currentDialogue = null;
	private int index = 0;

	private TMPro.TextMeshProUGUI text;

    void Start()
    {
       
        text = transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>();
		text.transform.gameObject.SetActive(false);
    }

	public void Activate(string dialogueName) 
	{
        isSpeaking = true;
        if (dialogue.TryGetValue(dialogueName, out currentDialogue))

		text.transform.gameObject.SetActive(true);
		UpdateText();
	} 

	public void Deactivate() 
	{
        isSpeaking = false;
        text.transform.gameObject.SetActive(false);
		index = 0;
	}

	private void UpdateText() {
		if (index >= currentDialogue.Length) 
		{
			return;
		}

		text.text = currentDialogue[index];
		if (index < currentDialogue.Length - 1) {
			text.text += $" <color=#87B6C4AF>[enter]</color>";
		}
	}


	public void Update() 
	{
		if (currentDialogue == null) 
		{
            
            return;
		}

		if (Input.GetButtonUp("Submit"))
		{
            
            index += 1;
			UpdateText();
		}
	}

    public bool IsSpeaking()
    {
        return isSpeaking;
    }
}

