using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableTimeObject : MonoBehaviour
{
    [SerializeField] private Vector3[] _positions = new Vector3[5];
    private Vector3[] _oldPositions = new Vector3[5];
    [SerializeField] private Quaternion[] _rotation = new Quaternion[5];
    private Quaternion[] _oldRotation = new Quaternion[5];
    void Start()
    {
        for (int i = 0; i < _positions.Length; i++)
        {
            _positions[i] = this.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePositionInfo(int previoustime, int actualTime)
    {
         _positions[previoustime - 1] = this.transform.position;
        if (_positions[previoustime-1] != _oldPositions[previoustime-1])
        {
            for (int i = previoustime - 1; i < _positions.Length; i++)
            {
                _positions[i] = _positions[previoustime - 1];
            }

            for (int i = previoustime - 1; i < _oldPositions.Length; i++)
            {
                _oldPositions[i] = _positions[i];
            }
            
        }
        


    }
    public void ChangePosition(int time)
    {
        this.transform.position = _positions[time-1];
    }
    public void ChangeRotationInfo(int previoustime, int actualTime)
    {
        _rotation[previoustime - 1] = this.transform.rotation;
        if (_rotation[previoustime - 1] != _oldRotation[previoustime - 1])
        {
            for (int i = previoustime - 1; i < _rotation.Length; i++)
            {
                _rotation[i] = _rotation[previoustime - 1];
            }

            for (int i = previoustime - 1; i < _oldRotation.Length; i++)
            {
                _oldRotation[i] = _rotation[i];
            }
        }
    }
    public void ChangeRotation(int time)
    {
        this.transform.rotation = _rotation[time - 1];
    }
}
