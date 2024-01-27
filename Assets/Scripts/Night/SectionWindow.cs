using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;


public class SectionWindow : MonoBehaviour
{
    public SelectionManager selectionManager;
    public EActivityTypes sectionType = EActivityTypes.none;
    public ShowActivity[] sectionShowActivities; //Cargar de un diccionario / archivo y luego comprobar valor de reputacion para mostrarlo o no
    public TMP_Text windowTitle;
    public GameObject showElementPrefab;
    public GameObject activitiesList;
    void Start()
    {
        
    }
    
    public void changeWindowType(EActivityTypes type) {
        sectionType = type;
        windowTitle.text = sectionType.ToString();
        sectionShowActivities = selectionManager.availableShowElements.Where(showElement => showElement.type == sectionType).ToArray();
        //Añadir filtro para reputacion

        foreach (Transform child in activitiesList.transform) {
            GameObject.Destroy(child.gameObject);
        }

        foreach(ShowActivity activity in sectionShowActivities)
        {
            if(activity.available){
                var instance = Instantiate(showElementPrefab, activitiesList.transform);
                ShowElementUI newShowElement = instance.GetComponent<ShowElementUI>();
                newShowElement.activityName = activity.name.ToString();
                newShowElement.activityType = activity.type;
                newShowElement.money = activity.moneyCost;
                newShowElement.reputation = activity.neededReputation;
                newShowElement.laughs = activity.laughPoints;
            }

        }
    }
}
