using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[HelpURL("https://www.youtube.com/watch?v=dQw4w9WgXcQ")]
public class AudioManager : MonoBehaviour
{
    #region SINGLETON

    /// <summary>
    ///  Force a avoir qu'un seul LevelManager
    /// </summary>
    [SerializeField] private static AudioManager _instance = null;

    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<AudioManager>();
                // Si vrai, l'instance va etre cree
                if (_instance == null)
                {
                    var newObjectInstance = new GameObject();
                    newObjectInstance.name = typeof(AudioManager).ToString();
                    _instance = newObjectInstance.AddComponent<AudioManager>();
                }
            }
            return _instance;
        }
    }

    #endregion
    [SerializeField] private PlaySounds _playSounds;
    [SerializeField] private Sound[] sounds = new Sound[0];

    
    public Sound[] GetSetSounds
    {
        get { return sounds; }
        set { sounds = value; }
    }
    void Awake()
    {
        _playSounds = GetComponent<PlaySounds>(); 
        foreach(Sound s in sounds)
        {
            s.GetSetSource = gameObject.AddComponent<AudioSource>();
            s.GetSetSource.clip = s.GetClip;
            s.GetSetSource.outputAudioMixerGroup = s.GetSetAudioMixer;

            s.GetSetSource.volume = s.GetSetVolume;
            //s.GetSetSource.pitch = s.GetSetVolume * volumeGenerale * volume;
            s.GetSetSource.pitch = s.GetSetPitch;
            s.GetSetSource.loop = s.GetLoop;
        }
    }

    public IEnumerator SetVolume()
    {
        yield return new WaitForSeconds(0.01f);
        foreach (Sound s in sounds)
        {
            Debug.LogError(s.GetName);
            Debug.LogError(s.GetSetSource);
            Debug.LogError(s.GetSetSource.volume);
            Debug.LogError(s.GetSetVolume);
            s.GetSetSource.volume = s.GetSetVolume;
            //s.GetSetSource.pitch = s.GetSetVolume;
        
        }
    }

    public Sound GetSound(string name) 
    {
        if (name == null) { name = "NULL"; }
        if (sounds.Length == 0) { return null; }

        return Array.Find(sounds, sound => sound.GetName == name);
    }

    private int GetNbrSound(string name)
    {
        if (name == null) { name = "NULL"; }

        if (AudioManager.Instance != null)
        {
            int nbrIterationSound = 1;

            while (AudioManager.Instance.IsExist(name + nbrIterationSound))
            {
                nbrIterationSound++;
            }

            if (nbrIterationSound <= 1) { return 0; }
            else return nbrIterationSound;
        }
        else
        {
            return 0;
        }

    }

    private string GetRandomSoundFromName(string name)
    {
        if (name == null) { name = "NULL"; }

        int nbrSound = GetNbrSound(name);

            if (nbrSound > 0)
            {
                return name + UnityEngine.Random.Range(1, nbrSound);
            }
            else
            {
                return name;
            }
        
    }

    public void Play(string name)
    {
        if (name == null||name==" ") { name = "NULL"; }
        if (sounds.Length == 0) { return ; }


        Sound s = Array.Find(sounds, sound => sound.GetName == name);



        if ( s != null )
        {
            s.GetSetSource.Play();

        }

    }

    public void PlayDistanceVolume(string name, float volume)
    {
        if (name == null || name == " ") { name = "NULL"; }
        if (sounds.Length == 0) { return; }


        Sound s = Array.Find(sounds, sound => sound.GetName == name);
        if (s != null)
        {
            s.GetSetVolume = s.GetSetVolume/volume;
            if(s.GetSetVolume > 0)
            {
                s.GetSetSource.Play();

            }

        }

    }
    public void Stop(string name)
    {
        if (sounds.Length == 0) { return; }
        Sound s = Array.Find(sounds, sound => sound.GetName == name);
        if (s != null)
        {
            s.GetSetSource.Stop();
        }



    }
    public void Pause(string name)
    {
        if (sounds.Length == 0) { return; }
        Sound s = Array.Find(sounds, sound => sound.GetName == name);
        if (s != null)
        {
            s.GetSetSource.Pause();
        }

    }
    public void Resume(string name)
    {
        if (sounds.Length == 0) { return; }
        Sound s = Array.Find(sounds, sound => sound.GetName == name);
        if (s != null)
        {
            s.GetSetSource.UnPause();
        }

    }
    public void PlayRandom(string name)
    {
        Play(GetRandomSoundFromName(name));
    }

    public bool IsExist(string name)
    {
        if (name == null) { name = "NULL"; }
        if (sounds.Length == 0) { return false; }

        Sound s = Array.Find(sounds, sound => sound.GetName == name);
        if (s != null)
            return true;
        else
            return false;
    }
}

//FindObjectOfType<AudioManager>().Play("");
