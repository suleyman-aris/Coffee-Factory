using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffect : MonoBehaviour
{
    public GameObject particleEffect; // Oynatmak istediðiniz particle efektinin referansý

    public Transform target;
    Vector3 targetTemp;
    private void Awake()
    {
        GameObject[] conveyorBelts = GameObject.FindGameObjectsWithTag("ConveyorBelt");

        if (conveyorBelts.Length > 0)
            target = conveyorBelts[0].transform;

        targetTemp = target.position;
    }

    public void PlayParticleEffect()
    {
        Vector3 particlePos;

        if (transform.position.x > targetTemp.x)
            particlePos = new Vector3(transform.position.x + 0.157f, transform.position.y + 0.149f, transform.position.z);
        else
            particlePos = new Vector3(transform.position.x - 0.157f, transform.position.y + 0.149f, transform.position.z);

        GameObject particle = Instantiate(particleEffect, particlePos, Quaternion.Euler(90f, 180f, 0f));

        // Particle efektini oynat
        ParticleSystem particleSystem = particle.GetComponent<ParticleSystem>();
        particleSystem.Play();
    }

    public void MoneyEffect()
    {
        Vector3 particlePos = new Vector3(0, 0.426f, -3.461f);
        GameObject particle = Instantiate(particleEffect, particlePos, Quaternion.Euler(-90f, 0, 0));

        // Particle efektini oynat
        ParticleSystem particleSystem = particle.GetComponent<ParticleSystem>();
        particleSystem.Play();
        Destroy(particle, 3);
    }
}
