using System.Collections.Generic;
using UnityEngine;

public class SPHFluidSimulation : MonoBehaviour
{
    public GameObject particlePrefab;
    public int numParticles = 100;
    public float particleRadius = 0.1f;
    public float stiffness = 1.0f;
    public float viscosity = 0.1f;
    public float timeStep = 0.01f;

    private List<GameObject> particles;

    void Start()
    {
        particles = new List<GameObject>();

        // Instantiate particles
        for (int i = 0; i < numParticles; i++)
        {
            Vector3 position = new Vector3(0.7776725f, 1.628f, 1.5f);
            GameObject particle = Instantiate(particlePrefab, position, Quaternion.identity);
            particles.Add(particle);
        }
    }

    void Update()
    {
        ApplySPHForces();
    }

    void ApplySPHForces()
    {
        foreach (var particle in particles)
        {
            Vector3 acceleration = Vector3.zero;

            foreach (var neighbor in particles)
            {
                if (neighbor != particle)
                {
                    Vector3 toNeighbor = neighbor.transform.position - particle.transform.position;
                    float distance = toNeighbor.magnitude;

                    if (distance < 2 * particleRadius)
                    {
                        // Apply SPH forces (pressure and viscosity)
                        float pressure = stiffness * (2 * particleRadius - distance);
                        acceleration += pressure * toNeighbor.normalized;
                        acceleration += viscosity * (neighbor.GetComponent<Rigidbody>().velocity - particle.GetComponent<Rigidbody>().velocity) / distance;
                    }
                }
            }

            // Update particle velocity and position
            Rigidbody particleRigidbody = particle.GetComponent<Rigidbody>();
            particleRigidbody.velocity += acceleration * timeStep;
            particle.transform.position += particleRigidbody.velocity * timeStep;
        }
    }
}
