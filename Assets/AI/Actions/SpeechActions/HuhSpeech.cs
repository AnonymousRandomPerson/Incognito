using UnityEngine;
using System.Collections;
using System;

public class HuhSpeech : GenericSpeech {

    protected override AudioClip GetClip()
    {
        return (AudioClip)Resources.Load("SpeechClips/huh", typeof(AudioClip));
    }
}
