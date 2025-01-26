using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering;

public class Button : MonoBehaviour
{
    [SerializeField] private GameObject[] _door;
    [SerializeField] private Transform[] _objectMovementReference;
    [SerializeField] private Vector3[] _objectEndPos;
    [SerializeField] private bool[] _baseIsHigher;
    [SerializeField] private float _speed;
    [SerializeField] private Axis _axis;
    [SerializeField] private bool _enable;

    enum Axis
    {
        X,
        Y,
        Z
    }

    private void Awake()
    {
        _objectEndPos = new Vector3[_door.Length];
        _objectMovementReference = new Transform[_door.Length];
        _baseIsHigher = new bool[_door.Length];
        for (int i = 0; i < _door.Length; i++)
        {
            _objectMovementReference[i] = _door[i].transform.GetChild(0);
            _objectEndPos[i] = _objectMovementReference[i].position;

            switch (_axis)
            {
                case Axis.X:
                    if (_door[i].transform.position.x > _objectEndPos[i].x)
                    {
                        _baseIsHigher[i] = true;
                    }
                    break;

                case Axis.Y:
                    if (_door[i].transform.position.y > _objectEndPos[i].y)
                    {
                        _baseIsHigher[i] = true;
                    }
                    break;

                case Axis.Z:
                    if (_door[i].transform.position.z > _objectEndPos[i].z)
                    {
                        _baseIsHigher[i] = true;
                    }
                    break;
            }
        }
    }

    public void OpenDoor()
    {
        _enable = true;
        transform.GetComponent<BoxCollider>().enabled = false;
    }

    private void Update()
    {
        if (_enable)
        {
            for (int i = 0; i < _door.Length; i++)
            {
                _door[i].transform.position += _objectMovementReference[i].localPosition.normalized * Time.deltaTime * _speed;

                switch (_axis)
                {
                    case Axis.X:
                        if (_baseIsHigher[i])
                        {
                            if (_door[i].transform.position.x < _objectEndPos[i].x)
                            {
                                _enable = false;
                            }
                        }
                        else
                        {
                            if (_door[i].transform.position.x > _objectEndPos[i].x)
                            {
                                _enable = false;
                            }
                        }
                        break;

                    case Axis.Y:
                        if (_baseIsHigher[i])
                        {
                            if (_door[i].transform.position.y < _objectEndPos[i].y)
                            {
                                _enable = false;
                            }
                        }
                        else
                        {
                            if (_door[i].transform.position.y > _objectEndPos[i].y)
                            {
                                _enable = false;
                            }
                        }
                        break;

                    case Axis.Z:
                        if (_baseIsHigher[i])
                        {
                            if (_door[i].transform.position.z < _objectEndPos[i].z)
                            {
                                _enable = false;
                            }
                        }
                        else
                        {
                            if (_door[i].transform.position.z > _objectEndPos[i].z)
                            {
                                _enable = false;
                            }
                        }
                        break;
                }


            }
        }

    }
}

