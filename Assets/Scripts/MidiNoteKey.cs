using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidiNoteKey : MonoBehaviour {

    public GameObject MidiNoteController;
    public int midi_note = 0;
    public int KeyColor = 0;

    private const int BLACK_KEY = 0;
    private const int WHITE_KEY = 1;

    public Renderer rend;
	
    void GenMidiNote()
    {
        MidiNoteController.GetComponent<MidiNoteController>().SendMidiNote(midi_note);
    }

    void StopMidiNote()
    {
        MidiNoteController.GetComponent<MidiNoteController>().SendStopNote();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //Produce sound
            GenMidiNote();

            Color color;
            float R, G, B;

            //Light up the key

            //White key
            if(KeyColor == WHITE_KEY)
            {
                //This will get us a blue hue
                R = 1.0f;
                G = 0.0f;
                B = 0.0f;
            }

            //Black key
            else
            {
                //This will get us a purple/pink hue
                R = 0.0f;
                G = 1.0f;
                B = 0.0f;
            }

            color = new Color(R, G, B);

            rend = GetComponent<Renderer>();
            rend.material.shader = Shader.Find("Outlined/Silhouetted Diffuse");

            rend.material.SetColor("_OutlineColor", color);

            //If our key is black, turn it white to activate the bloom
            if(KeyColor == BLACK_KEY)
            {
                rend.material.SetColor("_Color", new Color(1.0f, 1.0f, 1.0f));
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        StopMidiNote();

        if (collision.gameObject.CompareTag("Player"))
        {
            Color color = new Color(1.0f, 1.0f, 1.0f);

            rend = GetComponent<Renderer>();
            rend.material.shader = Shader.Find("Outlined/Silhouetted Diffuse");

            rend.material.SetColor("_OutlineColor", color);

            //If our key is black, turn it back to black
            if (KeyColor == BLACK_KEY)
            {
                rend.material.SetColor("_Color", new Color(0.0f, 0.0f, 0.0f));
            }
        }
    }
}
