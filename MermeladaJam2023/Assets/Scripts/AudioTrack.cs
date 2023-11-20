using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AudioTrack
{
    [Tooltip("Identificador del sonido, todos tienen que ser diferentes")]
    public int ID;
    [Tooltip("Nombre del sonido")]
    public string Name;
    [Tooltip("Clip de audio")]
    public AudioClip AudioClip;

    AudioTrack(string name, AudioClip audioClip) {Name = name; AudioClip = audioClip; }
}

