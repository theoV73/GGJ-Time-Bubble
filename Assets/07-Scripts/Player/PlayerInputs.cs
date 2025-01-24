using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    private ChangeTime _changeTime;

    private bool _isPause = false;
    public void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _changeTime = GetComponent<ChangeTime>();
    }

    public void OnMove(Vector2 values)
    {
        Vector3 movement = new Vector3(values.x, 1.0f, values.y);
        _characterController.Move(movement);
    }
    public void OnLook(Vector2 values)
    {
        
    }
    public void OnJump()
    {

    }
    public void OnPause()
    {
        if (_isPause)
        {
            _isPause = false;
        }
        else
        {
            _isPause = true;
        }
    }
    public void OnAddTime()
    {
        _changeTime.OnChangeTime(1);   
    }
    public void OnRemoveTime()
    {
        _changeTime.OnChangeTime(-1);
    }
    public void OnReadNoteBook(int layerIndex)
    {
        
    }
}
