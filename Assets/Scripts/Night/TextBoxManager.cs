using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TextBoxManager : MonoBehaviour
{
    public GameObject textBox;
    public TMP_Text resultText;
    public TextAsset textFile;
    public string[] textLines;
    public int currentLine;
    public int endAtLine;
    public int currentChars;
    public int totalChars;
    float lineProgress;
    public float activityTimer = 0;


    // Start is called before the first frame update
    void Start()
    {
        if(textFile != null){
            textLines = (textFile.text.Split('\n'));
        }
        endAtLine = textLines.Length - 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentLine > endAtLine){
            textBox.SetActive(false);
            return;
        }
        totalChars = textLines[currentLine].Length;
        activityTimer += Time.deltaTime;
        lineProgress = Math.Min(1,activityTimer/4.0f);
        currentChars = (int)Math.Ceiling(totalChars*lineProgress);
        resultText.text = textLines[currentLine];
        resultText.text = resultText.text.Substring(0, currentChars);
        if (activityTimer >= 5.0f) {
            currentLine+=1;
            activityTimer = 0.0f;
        }
    }
}
