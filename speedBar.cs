using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class speedBar : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = 270f;
        slider.value=0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SetSpeed(float speed)
    {
        slider.value = speed;
    }
}
