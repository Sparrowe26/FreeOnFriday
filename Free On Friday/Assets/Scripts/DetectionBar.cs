using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectionBar : MonoBehaviour
{ 
    Slider _detectionSlider;

    private void Start()
    {
        _detectionSlider = GetComponent<Slider>();
    }

    public void SetDetectionMax(int maxAmount)
    {
        _detectionSlider.maxValue = maxAmount;
    }

    public void SetDetection(int startAmount)
    {
        _detectionSlider.value = startAmount;
    }
}
