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

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector2 values = context.ReadValue<Vector2>();
            Vector3 movement = new Vector3(values.x, 0, values.y);
            _characterController.Move(movement);
        }
    }
    public void OnLook(Vector2 values)
    {
        
    }
    public void OnJump()
    {
        //_characterController.velocity
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
    public void OnAddTime(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Add Time");
            _changeTime.OnChangeTime(1);
        }
        
    }
    public void OnRemoveTime(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Remove Time");

            _changeTime.OnChangeTime(-1);
        }
    }
    public void OnReadNoteBook(int layerIndex)
    {
        
    }
}
