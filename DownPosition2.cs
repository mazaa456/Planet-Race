using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownPosition2 : MonoBehaviour
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
            if(PosManager.pos1>PosManager.pos3&&LapManager.Lap==LapManager.Lap3)
            {

                int temp = PosManager.pos1;
                PosManager.pos1 = PosManager.pos3;
                PosManager.pos3 = temp;
            }
        }
    }
}
