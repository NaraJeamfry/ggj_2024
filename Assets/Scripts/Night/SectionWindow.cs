using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SectionWindow : MonoBehaviour
{
    public ShowActivity[] sectionShowActivities; //Cargar de un diccionario / archivo
    public TMP_Text windowTitle;
    public GameObject showElementPrefab;
    void Start()
    {
        foreach(ShowActivity activity in sectionShowActivities)
        {
            ShowElementUI newSection = showElementPrefab.GetComponent<ShowElementUI>();
            newSection.title = type.ToString();
            var instance = Instantiate(newSection, new Vector3(0, 0, 0), Quaternion.identity);
            instance.transform.parent = gameObject.transform;

        }
    }

    void Update()
    {
        
    }
}
