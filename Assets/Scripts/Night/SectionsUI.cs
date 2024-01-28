using System;
using System.Collections;
using System.Collections.Generic;
using Enums;
using UnityEngine;
using UnityEngine.UI;

public class SectionsUI : MonoBehaviour
{
    public GameObject SectionUIObject;
    public GameObject sectionWindow;
    void Start()
    {
        foreach(EActivityTypes type in Enum.GetValues(typeof(EActivityTypes)))
        {
            if(type != EActivityTypes.None) {
                SectionTypeUI newSection = SectionUIObject.GetComponent<SectionTypeUI>();
                newSection.title = type.ToString();
                newSection.type = type;
                var instance = Instantiate(newSection, gameObject.transform);
            }

        }
    }

    public void openSectionWindow(EActivityTypes sectionType) {
        sectionWindow.GetComponent<SectionWindow>().changeWindowType(sectionType);
        sectionWindow.SetActive(true);
    }
}
