using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressManager : MonoBehaviour
{
    public GameObject progressSection;
    public GameObject progressBar;
    public int currentSlot;
    public int endAtSlot;
    public float panelMinAnchor;
    public float panelMaxAnchor;
    public float panelAnchorIncrement;
    public float activityTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentSlot = 0;
        endAtSlot = 10;
        panelAnchorIncrement = (float)1/endAtSlot;
        panelMinAnchor = 0f;
        panelMaxAnchor = panelAnchorIncrement;
        int loopCounter = 0;
        while(loopCounter<endAtSlot){
            /*
            GameObject panel = new GameObject("Panel");
            panel.AddComponent<CanvasRenderer>();

            Image i = panel.AddComponent<Image>();
            if(loopCounter%2==0){
                i.color = Color.red;
            }else{
                i.color = Color.green;
            }
            */
            GameObject newPS = Instantiate(progressSection, progressBar.transform);
            
            RectTransform prt = newPS.GetComponent<RectTransform>();

            prt.offsetMin = new Vector2(0, 0); //left, top
            prt.offsetMax = new Vector2(0, 14); //right, bottom
            //prt.sizeDelta = new Vector2(prt.sizeDelta.x, progressBar.GetComponent<RectTransform>().rect.size.y);
            prt.anchorMin = new Vector2(panelMinAnchor,0);
            prt.anchorMax = new Vector2(panelMaxAnchor,0);
            
            panelMinAnchor+=panelAnchorIncrement;
            panelMaxAnchor+=panelAnchorIncrement;

            loopCounter+=1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        activityTimer += Time.deltaTime;
        if (activityTimer >= 5.0f) {
            currentSlot+=1;
            activityTimer = 0.0f;
        }
    }
}
