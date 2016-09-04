using UnityEngine;
using System.Collections;

public class ActivateTextAtLine : MonoBehaviour {

    public TextAsset dialogueTextFile;

    public int startingPoint;
    public int endPoint;

    public TextBoxManager textBoxManager;

    public bool requieredButtonPress;
    private bool waitForPress;

    public bool destroyWhenActivated;

	// Use this for initialization
	void Start () {
        textBoxManager = FindObjectOfType<TextBoxManager>();
	}
	
	// Update is called once per frame
	void Update () {

        if(waitForPress && Input.GetKeyDown(KeyCode.E))
        {
            textBoxManager.ReloadScript(dialogueTextFile);
            textBoxManager.currentLine = startingPoint;
            textBoxManager.endAtLine = endPoint;
            textBoxManager.EnableTextBox();

            if (destroyWhenActivated)
            {
                Destroy(gameObject);
            }
        }
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "PlayerTestModelV2")
        {
            if (requieredButtonPress)
            {
                waitForPress = true;
                return;
            }

            textBoxManager.ReloadScript(dialogueTextFile);
            textBoxManager.currentLine = startingPoint;
            textBoxManager.endAtLine = endPoint;
            textBoxManager.EnableTextBox();

            if (destroyWhenActivated)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if(coll.name == "PlayerTestModelV2")
        {
            waitForPress = false;
        }
    }
}
