using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tabread : AudioClipReceiver
{

    private float[] phasor_data;
    private float[] sample_data;

    private float[] output_data;

    public AudioClip sample;

    public AudioClipReceiver audioClipReceiver;

    public override void ReceiveAudioClip(AudioClip audioClip)
    {
        base.ReceiveAudioClip(audioClip);

        phasor_data = new float[audioClip.samples * audioClip.channels];
        sample_data = new float[sample.samples * sample.channels];
        output_data = new float[audioClip.samples * audioClip.channels];

        audioClip.GetData(phasor_data, 0);

        for (int i = 0; i < phasor_data.Length; i++)
        {
            phasor_data[i] *= 44100;
        }
        ReadTab();
    }

    private void ReadTab()
    {
        print(sample_data.Length);
        print(phasor_data.Length);
        sample.GetData(sample_data, 0);
        for (int i = 0; i < output_data.Length; i++)
        {
            output_data[i] = sample_data[(int)phasor_data[i]];
        }

        audioClip.SetData(output_data, 0);
        audioClipReceiver.ReceiveAudioClip(audioClip);
    }
}