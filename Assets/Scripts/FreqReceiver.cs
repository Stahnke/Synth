using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreqReceiver : MonoBehaviour {

    public float frequency;

    public virtual void ReceiveFreq(float frequency)
    {
        this.frequency = frequency;
    }
    
    public virtual void ReceiveStop()
    {

    }	
}
