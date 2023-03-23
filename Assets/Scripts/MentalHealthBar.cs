using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MentalHealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxValue(int value)
    {
        value = 100;
        slider.maxValue = value;
        slider.value = value;
        
        fill.color = gradient.Evaluate(1f);

    }

    // Start is called before the first frame update

    public void SetValue(int Mhealth)
    {
        slider.value = Mhealth;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }


}
