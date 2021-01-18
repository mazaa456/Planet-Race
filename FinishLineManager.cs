using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
      if (other.tag == "Player1"&&CheckMid.m==true)
        {
            LapManager.Lap++;
            Debug.Log("Lap: " + LapManager.Lap);
            CheckMid.m=false;

        }
    if (other.tag == "Player2"&&CheckMid.m2==true)
        {
            LapManager.Lap2++;
            Debug.Log("Lap2: " + LapManager2.Lap2);
            CheckMid.m2=false;
        }
    if (other.tag == "Player3"&&CheckMid.m3==true)
        {
            LapManager.Lap3++;
            Debug.Log("Lap2: " + LapManager3.Lap2);
            CheckMid.m3=false;
        }
    if (other.tag == "Player4"&&CheckMid.m3==true)
        {
            LapManager.Lap4++;
            Debug.Log("Lap2: " + LapManager3.Lap2);
            CheckMid.m4=false;
        }
    }
}
