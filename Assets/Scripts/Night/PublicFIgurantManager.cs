using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;
using Night;

public class PublicFIgurantManager : MonoBehaviour
{
    public GameSettings gameSettings;
    public GameObject PublicFigurant_ph;
    public GameObject figurantPrefab;
    // Start is called before the first frame update
    void Start()
    {
        NightPreview result = Managers.RoundInitializer.GenerateRound(0, gameSettings);
        int resultIndex = 0;
        foreach(Transform placeHolder in PublicFigurant_ph.transform){
            GameObject figurant = Instantiate(figurantPrefab,placeHolder);
            SpriteRenderer f_SpriteRenderer = figurant.GetComponent<SpriteRenderer>();
            f_SpriteRenderer.sprite = result.audience[resultIndex].person;
            resultIndex++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
