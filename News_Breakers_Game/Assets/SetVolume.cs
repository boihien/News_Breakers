using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{

    public AudioMixer mixer;
    
    public void SetVol (float val)
    {
        mixer.SetFloat("Vol", Mathf.Log10(val) * 20);
    }

    
}
