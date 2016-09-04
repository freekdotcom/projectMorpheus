using UnityEngine;
using System.Collections;

public class TextImportManager : MonoBehaviour {

    public TextAsset textFile;
    public string[] textLines;

	// Use this for initialization
	void Start () {

        //checks if the file exists
	    if(textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }
	}
	

}
