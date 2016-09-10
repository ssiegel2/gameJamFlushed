using UnityEngine;
using System.Collections;

public class DisplayDialogueScript : MonoBehaviour {
	public GUIStyle textStyle;

	private class DialogueClass {
		public string text;
		public Rect rect;


		public DialogueClass (string dialogue) {
			// Based on the size of the dialogue, determine how big the rect should be,
			// where to place it, and where to put line breaks in the text

			//int height = textStyle.CalcHeight();

			this.text = dialogue;
			this.rect = new Rect(Screen.width / 2 - 250, Screen.height * 0.60f - 50 / 2, 500, 100);
		}
	}

	private class ChoiceClass {
		public string text;
		public Rect rect;

		public ChoiceClass (string choice, int choiceIndex) {
			if (choiceIndex > 3 || choiceIndex < 1) {
				Debug.LogError ("The maximum choice index is 3. The minimum is 1. Your choice's index is " + choiceIndex);
			}
			else {
				// Format choice text and position by length and choice index
				this.text = choice;

				this.rect = new Rect(0, 0, 500, 20);



				if (choiceIndex == 1) {
					this.rect.x = Screen.width / 3 - 250;
					this.rect.y = Screen.height * 0.75f;
				}
				else if (choiceIndex == 2) {
					this.rect.x = Screen.width * 0.66f - 250;
					this.rect.y = Screen.height * 0.75f;
				}
				else if (choiceIndex == 3) {
					this.rect.x = Screen.width / 2 - 250;
					this.rect.y = Screen.height * 0.825f;
				}


			}
		}
	}

	private DialogueClass dialogue;
	private ChoiceClass choice1;
	private ChoiceClass choice2;
	private ChoiceClass choice3;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}


	public void NewChoice (string words, string option1, string option2, string option3) {
		dialogue = new DialogueClass (words);

		// Choice 1 and choice 2 are required. Choice 3 is optional. Max of 3 choices
		choice1 = new ChoiceClass (option1, 1);
		choice2 = new ChoiceClass (option2, 2);
		choice3 = new ChoiceClass (option3, 3);
	}

	void OnGUI() {
		GUI.Label (dialogue.rect, dialogue.text, textStyle);
		GUI.Label (choice1.rect, choice1.text, textStyle);
		GUI.Label (choice2.rect, choice2.text, textStyle);
		GUI.Label (choice3.rect, choice3.text, textStyle);
	}
}
