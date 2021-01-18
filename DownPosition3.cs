using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownPosition3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerExit (Collider m)
    {
        if(m.tag=="Player1")
        {
            if(PosManager.pos1>PosManager.pos4&&LapManager.Lap==LapManager.Lap4)
            {

                int temp = PosManager.pos1;
                PosManager.pos1 = PosManager.pos4;
                PosManager.pos4 = temp;
            }
        }
        if(m.tag=="Player3")
        {
            if(PosManager.pos3>PosManager.pos4&&LapManager.Lap3==LapManager.Lap4)
            {

                int temp = PosManager.pos3;
                PosManager.pos3 = PosManager.pos4;
                PosManager.pos4 = temp;
            }
        }
        if(m.tag=="Player2")
        {
            if(PosManager.pos2>PosManager.pos4&&LapManager.Lap2==LapManager.Lap4)
            {

                int temp = PosManager.pos4;
                PosManager.pos4 = PosManager.pos2;
                PosManager.pos2 = temp;
            }
        }
    }
}
