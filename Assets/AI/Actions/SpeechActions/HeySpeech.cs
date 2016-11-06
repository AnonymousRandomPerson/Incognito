using UnityEngine;
using System.Collections;
using System;

public class HeySpeech : GenericSpeech
{

    protected override AudioClip GetClip()
    {
        return (AudioClip)Resources.Load("SpeechClips/hey", typeof(AudioClip));
    }
}

