using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidiNoteController : MonoBehaviour {

    public FreqReceiver FreqReceiver;

    public void SendFreq(float frequency)
    {
        FreqReceiver.GetComponent<FreqReceiver>().ReceiveFreq(frequency);
    }

    public void SendStop()
    {
        FreqReceiver.GetComponent<FreqReceiver>().ReceiveStop();
    }

    public void SendMidiNote(int midi_note)
    {
        SendStop();
        print("Midi note: " + midi_note);
        float frequency = MFConverter.mtof(midi_note);
        SendFreq(frequency / 400.0f); //Divid by 200 for sampling TODO
    }

    public void SendStopNote()
    {
        SendStop();
    }
}
