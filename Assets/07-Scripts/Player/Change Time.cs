using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTime : MonoBehaviour
{
    private int _actualTime;
    private int _newTime;

    public int ActualTime
    {
        get { return _actualTime; }
        set { _actualTime = value; }
    }
    public void OnChangeTime(int value)
    {
        _newTime += value;
       
        switch (_actualTime)
        {
            case 0:
                _actualTime = 1; break;
            case 1:
                _actualTime = 1; break;
            case 2:
                _actualTime = 2; break;
            case 3:
                _actualTime = 3; break;
            case 4:
                _actualTime = 4; break;
            case 5:
                _actualTime = 5; break;
            case 6:
                _actualTime = 5; break;
        }
        if (_actualTime != _newTime)
        {
            ChangeAssets();
        }

    }
    public void ChangeAssets()
    {
        
    }

}
