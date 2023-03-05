using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_MuzzleFlash : MonoBehaviour
{
    public ParticleSystem particleSystem_;
    // Start is called before the first frame update
    public void FireHandle()
    {

        particleSystem_.Simulate(0, true, true);
        particleSystem_.Play();
    }
}
