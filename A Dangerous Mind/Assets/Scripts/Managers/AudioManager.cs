using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicAudio;
    [SerializeField] private AudioSource[] randomSoundEffects;
    [SerializeField] private AudioSource[] doorSoundEffects;
    [SerializeField] private AudioSource[] soundEffects;

    public AudioSource MusicAudio { get => musicAudio; set => musicAudio = value; }
    public AudioSource[] RandomSoundEffects { get => randomSoundEffects; set => randomSoundEffects = value; }
    public AudioSource[] DoorSoundEffects { get => doorSoundEffects; set => doorSoundEffects = value; }
    public AudioSource[] SoundEffects { get => soundEffects; set => soundEffects = value; }
}
