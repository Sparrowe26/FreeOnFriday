using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection
{
    //Fields
    int _currentDetection;
    int _currentMaxDetection;
    
    //Properties
    public int Detect
    {
        get
        {
            return _currentDetection;
        }
        set
        {
            _currentDetection = value;
        }
    }
    
    public int MaxDetection
    {
        get
        {
            return _currentMaxDetection;
        }
        set
        {
            _currentMaxDetection = value;
        }
    }
    
    // Constructor
    public Detection(int detection, int maxDetection)
    {
        _currentDetection = detection;
        _currentMaxDetection = maxDetection;
    }
    
    // Methods
    public void DectectionUnit(int amount)
    {
        if (_currentDetection < _currentMaxDetection)
        {
            _currentDetection += amount;
        }

        if (_currentDetection > _currentMaxDetection)
        {
            _currentDetection = _currentMaxDetection;
        }
    }
    

}
