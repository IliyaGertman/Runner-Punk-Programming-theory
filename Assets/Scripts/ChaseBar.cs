using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChaseBar : MonoBehaviour
{
    public Slider slider;

    public void SetMinChase(float chase)
    {
        slider.minValue = chase;
        slider.value = chase; 
    }
    public void SetChase(float chase)

    {
        slider.value = chase;
    }    
        
    
}
