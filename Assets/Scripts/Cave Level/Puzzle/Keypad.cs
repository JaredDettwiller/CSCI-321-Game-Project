using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : MonoBehaviour
{
    public string enteredIntoKeypad;
    string correct;
    // Start is called before the first frame update
    private void Start()
    {
        correct = "725";
        enteredIntoKeypad = "";
    }
    public void addNumberToString(string number)
    {
        enteredIntoKeypad += number;
        print(enteredIntoKeypad);
    }

    public void clearString()
    {
        this.enteredIntoKeypad = "";
    }
}
