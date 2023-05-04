using UnityEngine;
using System.Collections;

public class Playsound : MonoBehaviour 

{
	public void Clicky (){
		GetComponent<AudioSource>().Play();
		pressButton();
	}

	public void pressButton()
    {
		string buttonName = gameObject.name;
		GameObject keyPad = GameObject.Find("Keypad");

		switch (buttonName)
        {
			case "Enter":
				// TODO: Enter the component
				string correctString = "404";
				if(keyPad.GetComponent<Keypad>().enteredIntoKeypad.Equals(correctString))
                {
					// Get rid of the barrier
					GameObject barrier = GameObject.Find("EnterWaveTwoTrigger");
					barrier.GetComponent<Collider>().isTrigger = true;
					Light light = GameObject.Find("Crystal Light").GetComponent<Light>();
					light.range = 10;

					deactivateKeypad(keyPad);
					// Text
					GameObject textBox = GameObject.Find("Textbox");
					textBox.GetComponent<TextboxTrigger>().DisplayTextInPanel("CorrectCodeText");
				}
				else
                {
					deactivateKeypad(keyPad);
					// Text
					GameObject textBox = GameObject.Find("Textbox");
					textBox.GetComponent<TextboxTrigger>().DisplayTextInPanel("WrongCodeText");
				}
				break;
			case "Clear":
				deactivateKeypad(keyPad);
				break;
			default:
				keyPad.GetComponent<Keypad>().addNumberToString(buttonName);
				break;

		}
    }

	private void deactivateKeypad(GameObject keyPad)
    {
		keyPad.GetComponent<Keypad>().clearString();
		keyPad.SetActive(!keyPad.activeInHierarchy);
		Time.timeScale = 1f;
	}


}
