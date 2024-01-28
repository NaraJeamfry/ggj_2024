using System.Collections;
using System.Collections.Generic;
using Enums;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

public class ShowImageController : MonoBehaviour
{
    public ShowActivity activity;
    public GameObject displayedImage;
    // Start is called before the first frame update
    void Start()
    {
        changeActivityType(activity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeActivityType(ShowActivity newActivity) {
        activity = newActivity;
        changeImageByShowActivity(activity);
    }

    public void changeImageByShowActivity(ShowActivity showActivity) {
        switch(showActivity.type){
            case EActivityTypes.Invitado:
                displayedImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Night/entrevistado");
                break;
            case EActivityTypes.Seccion:
                displayedImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Night/comediante");
                break;
        }
    }
}
