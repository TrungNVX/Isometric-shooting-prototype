using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fps_Impact : MonoBehaviour
{
    public float timeLife = 2;
    public string namePool;
    public ParticleSystem particleSystem_;
    // Start is called before the first frame update
    public void OnSpawned()
    {

        particleSystem_.Simulate(0, true, true);
        particleSystem_.Play();
        StartCoroutine("DelayDisable");
    }
    IEnumerator DelayDisable()
    {
        yield return new WaitForSeconds(timeLife);
        BYPoolManager.instance.DeSpawn(namePool, transform);
    }
}
