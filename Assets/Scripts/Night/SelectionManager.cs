using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using TMPro;

public enum EActivityTypes {
    none,
    chiste,
    invitado,
    invitadoMusical,
    seccion

}

[System.Serializable]
public class ShowActivity {
    public string name = "";
    public EActivityTypes type = EActivityTypes.none;
    public int moneyCost = 0;
    public int energyCost = 0;
    public int neededReputation = 0;
    public int laughPoints = 0;
    public bool available = true;
}

public class SelectionManager : MonoBehaviour
{
    public int money = 1000;
    public TMP_Text moneyText;
    public int energy = 20;
    public TMP_Text energyText;
    public int reputation = 0;
    public TMP_Text reputationText;
    public int yesterdayLaughPoints = 0;
    public string theme;
    public TMP_Text themeUI;
    public ShowActivity[] availableShowElements;
    public List<ShowActivity> selectedShowActivities;
    public int maxShowActivities;
    public GameObject[] ActivitySlots;
    public GameObject[] ActivityXs;

    public GameObject showActivitUIPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        moneyText.text = money.ToString();
        energyText.text = energy.ToString();
        reputationText.text = reputation.ToString();
        themeUI.text = theme;

        for(int i = 0; i < ActivitySlots.Length-1; i++){
            if(i > maxShowActivities){
                ActivitySlots[i].SetActive(false);
                ActivityXs[i].SetActive(false);
            } else {
                //idk, maybe we don't need this, whatever. I don't have time to find out.
                ActivitySlots[i].SetActive(true);
                ActivityXs[i].SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void selectActivity(ShowActivity activity) {
        selectedShowActivities.Add(activity);
        GameObject activitySlot = ActivitySlots[selectedShowActivities.Count - 1];
        var instance = Instantiate(showActivitUIPrefab, activitySlot.transform);
        ShowElementUI newShowElement = instance.GetComponent<ShowElementUI>();
        newShowElement.activityName = activity.name.ToString();
        newShowElement.activityType = activity.type;
        newShowElement.money = activity.moneyCost;
        newShowElement.reputation = activity.neededReputation;
        newShowElement.laughs = activity.laughPoints;
    }

    //DOESN'T WORK!!! Gotta fix aaa
    public void removeActivity(int slot){
        Debug.Log(slot);
        selectedShowActivities.RemoveAt(slot);
        foreach (Transform child in ActivitySlots[slot].transform) {
            GameObject.Destroy(child.gameObject);
        }

        //Reorganize
        Debug.Log(selectedShowActivities.Count);
        if(slot != selectedShowActivities.Count) {
            for(int i = slot + 1; i < selectedShowActivities.Count; i++){
                selectedShowActivities[i-1] = selectedShowActivities[i];
                ActivitySlots[i].transform.GetChild(0).SetParent(ActivitySlots[i-1].transform);
            }
            foreach (Transform child in ActivitySlots[selectedShowActivities.Count].transform) {
                GameObject.Destroy(child.gameObject);
            }
            selectedShowActivities.RemoveAt(selectedShowActivities.Count);
        }
    }
}
