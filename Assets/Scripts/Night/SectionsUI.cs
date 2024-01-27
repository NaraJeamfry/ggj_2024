using System;
using System.Collections;
using System.Collections.Generic;
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
            if(type != EActivityTypes.none) {
                SectionTypeUI newSection = SectionUIObject.GetComponent<SectionTypeUI>();
                newSection.title = type.ToString();
                newSection.type = type;
                var instance = Instantiate(newSection, new Vector3(0, 0, 0), Quaternion.identity);
                instance.transform.parent = gameObject.transform;
            }

        }
    }

    public void openSectionWindow(EActivityTypes sectionType) {
        sectionWindow.GetComponent<SectionWindow>().changeWindowType(sectionType);
        sectionWindow.SetActive(true);
    }
}
