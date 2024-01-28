using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    [Range(0,1  )]
    public float progress = 0;
    public GameObject bar;
    private float barMaxWidthPx;

    // Start is called before the first frame update
    void Start()
    {
        barMaxWidthPx = GetComponent<RectTransform>().sizeDelta.x;
    }

    // Update is called once per frame
    void Update()
    {
        RectTransform barRectTransform = bar.GetComponent<RectTransform>();
        float barWidth = progress * barMaxWidthPx;
        barRectTransform.sizeDelta = new Vector2(barWidth, barRectTransform.sizeDelta.y);
    }
    public void updateProgress(float value) {
        progress = value;
    }
}
