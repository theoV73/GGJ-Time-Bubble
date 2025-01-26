using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTime : MonoBehaviour
{
    [SerializeField] private int _actualTime = 2;
    [SerializeField] private int _oldTime = 1;
    [SerializeField] private List<InteractableTimeObject> _interactableTimeObject = new List<InteractableTimeObject>();

    [SerializeField] List<GameObject> _objectEnviroFirst = new List<GameObject>();
    [SerializeField] List<GameObject> _objectEnviroSecond = new List<GameObject>();
    [SerializeField] List<GameObject> _objectEnviroThird = new List<GameObject>();
    [SerializeField] List<GameObject> _objectEnviroFourth = new List<GameObject>();
    [SerializeField] List<GameObject> _objectEnviroFifth = new List<GameObject>();
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
        //Debug.Log($"Change time of {_actualTime} to {_actualTime+value}");
        _actualTime += value;
        //Debug.Log($"Before Fonction, actual time = {_actualTime}");

        for (int i = 0; i < _interactableTimeObject.Capacity; i++)
        {
            _interactableTimeObject[i].ChangePositionInfo(_actualTime - value, _actualTime);
            _interactableTimeObject[i].ChangeRotationInfo(_actualTime - value, _actualTime);
        }
        //Debug.Log($"After Fonction, actual time = {_actualTime}");

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

        if (_actualTime != _oldTime)
        {
            _oldTime = _actualTime;
            ChangeAssets(value);
            for (int i = 0; i < _interactableTimeObject.Capacity; i++)
            {
                _interactableTimeObject[i].ChangePosition(_actualTime);
                _interactableTimeObject[i].ChangeRotation(_actualTime);
            }
        }

    }
    public void ChangeAssets(int value)
    {
        switch (_actualTime)
        {
            case 1:
                ObjectFirstTime(true);
                ObjectSecondTime(false);
                break;
            case 2:
                if (value<=0)
                {
                    ObjectSecondTime(true);
                    ObjectThirdTime(false);
                }
                else
                {
                    ObjectSecondTime(true);
                    ObjectFirstTime(false);
                }
                break;
            case 3:
                if (value <= 0)
                {
                    ObjectThirdTime(true);
                    ObjectFourthTime(false);
                }
                else
                {
                    ObjectThirdTime(true);
                    ObjectSecondTime(false);
                }
                break;
            case 4:
                if (value <= 0)
                {
                    ObjectFourthTime(true);
                    ObjectFifthTime(false);
                }
                else
                {
                    ObjectFourthTime(true);
                    ObjectThirdTime(false);
                }

                break;
            case 5:
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
            for (int i = 0; i < _objectEnviroFirst.Capacity; i++)
            {
                _objectEnviroFirst[i].gameObject.SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < _objectEnviroFirst.Count; i++)
            {
                _objectEnviroFirst[i].gameObject.SetActive(false);
            }
        }

        
        
    }
    private void ObjectSecondTime(bool value)
    {
        if (value)
        {
            for (int i = 0; i < _objectEnviroSecond.Count; i++)
            {
                _objectEnviroSecond[i].gameObject.SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < _objectEnviroSecond.Count; i++)
            {
                _objectEnviroSecond[i].gameObject.SetActive(false);
            }
        }
    }
    private void ObjectThirdTime(bool value)
    {
        if (value)
        {
            for (int i = 0; i < _objectEnviroThird.Count; i++)
            {
                _objectEnviroThird[i].gameObject.SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < _objectEnviroThird.Count; i++)
            {
                _objectEnviroThird[i].gameObject.SetActive(false);
            }
        }
    }
    private void ObjectFourthTime(bool value)
    {
        if (value)
        {
            for (int i = 0; i < _objectEnviroFourth.Count; i++)
            {
                _objectEnviroFourth[i].gameObject.SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < _objectEnviroFourth.Count; i++)
            {
                _objectEnviroFourth[i].gameObject.SetActive(false);
            }
        }
    }
    private void ObjectFifthTime(bool value)
    {
        if (value)
        {
            for (int i = 0; i < _objectEnviroFifth.Count; i++)
            {
                _objectEnviroFifth[i].gameObject.SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < _objectEnviroFifth.Count; i++)
            {
                _objectEnviroFifth[i].gameObject.SetActive(false);
            }
        }
    }

}
