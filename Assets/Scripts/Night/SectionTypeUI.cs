using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SectionTypeUI : MonoBehaviour
{
    public string title = "Section";
    public TMP_Text titleUI;
    void Start()
    {
        titleUI.text = title;
    }
}
