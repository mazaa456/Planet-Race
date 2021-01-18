using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelected : MonoBehaviour
{
    CharacterSelection characterSelection=new CharacterSelection();
    public GameObject[] cars;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag=="Player1")
        {
            if (CharacterSelection.allReady == true)
            {
                for (int i = 0; i < 4; i++)
                {
                    cars[i].SetActive(false);
                    if (i == CharacterSelection.selectedCharacter)
                    {
                        cars[i].SetActive(true);
                    }
                }
            }
        }
        if (gameObject.tag == "Player2")
        {
            if (CharacterSelection.allReady == true)
            {
                for (int i = 0; i < 4; i++)
                {
                    cars[i].SetActive(false);
                    if (i == CharacterSelection.selectedCharacter2)
                    {
                        cars[i].SetActive(true);
                    }
                }
            }
        }
        if (gameObject.tag == "Player3")
        {
            if (CharacterSelection.allReady == true)
            {
                for (int i = 0; i < 4; i++)
                {
                    cars[i].SetActive(false);
                    if (i == CharacterSelection.selectedCharacter3)
                    {
                        cars[i].SetActive(true);
                    }
                }
            }
        }
        if (gameObject.tag == "Player4")
        {
            if (CharacterSelection.allReady == true)
            {
                for (int i = 0; i < 4; i++)
                {
                    cars[i].SetActive(false);
                    if (i == CharacterSelection.selectedCharacter4)
                    {
                        cars[i].SetActive(true);
                    }
                }
            }
        }


    }
}
