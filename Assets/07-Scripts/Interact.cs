using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] private LayerMask _accesCardLayer;
    [SerializeField] private LayerMask _buttonCardLayer;

    [SerializeField] private GameObject _intercatedObject;

    [SerializeField] private bool _interacted = false;
    public bool Interacted
    {
        get { return _interacted; } set { _interacted = value; }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == _accesCardLayer)
        {
            _intercatedObject = other.gameObject;
            AccesCard();
        }
        if (other.gameObject.layer == _buttonCardLayer)
        {
            _intercatedObject = other.gameObject;
            ButtonCard();
        }
    }
    private void AccesCard()
    {
        if (_interacted)
        {
            
        }
    }
    private void ButtonCard()
    {
        if (_interacted)
        {

        }
    }
}
