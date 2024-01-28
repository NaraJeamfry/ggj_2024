using System.Collections;
using System.Collections.Generic;
using Enums;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SectionTypeUI : MonoBehaviour
{
    public string title = "Section";
    public EActivityTypes type;
    public TMP_Text titleUI;
    void Awake()
    {
        titleUI.text = title;
        Button button = GetComponent<Button>();
        button.onClick.AddListener ((UnityEngine.Events.UnityAction) this.OnClick);
    }
    public void OnClick(){
        GameObject parent = transform.parent.gameObject;
        if(parent.GetComponent<SectionsUI>()){
            parent.GetComponent<SectionsUI>().openSectionWindow(type);
        } else {
            Debug.LogError("This button must be a children of an element with a SectionsUI component");
        }
    }
}
