using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsSlider : MonoBehaviour
{
    public TextMeshProUGUI text;

    private Slider _slider;
    
    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    public void UpdateText()
    {
        if (_slider != null)
        {
            float value = _slider.value;
            text.text = value.ToString();
        }
    }
}
