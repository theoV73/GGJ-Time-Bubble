using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    private ChangeTime _changeTime;

    private bool _isPause = false;

    private Vector3 _movement;
    [SerializeField] private float _speed;

    [SerializeField] private GameObject _lookAtReference;
    [SerializeField] private GameObject _movementReference;

    private Rigidbody _rigidbody;
    [SerializeField, Min(0f)] private float jumpForce = 10f;

    bool _jumpInput;

    public void Start()
    {
        _changeTime = GetComponent<ChangeTime>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _movement = ((_movementReference.transform.position - transform.position) * _speed) * Time.deltaTime;
        transform.position += _movement;
        transform.LookAt(new Vector3(_lookAtReference.transform.position.x, transform.position.y, _lookAtReference.transform.position.z));

        if (_jumpInput)
        {
            _rigidbody.AddForce(Vector3.up * jumpForce);
            _jumpInput = false;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        Vector3 movement = new Vector3(input.x, 0, input.y);
        _movementReference.transform.localPosition = movement.normalized;
        
    }

    public void OnLook(Vector2 values)
    {
        
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (Mathf.Approximately(_rigidbody.velocity.y, 0f))
        {
            _jumpInput = true;
        }
    }

    public void OnPause(InputAction.CallbackContext context)
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

    public void OnInteract(InputAction.CallbackContext context)
    {

    }

    public void OnAddTime(InputAction.CallbackContext context)
    {
        //if (context.performed)
        //{
        //    Debug.Log("Add Time");
        //    _changeTime.OnChangeTime(1);
        //}
    }

    public void OnRemoveTime(InputAction.CallbackContext context)
    {
        //if (context.performed)
        //{
        //    Debug.Log("Remove Time");

        //    _changeTime.OnChangeTime(-1);
        //}
    }

    public void OnReadNoteBook(InputAction.CallbackContext context)
    {
        
    }
}
