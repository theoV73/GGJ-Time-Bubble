using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogs : MonoBehaviour
{
    [SerializeField] List<string> _dialogs = new List<string>();
    [SerializeField] List<float> _dialogsTime = new List<float>();
    [SerializeField] List<float> _dialogsSize = new List<float>();

    [SerializeField] List<int> _dialogsColor = new List<int>();
    [SerializeField] List<Color> _dialogstextColor = new List<Color>();
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    public void StartDialog()
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
            _textMeshPro.color = _dialogstextColor[_dialogsColor[i]];
            _textMeshPro.fontSize = _dialogsSize[i];
            yield return new WaitForSeconds(_dialogsTime[i]);
        }
        _textMeshPro.gameObject.SetActive(false);
    }

}
