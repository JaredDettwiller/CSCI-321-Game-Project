using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextSet : MonoBehaviour
{
    private Text UIText;
    private GameObject TextPanel;
    void Start()
    {
        TextPanel = gameObject.transform.GetChild(0).gameObject;
        UIText = TextPanel.transform.GetChild(0).gameObject.GetComponent<Text>();
        UIText.text = "";
        TextPanel.SetActive(false);
    }

    public void clearUI(){
        UIText.text = "";
        TextPanel.SetActive(false);
    }

    public void setUIText(string text){
        TextPanel.SetActive(true);
        UIText.text = text;
    }
}
