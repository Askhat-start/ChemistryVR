using System.Collections.Generic;
using UnityEngine;

public class ParticleCohesion : MonoBehaviour
{
    public float cohesionStrength = 1.0f;
    public float cohesionRadius = 1.0f;
    private GameObject[] particles;

    void Start()
    {
        particles = GameObject.FindGameObjectsWithTag("ParticleTag");
    }

    void FixedUpdate()
    {
        foreach (var particle in particles)
        {
            if (particle != null && particle != this.gameObject)
            {
                Vector3 toOther = particle.transform.position - transform.position;
                float distance = toOther.magnitude;

                if (distance > 0 && distance < cohesionRadius)
                {
                    Vector3 cohesionForce = cohesionStrength * toOther.normalized;
                    GetComponent<Rigidbody>().AddForce(cohesionForce);
                }
            }
        }
    }
}
