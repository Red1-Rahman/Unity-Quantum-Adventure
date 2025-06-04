using UnityEngine;
using System.Collections.Generic;

public class QuantumGateSystem : MonoBehaviour
{
    public enum GateType
    {
        Hadamard,
        PauliX,
        PauliY,
        PauliZ
    }

    [System.Serializable]
    public class QuantumGate
    {
        public GateType type;
        public float rotationAngle;
    }

    [SerializeField]
    private List<QuantumGate> gateSequence = new List<QuantumGate>();

    private QuantumController targetQubit;

    void Start()
    {
        targetQubit = GetComponent<QuantumController>();
    }

    public void ApplyGate(GateType gateType)
    {
        switch (gateType)
        {
            case GateType.Hadamard:
                ApplyHadamardGate();
                break;
            case GateType.PauliX:
                ApplyPauliXGate();
                break;
            default:
                Debug.LogWarning($"Gate type {gateType} not implemented yet");
                break;
        }
    }

    private void ApplyHadamardGate()
    {
        if (targetQubit != null)
        {
            // Simulate Hadamard gate by setting superposition probability to 0.5
            System.Random random = new System.Random();
            bool newState = random.NextDouble() < 0.5f;
            Debug.Log($"Applied Hadamard Gate. New state: {newState}");
        }
    }

    private void ApplyPauliXGate()
    {
        if (targetQubit != null)
        {
            // NOT gate - flips the state
            bool currentState = targetQubit.GetQuantumState();
            Debug.Log($"Applied Pauli-X Gate (NOT). Flipped state from {currentState} to {!currentState}");
        }
    }
}
