using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogs : MonoBehaviour
{
    [SerializeField] List<string> _dialogs = new List<string>();
    [SerializeField] List<float> _dialogsTime = new List<float>();
    
    public IEnumerator ReadDialogs()
    {
        for (int i = 0; i < _dialogs.Count; i++)
        {
            yield return new WaitForSeconds(_dialogsTime[i]);
        }
    }

}
