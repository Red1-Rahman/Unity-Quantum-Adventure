using UnityEngine;
using System;

public class QuantumController : MonoBehaviour
{
    [SerializeField]
    private bool quantumState = false;

    [SerializeField]
    private float superpositionProbability = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Quantum Controller initialized");
        InitializeQuantumState();
    }

    // Update is called once per frame
    void Update()
    {
        // Check for state change input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleQuantumState();
        }
    }

    private void InitializeQuantumState()
    {
        // Initialize quantum state with superposition probability
        System.Random random = new System.Random();
        quantumState = random.NextDouble() < superpositionProbability;
        Debug.Log($"Quantum state initialized to: {quantumState}");
    }

    private void ToggleQuantumState()
    {
        quantumState = !quantumState;
        Debug.Log($"Quantum state changed to: {quantumState}");
    }

    public bool GetQuantumState()
    {
        return quantumState;
    }
}
