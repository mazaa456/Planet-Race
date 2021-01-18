using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMid : MonoBehaviour
{
    public static bool m;
    public static bool m2;
    public static bool m3;
    public static bool m4;
    // Start is called before the first frame update
    void Start()
    {
        m=false;
        m2=false;
        m3=false;
        m4=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
      if (other.tag == "Player1")
        {
            m=true;
        }
      if (other.tag == "Player2")
      {
          m2=true;
      }
      if (other.tag == "Player3")
      {
          m3=true;
      }
      if (other.tag == "Player4")
      {
          m4=true;
      }
    
    }
}
