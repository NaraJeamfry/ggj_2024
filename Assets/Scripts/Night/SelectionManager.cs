using System.Collections.Generic;
using Managers;
using Night;
using ScriptableObjects;
using UnityEngine;
using TMPro;


public class SelectionManager : MonoBehaviour
{
    public TMP_Text moneyText;
    public TMP_Text energyText;
    public TMP_Text reputationText;
    public int yesterdayLaughPoints = 0;
    public ShowTheme theme;
    public TMP_Text themeUI;
    public ShowActivity[] availableShowElements;
    public List<ShowActivity> selectedShowActivities;
    public GameObject[] ActivitySlots;
    public GameObject[] ActivityXs;

    public GameObject showActivitUIPrefab;

    private GameManager _gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameManager.Instance;
    }

    public void StartPreparing()
    {
        moneyText.text = $"{_gameManager.money}";
        reputationText.text = $"{_gameManager.renown}";
        themeUI.text = $"{_gameManager.preview.extraTheme}";

        for(int i = 0; i < ActivitySlots.Length; i++){
            if(i >= _gameManager.gameSettings.maxActivities){
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

    public void FinishPreparing()
    {
        NightState nightState = new()
        {
            preview = _gameManager.preview,
            showActivities = selectedShowActivities.ToArray()
        };

        _gameManager.FinishPreparing(nightState);
    }

    public void selectActivity(ShowActivity activity) {
        selectedShowActivities.Add(activity);
        Debug.Log(selectedShowActivities.Count - 1);
        GameObject activitySlot = ActivitySlots[selectedShowActivities.Count - 1];
        var instance = Instantiate(showActivitUIPrefab, activitySlot.transform);
        ShowElementUI newShowElement = instance.GetComponent<ShowElementUI>();
        newShowElement.activityName = activity.activityName;
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
            for(int i = slot + 1; i < selectedShowActivities.Count+1; i++) {
                ActivitySlots[i].transform.GetChild(0).SetParent(ActivitySlots[i-1].transform);
            }
        }
    }
}
