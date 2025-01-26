using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PlaySounds : MonoBehaviour
{
    #region SINGLETON
    [SerializeField] private static PlaySounds _instance = null;

    public static PlaySounds Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<PlaySounds>();
                // Si vrai, l'instance va etre cree
                if (_instance == null)
                {
                    var newObjectInstance = new GameObject();
                    newObjectInstance.name = typeof(PlaySounds).ToString();
                    _instance = newObjectInstance.AddComponent<PlaySounds>();
                }
            }
            return _instance;
        }
    }

    public AudioManager AudioManager { get => _audioManager; set => _audioManager = value; }
    #endregion
    AudioManager _audioManager;
    string _actualMusique;
    private void Awake()
    {
        _audioManager = AudioManager.Instance;
    }
    public void SetVolume()
    {
        AudioManager.SetVolume();
    }
    public void PlayRandomPitch(string name)
    {
        
        for (int i = 0; i < AudioManager.GetSetSounds.Length; i++)
        {
            if (AudioManager.GetSetSounds[i].GetName == name)
            {
                float rndPitch = Random.Range(0.9f, 1.1f);
                AudioManager.GetSetSounds[i].GetSetPitch = rndPitch;
                AudioManager.Play(name);

            }
        }
    }

    public void PlayRandomVolume(string name)
    {

        for (int i = 0; i < AudioManager.GetSetSounds.Length; i++)
        {
            if (AudioManager.GetSetSounds[i].GetName == name)
            {
                float rndSpeed = Random.Range(AudioManager.GetSetSounds[i].GetSetVolume - 0.2f, AudioManager.GetSetSounds[i].GetSetVolume + 0.2f);

                AudioManager.GetSetSounds[i].GetSetPitch = rndSpeed;
                AudioManager.Play(name);

            }
        }
    }
    public void PlayRandomPitchAndVolume(string name)
    {
        

        for (int i = 0; i < AudioManager.GetSetSounds.Length; i++)
        {
            if (AudioManager.GetSetSounds[i].GetName == name)
            {
                float rndPitch = Random.Range(0.9f, 1.1f);
                float rndSpeed = Random.Range(AudioManager.GetSetSounds[i].GetSetVolume - 0.2f, AudioManager.GetSetSounds[i].GetSetVolume + 0.2f);
                AudioManager.GetSetSounds[i].GetSetPitch = rndPitch;
                AudioManager.GetSetSounds[i].GetSetVolume = rndSpeed;
                AudioManager.Play(name);

            }
        }
    }
    public void PlaySound(string name)
    {
        if (name == "Boucle In Game 0.47_2.00")
        {
            _actualMusique = name;
        }
        else if (name == "Eau Canal")
        {
            _actualMusique = name;
        }
        else if (name == "Hub")
        {
            _actualMusique = name;
        }
        
        if (name != null) 
        { 
          AudioManager.Play(name);
        }
    }
    public void PlaySoundDistance(string name,float distance,float distanceMax)
    {
        if (distance > distanceMax)
        {
            distance = distanceMax;
        }
        float percent = distance / distanceMax;
        //Debug.Log(name+"distance : " + distance + " & distance max : " + distanceMax);
        percent = 1 - percent;
        //Debug.Log(name+"after" + percent);
        if (name != null)
        {
            AudioManager.PlayDistanceVolume(name, percent);
        }
    }
    public void StopSound(string name)
    {

        if (name != null)
        {
            AudioManager.Stop(name);
        }
    }
    public void PauseSound(string name)
    {

        if (name != null)
        {
            AudioManager.Pause(name);
        }
    }

    public void PauseMusique()
    {
        if (_actualMusique != null)
        {
            AudioManager.Pause(_actualMusique);
        }
    }
    public void ResumeMusique()
    {
        if (_actualMusique != null)
        {
            AudioManager.Resume(_actualMusique);
        }
    }
}
