using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreqShrink : FreqReceiver {

    public AudioClip sample;

    public FreqReceiver oscillator;

    public override void ReceiveFreq(float frequency)
    {
        base.ReceiveFreq(frequency);

        float f = MFConverter.mtof(60) / (44100.0f / sample.samples);

        oscillator.ReceiveFreq(frequency / f);
    }
}
