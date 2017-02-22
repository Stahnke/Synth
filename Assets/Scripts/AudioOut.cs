using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOut : AudioClipReceiver
{

    private AudioSource aud;

    public float approxSecondsToFade = 0.020f;

    public override void ReceiveAudioClip(AudioClip audioClip)
    {
        base.ReceiveAudioClip(audioClip);

        aud = GetComponent<AudioSource>();
        aud.clip = audioClip;
        aud.Play();
    }

    public override void ReceiveStop()
    {
        if (audioClip != null)
        {
            aud.Stop();
        }
    }
}
