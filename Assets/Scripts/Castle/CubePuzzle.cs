using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePuzzle : MonoBehaviour
{
    public bool isInteractable = false;
    public GameObject chest;
    public Animator top;
    public Animator middle;
    public Animator bottom;
    public AudioClip puzzleDone;
    private int topValue = 0;
    private int midValue = 0;
    private int botValue = 0;
    private float timeSinceLastPress = 0;
    private ConsolePrompt consolePrompt;

    void Start()
    {
        chest.SetActive(false);
    }

    void Update()
    {
        if(topValue == 3 && midValue == 1 && botValue == 2)
        {
            chest.SetActive(true);
            GetComponent<AudioSource>().PlayOneShot(puzzleDone);
        }
        if(isInteractable && timeSinceLastPress >= 1f)
        {
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                StartCoroutine(SpinTop());
                timeSinceLastPress = 0f;
            }
            if(Input.GetKeyDown(KeyCode.Alpha2))
            {
                StartCoroutine(SpinMiddle());
                timeSinceLastPress = 0f;
            }
            if(Input.GetKeyDown(KeyCode.Alpha3))
            {
                StartCoroutine(SpinBottom());
                timeSinceLastPress = 0f;
            }
        }
        timeSinceLastPress += Time.deltaTime;
    }

    public void OnTriggerStay(Collider other)
    {
        
        if(other.gameObject.CompareTag("Player"))
        {
            isInteractable = true;
            GetComponent<ConsolePrompt>().InRange();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isInteractable = false;
            GetComponent<ConsolePrompt>().OutOfRange();
        }
    }

    IEnumerator SpinTop()
    {
        top.SetBool("Rotate", true);
        yield return new WaitForSeconds(1);
        top.SetBool("Rotate", false);
        topValue += 1;
        if(topValue == 4)
        {
            topValue = 0;
        }
        print(topValue);
    }

    IEnumerator SpinMiddle()
    {
        middle.SetBool("Rotate", true);
        yield return new WaitForSeconds(1);
        middle.SetBool("Rotate", false);
        midValue += 1;
        if(midValue >= 4)
        {
            midValue = 0;
        }
    }

    IEnumerator SpinBottom()
    {
        bottom.SetBool("Rotate", true);
        yield return new WaitForSeconds(1);
        bottom.SetBool("Rotate", false);
        botValue += 1;
        if(botValue >= 4)
        {
            botValue = 0;
        }
    }
}
