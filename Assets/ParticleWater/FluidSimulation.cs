using System.Collections.Generic;
using UnityEngine;

public class FluidSimulation : MonoBehaviour
{
    public float fluidDensity = 1.0f;
    public float viscosity = 0.01f;
    public float damping = 0.98f;

    private List<Rigidbody> particles;

    void Start()
    {
        InitializeParticles();
    }

    void InitializeParticles()
    {
        particles = new List<Rigidbody>();
        
        // Assuming your particles have the "ParticleTag"
        GameObject[] particleObjects = GameObject.FindGameObjectsWithTag("ParticleTag");

        foreach (var particleObject in particleObjects)
        {
            Rigidbody particleRigidbody = particleObject.GetComponent<Rigidbody>();
            
            if (particleRigidbody != null)
            {
                particles.Add(particleRigidbody);
            }
        }
    }

    void FixedUpdate()
    {
        ApplyFluidForces();
    }

    void ApplyFluidForces()
    {
        foreach (var particle in particles)
        {
            if (particle != null)
            {
                ApplyGravity(particle);
                ApplyViscosity(particle);
            }
        }
    }

    void ApplyGravity(Rigidbody particle)
    {
        // Apply gravity based on fluid density
        particle.AddForce(Vector3.down * fluidDensity);
    }

    void ApplyViscosity(Rigidbody particle)
    {
        // Apply simple viscosity forces
        Vector3 fluidVelocity = particle.velocity;
        Vector3 dampingForce = -viscosity * fluidVelocity;
        particle.AddForce(dampingForce);

        // Apply damping to slow down the particles over time
        particle.velocity *= damping;
    }
}
