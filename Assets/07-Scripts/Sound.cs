using UnityEngine.Audio;
using UnityEngine;

[HelpURL("https://www.youtube.com/watch?v=dQw4w9WgXcQ")]
[System.Serializable]
public class Sound
{
    [SerializeField]
    private string name;
    public string GetName
    {
        get { return name; }
    }
    [SerializeField]
    private AudioClip clip;
    public AudioClip GetClip
    {
        get { return clip; }
    }
    [SerializeField]

    private AudioMixerGroup audioMixerGroup;
    public AudioMixerGroup GetSetAudioMixer
    {
        get { return audioMixerGroup; }
        set { audioMixerGroup = value; }
    }
    [Range(0f, 1f)]
    [SerializeField]
    private float volume;
    public float GetSetVolume
    {
        get { return volume; }
        set { volume = value; }
    }
    [Range(.1f, 3f)]
    [SerializeField]
    private float pitch;
    public float GetSetPitch
    {
        get { return pitch; }
        set { pitch = value; }
    }

    [SerializeField]
    private bool loop;
    public bool GetLoop
    {
        get { return loop; }
    }
    [HideInInspector]
    [SerializeField]
    private AudioSource source;
    public AudioSource GetSetSource
    {
        get { return source; }
        set { source = value; }
    }


}
