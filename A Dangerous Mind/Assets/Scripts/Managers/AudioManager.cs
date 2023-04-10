using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicAudio;
    [SerializeField] private AudioSource[] randomSoundEffects;
    [SerializeField] private AudioSource[] doorSoundEffects;
    [SerializeField] private AudioSource[] soundEffects;
    [SerializeField] private AudioSource[] entitySounds;

    public AudioSource MusicAudio { get => musicAudio; set => musicAudio = value; }
    public AudioSource[] RandomSoundEffects { get => randomSoundEffects; set => randomSoundEffects = value; }
    public AudioSource[] DoorSoundEffects { get => doorSoundEffects; set => doorSoundEffects = value; }
    public AudioSource[] SoundEffects { get => soundEffects; set => soundEffects = value; }
    public AudioSource[] EntitySounds { get => entitySounds; set => entitySounds = value; }
}
