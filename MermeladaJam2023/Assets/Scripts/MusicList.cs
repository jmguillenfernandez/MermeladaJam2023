using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class MusicList
{
    [Tooltip("Lista de sonidos/canciones a almacenar, puedes añadir más pulsando el icono de +")]
    public List<AudioTrack> tracks;

    public void AddAudio(AudioTrack track)
    {
        tracks.Add(track);
        track.ID = tracks.Count - 1;
    }
}
