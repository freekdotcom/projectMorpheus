using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextBoxManager : MonoBehaviour {
    public GameObject textBox;

    public Text dialogueText; 

    public TextAsset textFile;
    public string[] textLines;

    public int currentLine;
    public int endAtLine;

    private GameObject player;
    private PlayerMovement playerMovement;

    public bool isActive;

    public bool stopPlayerMovement;

    private bool isTyping = false;
    private bool cancelTyping = false;
    public float typeSpeed;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();

        //checks if the file exists
        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }

        if(endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }


        if (isActive)
            EnableTextBox();
        else
            DisableTextBox();
    }

    void Update()
    {
        if (!isActive)
            return;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!isTyping)
            {
                currentLine += 1;

                if (currentLine > endAtLine)
                {
                    DisableTextBox();
                } else
                {
                    StartCoroutine(TextScroll(textLines[currentLine]));
                }
            }
         
        }
        else if(isTyping && !cancelTyping)
        {
            cancelTyping = true;
        }
    }

    private IEnumerator TextScroll(string lineOfText)
    {
        int letter = 0;
        dialogueText.text = "";
        isTyping = true;
        cancelTyping = false;
        while (isTyping && !cancelTyping || (letter < (lineOfText.Length - 1)))
        {
            dialogueText.text += lineOfText[letter];
            letter += 1;
            yield return new WaitForSeconds(typeSpeed);
        }
        dialogueText.text = lineOfText;
        isTyping = false;
        cancelTyping = false;
    }

    public void EnableTextBox()
    {
        textBox.SetActive(true);
        isActive = true;
        stopPlayerMovement = true;

        if (stopPlayerMovement == true)
            playerMovement.enabled = false;

        StartCoroutine(TextScroll(textLines[currentLine]));

    }

    public void DisableTextBox()
    {
        textBox.SetActive(false);
        isActive = false;
        stopPlayerMovement = false;

        if (stopPlayerMovement == false)
            playerMovement.enabled = true;

    }

    public void ReloadScript(TextAsset dialogueTextFile)
    {
        if(dialogueTextFile != null)
        {
            textLines = new string[1];
            textLines = (dialogueTextFile.text.Split('\n'));
        }
    }
}
