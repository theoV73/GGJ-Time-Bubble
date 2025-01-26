using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] private LayerMask _accesCardLayer;
    [SerializeField] private LayerMask _buttonCardLayer;

    [SerializeField] private GameObject _intercatedObject;

    [SerializeField] private bool _interacted = false;
    private bool _haveAccesCard = false;
    public bool Interacted
    {
        get { return _interacted; } set { _interacted = value; }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == _accesCardLayer)
        {
            _intercatedObject = other.gameObject;
        }
        if (other.gameObject.layer == _buttonCardLayer)
        {
            _intercatedObject = other.gameObject;
        }
    }
    public void Interaction()
    {
        if (_intercatedObject != null) 
        {
            if (_intercatedObject.layer == _buttonCardLayer)
            {

            }
            else if (_intercatedObject.layer == _buttonCardLayer)
            {
                _haveAccesCard = true;
            }
        }
    }
}
