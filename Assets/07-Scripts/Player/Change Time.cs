using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTime : MonoBehaviour
{
    private int _actualTime = 2;
    private int _newTime = 0;
    [SerializeField] List<GameObject> _objectFirstTime = new List<GameObject>();
    [SerializeField] List<GameObject> _objectSecondTime = new List<GameObject>();
    [SerializeField] List<GameObject> _objectThirdTime = new List<GameObject>();
    [SerializeField] List<GameObject> _objectFourthTime = new List<GameObject>();
    [SerializeField] List<GameObject> _objectFifthTime = new List<GameObject>();
    public int ActualTime
    {
        get { return _actualTime; }
        set { _actualTime = value; }
    }
    private void Start()
    {
        OnChangeTime(0);
    }
    public void OnChangeTime(int value)
    {
        _actualTime += value;
       
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
        switch (_actualTime)
        {
            case 1:
                _newTime = 1;
                ObjectFirstTime(true);
                ObjectSecondTime(false);
                break;
            case 2:
                if (_actualTime < _newTime)
                {
                    ObjectSecondTime(true);
                    ObjectThirdTime(false);
                }
                else
                {
                    ObjectSecondTime(true);
                    ObjectFirstTime(false);
                }
                _newTime = 2; 
                break;
            case 3:
                if (_actualTime < _newTime)
                {
                    ObjectThirdTime(true);
                    ObjectFourthTime(false);
                }
                else
                {
                    ObjectThirdTime(true);
                    ObjectSecondTime(false);
                }
                _newTime = 3; 
                break;
            case 4:
                if (_actualTime < _newTime)
                {
                    ObjectFourthTime(true);
                    ObjectFifthTime(false);
                }
                else
                {
                    ObjectFourthTime(true);
                    ObjectThirdTime(false);
                }
                _newTime = 4;

                break;
            case 5:
                _newTime = 5;
                ObjectFifthTime(true);
                ObjectFourthTime(false);
                break;
        }
    }
    private void ObjectFirstTime(bool value)
    {
        //Debug.Log("ObjectFirstTime " + value);
        if (value) 
        {
            for (int i = 0; i < _objectFirstTime.Capacity; i++)
            {
                _objectFirstTime[i].gameObject.SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < _objectFirstTime.Count; i++)
            {
                _objectFirstTime[i].gameObject.SetActive(false);
            }
        }

        
        
    }
    private void ObjectSecondTime(bool value)
    {
        if (value)
        {
            for (int i = 0; i < _objectSecondTime.Count; i++)
            {
                _objectSecondTime[i].gameObject.SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < _objectSecondTime.Count; i++)
            {
                _objectSecondTime[i].gameObject.SetActive(false);
            }
        }
    }
    private void ObjectThirdTime(bool value)
    {
        if (value)
        {
            for (int i = 0; i < _objectThirdTime.Count; i++)
            {
                _objectThirdTime[i].gameObject.SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < _objectThirdTime.Count; i++)
            {
                _objectThirdTime[i].gameObject.SetActive(false);
            }
        }
    }
    private void ObjectFourthTime(bool value)
    {
        if (value)
        {
            for (int i = 0; i < _objectFourthTime.Count; i++)
            {
                _objectFourthTime[i].gameObject.SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < _objectFourthTime.Count; i++)
            {
                _objectFourthTime[i].gameObject.SetActive(false);
            }
        }
    }
    private void ObjectFifthTime(bool value)
    {
        if (value)
        {
            for (int i = 0; i < _objectFifthTime.Count; i++)
            {
                _objectFifthTime[i].gameObject.SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < _objectFifthTime.Count; i++)
            {
                _objectFifthTime[i].gameObject.SetActive(false);
            }
        }
    }

}
