using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] private string _tag;

    [SerializeField] private GameObject _intercatedObject;

    [SerializeField] private bool _interacted = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == _tag)
        {
            _intercatedObject = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject ==  _intercatedObject) 
        {
            _intercatedObject = null;
        }
    }
    public void Interaction()
    {
        if (_intercatedObject != null) 
        {
            if (_intercatedObject.TryGetComponent<Button>(out Button button))
            {
                button.OpenDoor();
            }
            else if (_intercatedObject.TryGetComponent<Dialogs>(out Dialogs dialog))
            {
                dialog.StartDialog();
            }
        }
    }
}
