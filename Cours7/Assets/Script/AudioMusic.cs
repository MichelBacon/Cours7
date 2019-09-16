using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundData", menuName = "ScriptableObjects/SoundData", order = 1)]
public class AudioMusic : ScriptableObject {
    public AudioClip soundToPlay;
}
