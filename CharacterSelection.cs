using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    
    public GameObject[] characters;
    public GameObject[] characters2;
    public GameObject[] characters3;
    public GameObject[] characters4;
    public GameObject[] ReadyText;
    public static int selectedCharacter = 0;
    public static int selectedCharacter2 = 0;
    public static int selectedCharacter3 = 0;
    public static int selectedCharacter4 = 0;
    public static bool p1Ready;
    public static bool p2Ready;
    public static bool p3Ready;
    public static bool p4Ready;
    public static bool allReady;
    public static bool[] Ready = { false, false, false, false };
    public static bool[] CountReady = { false, false, false, false };
    public static bool canAllRaedy=false;
    public static float canselect;
    public static bool selected=false;
    public static int NumOfReady = 0;
    private void Awake()
    {
        canselect = 25f;
        p1Ready = false;
        p2Ready = false;
        p3Ready = false;
        p4Ready = false;
        allReady = false;
    }
    public void Next()
    {
        if (canselect>=25&&p1Ready==false)
        {
            canselect = 0f;
            characters[selectedCharacter].SetActive(false);
            selectedCharacter = (selectedCharacter + 1) % characters.Length;
            characters[selectedCharacter].SetActive(true);
        }
    }
    public void Next2()
    {
        if (canselect >= 25 && p2Ready == false)
        {
            canselect = 0f;
            characters2[selectedCharacter2].SetActive(false);
            selectedCharacter2 = (selectedCharacter2 + 1) % characters2.Length;
            characters2[selectedCharacter2].SetActive(true);
        }
    }
    public void Next3()
    {
        if (canselect >= 25 && p3Ready == false)
        {
            canselect = 0f;
            characters3[selectedCharacter3].SetActive(false);
            selectedCharacter3 = (selectedCharacter3 + 1) % characters3.Length;
            characters3[selectedCharacter3].SetActive(true);
        } 
    }
    public void Next4()
    {

        if (canselect >= 25 && p4Ready == false)
        {
            canselect = 0f;
            characters4[selectedCharacter4].SetActive(false);
            selectedCharacter4 = (selectedCharacter4 + 1) % characters4.Length;
            characters4[selectedCharacter4].SetActive(true);
        }
    }

    public void Previous()
    {
        if (canselect >= 25 && p1Ready == false)
        {
            canselect = 0f;
            characters[selectedCharacter].SetActive(false);
            selectedCharacter--;
            if (selectedCharacter < 0)
            {
                selectedCharacter += characters.Length;
            }
            characters[selectedCharacter].SetActive(true);
            Debug.Log("Nooooooooooooooo");
        }
    }
    public void Previous2()
    {
        if (canselect >= 25 && p2Ready == false)
        {
            canselect = 0f;
            characters2[selectedCharacter2].SetActive(false);
            selectedCharacter2--;
            if (selectedCharacter2 < 0)
            {
                selectedCharacter2 += characters2.Length;
            }
            characters2[selectedCharacter2].SetActive(true);
        }
    }
    public void Previous3()
    {
        if (canselect >= 25 && p3Ready == false)
        {
            canselect = 0f;
            characters3[selectedCharacter3].SetActive(false);
            selectedCharacter3--;
            if (selectedCharacter3 < 0)
            {
                selectedCharacter3 += characters3.Length;
            }
            characters3[selectedCharacter3].SetActive(true);
        }
    }
    public void Previous4()
    {
        if (canselect >= 25 && p4Ready == false)
        {
            canselect = 0f;
            characters4[selectedCharacter4].SetActive(false);
            selectedCharacter4--;
            if (selectedCharacter4 < 0)
            {
                selectedCharacter4 += characters4.Length;
            }
            characters4[selectedCharacter4].SetActive(true);
        }
    }
    public void Ready1()
    {
        Ready[0] = true;
        Debug.Log(MenuManager.NumOfPlayer);
        Debug.Log(NumOfReady);
    }
    public void Ready2()
    {
        Ready[1] = true;
        Debug.Log(MenuManager.NumOfPlayer);
        Debug.Log(NumOfReady);
    }
    public void Ready3()
    {
        Ready[2] = true;
        Debug.Log(MenuManager.NumOfPlayer);
        Debug.Log(NumOfReady);
    }
    public void Ready4()
    {
        Ready[3] = true;
        Debug.Log(MenuManager.NumOfPlayer);
        Debug.Log(NumOfReady);
    }
    public void ClearChar()
    {
        canselect = 25f;
        p1Ready = false;
        p2Ready = false;
        p3Ready = false;
        p4Ready = false;
    }
    private void FixedUpdate()
    {
        if(canselect<25f)
        {
            canselect++;
        }
    }
    private void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            ReadyText[i].SetActive(Ready[i]);
        }
        /*if (Ready[0] == true)
        {
            ReadyText[0].SetActive(true);
        }
        if (Ready[1] == true)
        {
            ReadyText[1].SetActive(true);
        }
        if (Ready[2] == true)
        {
            ReadyText[2].SetActive(true);
        }
        if (Ready[3] == true)
        {
            ReadyText[3].SetActive(true);
        }*/
        if (NumOfReady!= MenuManager.NumOfPlayer)
        {
            for (int i = 0; i < MenuManager.NumOfPlayer; i++)
            {
                if (Ready[i] == true&&CountReady[i]==false)
                {
                    NumOfReady++;
                    CountReady[i] = true;
                    canAllRaedy = true;
                }
            }
        }
        
        else if (NumOfReady== MenuManager.NumOfPlayer&&canAllRaedy==true)
        {
            allReady = true;
        }
        /*if(me)
        {
            allReady = true;
        }*/
        
        if (allReady==true)
        {
            for (int i = 0; i < 4; i++)
            {
                ReadyText[i].SetActive(false);
            }
        }
    }
    
}
