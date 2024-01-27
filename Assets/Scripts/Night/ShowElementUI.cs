using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShowElementUI : MonoBehaviour
{
    public Sprite activityImage;
    public GameObject activityImageUI;
    public string activityName = "blank";
    public TMP_Text activityNameUI;
    public EActivityTypes activityType = EActivityTypes.none;
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

    public Color TypeColor(EActivityTypes type){
        switch(type) {
            case EActivityTypes.seccion: 
                return Color.red;
            case EActivityTypes.invitado: 
                return Color.blue;
            case EActivityTypes.invitadoMusical: 
                return Color.yellow;
            case EActivityTypes.chiste: 
                return Color.green;
            default: 
                return Color.white;
        }
    }
}
