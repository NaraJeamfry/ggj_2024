using System.Collections;
using System.Collections.Generic;
using Enums;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShowElementUI : MonoBehaviour
{
    public Sprite activityImage;
    public GameObject activityImageUI;
    public string activityName = "blank";
    public TMP_Text activityNameUI;
    public EActivityTypes activityType = EActivityTypes.None;
    public int money = 10;
    public TMP_Text moneyUI;
    public int reputation = 10;
    public TMP_Text reputationUI;
    public int laughs = 10;
    public TMP_Text laughsUI;

    private void Start() {
        activityImageUI.GetComponent<Image>().sprite = activityImage;
        GetComponent<Image>().color = TypeColor(activityType);
        activityNameUI.text = activityName;
        moneyUI.text = money.ToString();
        reputationUI.text = reputation.ToString();
        laughsUI.text = laughs.ToString();
    }

    private static Color TypeColor(EActivityTypes type){
        switch(type) {
            case EActivityTypes.Seccion: 
                return Color.red;
            case EActivityTypes.Invitado: 
                return Color.blue;
            case EActivityTypes.InvitadoMusical: 
                return Color.yellow; 
            case EActivityTypes.Chiste: 
                return Color.green;
            default: 
                return Color.white;
        }
    }
}
