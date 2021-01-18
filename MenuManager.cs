using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject BackB;
    public GameObject selectionChar;
    public GameObject selectionMap;
    public static int NumOfPlayer;
    public GameObject NumButton;
    public GameObject NumButton2;
    public GameObject NumButton3;
    public GameObject MapButton1;
    public GameObject MapButton2;
    public GameObject MapButton3;
    public GameObject[] charactersL;
    public GameObject[] ButtonL;
    public GameObject[] ReadyButton;
    public GameObject m;
    public CharacterSelection characterSelection=new CharacterSelection();
    private void Awake()
    {
        NumOfPlayer = 0;
    }
    private void Update()
    {
        if (NumOfPlayer!=0)
        {
            NumButton.SetActive(false);
            NumButton2.SetActive(false);
            NumButton3.SetActive(false);
            for (int i = 0; i < NumOfPlayer; i++)
            {
                charactersL[i].SetActive(true);
                ButtonL[i].SetActive(true);
                ReadyButton[i].SetActive(true);
            }
            Debug.Log(NumOfPlayer);
        }
        if (CharacterSelection.allReady==true)
        {
            for (int i = 0; i < NumOfPlayer; i++)
            {
                charactersL[i].SetActive(false);
                ButtonL[i].SetActive(false);
                ReadyButton[i].SetActive(false);
            }
            MapButton1.SetActive(true);
            MapButton2.SetActive(true);
            MapButton3.SetActive(true);
        }
        if (selectionChar.activeInHierarchy==true||selectionMap.activeInHierarchy==true)
        {
            BackB.SetActive(true);
        }
        else
        {
            BackB.SetActive(false);
        }


    }
    // Start is called before the first frame update
    public void OnMainMenu()
    {
        SceneManager.LoadScene("Menustart", LoadSceneMode.Single);
    }
    public void OnSelectMode()
    {
        ClearValue();
        SceneManager.LoadScene("Menustart 1", LoadSceneMode.Single);
    }
    public void OnSelectMode2P()
    {
        NumOfPlayer = 2;
        //ClearValue();
        //SceneManager.LoadScene("2", LoadSceneMode.Single);
    }
    public void OnSelectMode3P()
    {
        NumOfPlayer = 3;
        //ClearValue();
        //SceneManager.LoadScene("3", LoadSceneMode.Single);
    }
    public void OnSelectMode4P()
    {
        NumOfPlayer = 4;              
        //ClearValue();
        //SceneManager.LoadScene("4", LoadSceneMode.Single);
    }
    public void OnSelectMap1()
    {
        if (NumOfPlayer==2)
        {
            ClearValue();
            SceneManager.LoadScene("1.2", LoadSceneMode.Single);
        }
        else if (NumOfPlayer == 3)
        {
            ClearValue();
            SceneManager.LoadScene("1.3", LoadSceneMode.Single);
        }
        else if (NumOfPlayer == 4)
        {
            ClearValue();
            SceneManager.LoadScene("1.4", LoadSceneMode.Single);
        }
    }
    public void OnSelectMap2()
    {
        if (NumOfPlayer == 2)
        {
            ClearValue();
            SceneManager.LoadScene("2.2", LoadSceneMode.Single);
        }
        else if (NumOfPlayer == 3)
        {
            ClearValue();
            SceneManager.LoadScene("2.3", LoadSceneMode.Single);
        }
        else if (NumOfPlayer == 4)
        {
            ClearValue();
            SceneManager.LoadScene("2.4", LoadSceneMode.Single);
        }
    }
    public void OnSelectMap3()
    {
        if (NumOfPlayer == 2)
        {
            ClearValue();
            SceneManager.LoadScene("3.2", LoadSceneMode.Single);
        }
        else if (NumOfPlayer == 3)
        {
            ClearValue();
            SceneManager.LoadScene("3.3", LoadSceneMode.Single);
        }
        else if (NumOfPlayer == 4)
        {
            ClearValue();
            SceneManager.LoadScene("3.4", LoadSceneMode.Single);
        }
    }

    public void OnExit()
    {
        Application.Quit();
    }

    public void OnResume()
    {
        Time.timeScale=1;
        m.SetActive(false);     
    }

    public void ClearValue()
    {
        HoverCarControl.aclAxis=0f;
        HoverCarControl.turnAxis=0f;
        HoverCarControl2.aclAxis=0f;
        HoverCarControl2.turnAxis=0f;
        HoverCarControl3.aclAxis=0f;
        HoverCarControl3.turnAxis=0f;
        HoverCarControl4.aclAxis=0f;
        HoverCarControl4.turnAxis=0f;
        CheckMid.m=false;
        CheckMid.m2=false;
        CheckMid.m3=false;
        CheckMid.m4=false;
        LapManager.Lap=1;
        LapManager.Lap2=1;
        LapManager.Lap3=1;
        LapManager.Lap4=1;
        PosManager.pos1=2;
        PosManager.pos2=1;
        PosManager.pos3=3;
        PosManager.pos4=4;
        TimeManager.timeValue=0f;
    }

    public void OnBack()
    {
        if (selectionChar.activeInHierarchy==true)
        {
            ClearValue1();
            for (int i = 0; i < NumOfPlayer; i++)
            {
                charactersL[i].SetActive(false);
                ButtonL[i].SetActive(false);
                ReadyButton[i].SetActive(false);
            }
            NumOfPlayer = 0;
            NumButton.SetActive(true);
            NumButton2.SetActive(true);
            NumButton3.SetActive(true);
            MapButton1.SetActive(false);
            MapButton2.SetActive(false);
        }
        if(selectionMap.activeInHierarchy==true)
        {
            ClearValue1();
            MapButton1.SetActive(false);
            MapButton2.SetActive(false);
            MapButton3.SetActive(true);

            for (int i = 0; i < NumOfPlayer; i++)
            {
                charactersL[i].SetActive(true);
                ButtonL[i].SetActive(true);
                ReadyButton[i].SetActive(true);
            }
        }
    }
    public void ClearValue1()
    {
        //CharacterSelection.canselect = 25f;
        CharacterSelection.canAllRaedy = false;
        CharacterSelection.p1Ready = false;
        CharacterSelection.p2Ready = false;
        CharacterSelection.p3Ready = false;
        CharacterSelection.p4Ready = false;
        CharacterSelection.allReady = false;
        for (int i = 0; i < 4; i++)
        {
            CharacterSelection.Ready[i] = false;
            CharacterSelection.CountReady[i] = false;
        }
        CharacterSelection.selected = false;
        CharacterSelection.NumOfReady = 0;
        Debug.Log("MMMMMMMMMMM");
    }

    public void LoadMap12()
    {
        SceneManager.LoadScene("1.2", LoadSceneMode.Single);
    }

    public void LoadMap13()
    {
        SceneManager.LoadScene("1.3", LoadSceneMode.Single);
    }

    public void LoadMap14()
    {
        SceneManager.LoadScene("1.4", LoadSceneMode.Single);
    }

    public void LoadMap22()
    {
        SceneManager.LoadScene("2.2", LoadSceneMode.Single);
    }

    public void LoadMap23()
    {
        SceneManager.LoadScene("2.3", LoadSceneMode.Single);
    }

    public void LoadMap24()
    {
        SceneManager.LoadScene("2.4", LoadSceneMode.Single);
    }

    public void LoadMap32()
    {
        SceneManager.LoadScene("3.2", LoadSceneMode.Single);
    }

    public void LoadMap33()
    {
        SceneManager.LoadScene("3.3", LoadSceneMode.Single);
    }

    public void LoadMap34()
    {
        SceneManager.LoadScene("3.4", LoadSceneMode.Single);
    }
}
