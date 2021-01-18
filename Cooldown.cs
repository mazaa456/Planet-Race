using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooldown : MonoBehaviour
{
    //public GameObject par;
    //public Renderer rend;
    Collider m_Collider;
    public float timedown = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        //rend = GetComponent<Renderer>();
        m_Collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timedown <= 0)
        {
            //rend.enabled = true;
            for (int a = 0; a < transform.childCount; a++)
            {
                transform.GetChild(a).gameObject.SetActive(true);
            }
            m_Collider.enabled = true;
        }
        //par.SetActive(rend.enabled);
    }
    void FixedUpdate()
    {
        if (timedown > 0.0f)
        {
            timedown -= 0.02f;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2" || other.gameObject.tag == "Player3" || other.gameObject.tag == "Player4")
        {
            timedown = 10.0f;
            for (int a = 0; a < transform.childCount; a++)
            {
                transform.GetChild(a).gameObject.SetActive(false);
            }
            m_Collider.enabled = false;
        }
    }
}