using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : FreqReceiver
{
    public int position = 0;
    public int samplerate = 44100;
    public float amplitude = 0.5f;

    public int wave_type = 0;
    //Wave types
    private const int SIN_WAVE = 0;
    private const int SAWTOOTH_WAVE = 1;
    private const int SQUARE_WAVE = 2;
    private const int TRIANGLE_WAVE = 3;

    private AudioSource aud;
    private AudioClip myClip;

    public AudioClipReceiver audioClipReceiver;

    void StartOscillator()
    {
        myClip = AudioClip.Create("MySinusoid", samplerate, 1, samplerate, false, OnAudioRead, OnAudioSetPosition);
        audioClipReceiver.GetComponent<AudioClipReceiver>().ReceiveAudioClip(myClip);
    }

    void StopOscillator()
    {
        if(myClip != null)
            audioClipReceiver.GetComponent<AudioClipReceiver>().ReceiveStop();
    }

    void OnAudioRead(float[] data)
    {
        int count = 0;
        while (count < data.Length)
        {
            data[count] = amplitude * GetWaveData();  
            position++;
            count++;
        }
    }

    void OnAudioSetPosition(int newPosition)
    {
        position = newPosition;
    }

    public override void ReceiveFreq(float frequency)
    {
        this.frequency = frequency;
        StartOscillator();
    }

    public override void ReceiveStop()
    {
        StopOscillator();
    }

    private float GetWaveData()
    {
        switch(wave_type)
        {
            case SIN_WAVE:
                return (Mathf.Sin(2 * Mathf.PI * frequency * position / samplerate));
            case SAWTOOTH_WAVE:
                return ((frequency * position / samplerate) % 1);
                //return Mathf.Atan(1 / Mathf.Tan(0.0f));
            case SQUARE_WAVE:
                return Mathf.Sign(Mathf.Sin(2 * Mathf.PI * frequency * position / samplerate));
            case TRIANGLE_WAVE:
                return 4.0f * (Mathf.Abs((frequency * position / samplerate) % 1 - 0.5f) - 0.25f);
            default:
                return 0.0f;
        }
    }
}
