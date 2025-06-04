using UnityEngine;
using System.Collections.Generic;

public class QuantumEntanglement : MonoBehaviour
{
    [SerializeField]
    private List<QuantumController> entangledParticles = new List<QuantumController>();

    [SerializeField]
    private float entanglementStrength = 1.0f;

    [SerializeField]
    private bool isEntangled = false;

    public void EntangleParticles(QuantumController particleA, QuantumController particleB)
    {
        if (!entangledParticles.Contains(particleA))
            entangledParticles.Add(particleA);

        if (!entangledParticles.Contains(particleB))
            entangledParticles.Add(particleB);

        isEntangled = true;
        Debug.Log($"Particles entangled. Total entangled particles: {entangledParticles.Count}");
    }

    public void Measure()
    {
        if (!isEntangled || entangledParticles.Count < 2)
            return;

        // When measuring one particle, all entangled particles collapse to the same state
        System.Random random = new System.Random();
        bool collapsedState = random.NextDouble() < 0.5f;

        foreach (var particle in entangledParticles)
        {
            if (particle != null)
            {
                // Force the quantum state to match the collapsed state
                while (particle.GetQuantumState() != collapsedState)
                {
                    particle.SendMessage("ToggleQuantumState", SendMessageOptions.DontRequireReceiver);
                }
            }
        }

        Debug.Log($"Measurement performed. All particles collapsed to state: {collapsedState}");
    }

    public void DisentangleAll()
    {
        entangledParticles.Clear();
        isEntangled = false;
        Debug.Log("All particles disentangled");
    }
}
