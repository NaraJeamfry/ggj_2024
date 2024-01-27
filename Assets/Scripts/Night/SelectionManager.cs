using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

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
    public int energy = 20;
    public int reputation = 0;
    public int yesterdayLaughPoints = 0;
    public ShowActivity[] availableShowElements;
    public ShowActivity[] selectedShowElements;
    public int maxShowElements;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
