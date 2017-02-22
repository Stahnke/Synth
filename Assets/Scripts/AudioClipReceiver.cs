using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClipReceiver : MonoBehaviour {

    protected AudioClip audioClip;

    public virtual void ReceiveAudioClip(AudioClip audioClip)
    {
        this.audioClip = audioClip;
    }

    public virtual void ReceiveStop()
    {

    }
}
