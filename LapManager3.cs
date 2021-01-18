using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapManager3 : MonoBehaviour
{
    public static int Lap2;
    // Start is called before the first frame update
    void Start()
    {
        Lap2=0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Lap2<=3)
            GetComponent<Text>().text = "Lap : " + Lap2 + " / 3";
        else
            GetComponent<Text>().text = "Finish";

        
    }
}
