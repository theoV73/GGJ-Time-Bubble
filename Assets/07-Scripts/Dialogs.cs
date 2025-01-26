using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogs : MonoBehaviour
{
    [SerializeField] List<string> _dialogs = new List<string>();
    [SerializeField] List<float> _dialogsTime = new List<float>();
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    

    private void Start()
    {
        StartCoroutine(ReadDialogs());
    }
    public IEnumerator ReadDialogs()
    {
        yield return new WaitForSeconds(3);
        _textMeshPro.gameObject.SetActive(true);

        for (int i = 0; i < _dialogs.Count; i++)
        {
            _textMeshPro.text = _dialogs[i];
            yield return new WaitForSeconds(_dialogsTime[i]);
        }
        _textMeshPro.gameObject.SetActive(false);
    }

}
