using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using Enums;
using ScriptableObjects;
using UnityEngine.UI;


public class SectionWindow : MonoBehaviour
{
    public SelectionManager selectionManager;
    public EActivityTypes sectionType = EActivityTypes.None;
    public ShowActivity[] sectionShowActivities; //Cargar de un diccionario / archivo y luego comprobar valor de reputacion para mostrarlo o no
    public TMP_Text windowTitle;
    public GameObject showActivitUIPrefab;
    public GameObject activitiesList;
    void Start()
    {
        
    }
    
    public void changeWindowType(EActivityTypes type) {
        sectionType = type;
        windowTitle.text = sectionType.ToString();
        Debug.Log(selectionManager.availableShowElements);
        sectionShowActivities = selectionManager.availableShowElements.Where(showActivity => showActivity.type == sectionType).ToArray();
        //Añadir filtro para reputacion

        foreach (Transform child in activitiesList.transform) {
            GameObject.Destroy(child.gameObject);
        }

        foreach(ShowActivity activity in sectionShowActivities)
        {
            if(activity.available){
                var instance = Instantiate(showActivitUIPrefab, activitiesList.transform);
                ShowElementUI newShowElement = instance.GetComponent<ShowElementUI>();
                newShowElement.activityName = activity.activityName;
                newShowElement.activityType = activity.type;
                newShowElement.money = activity.moneyCost;
                newShowElement.reputation = activity.neededReputation;
                newShowElement.laughs = activity.laughPoints;
                Button button = instance.GetComponent<Button>();
                button.interactable = true;
                button.onClick.AddListener(delegate{selectionManager.selectActivity(activity);});
            }

        }
    }
}
