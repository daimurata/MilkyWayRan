using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    private ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {
        particle = this.GetComponent<ParticleSystem>();

        // ここで Particle System を停止する.
        particle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        // ここで Particle System を開始します.
        particle.Play();
    }

}
