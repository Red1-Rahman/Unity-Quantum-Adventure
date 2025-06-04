using UnityEngine;

public class QuantumParticle : MonoBehaviour
{
    [SerializeField]
    private float oscillationSpeed = 2.0f;
    [SerializeField]
    private float oscillationMagnitude = 0.5f;

    private Vector3 startPosition;
    private float randomPhase;
    void Start()
    {
        startPosition = transform.position;
        randomPhase = Random.Range(0f, 2f * Mathf.PI);
    }

    void Update()
    {
        // Quantum wave-like motion
        float yOffset = Mathf.Sin(Time.time * oscillationSpeed + randomPhase) * oscillationMagnitude;
        transform.position = startPosition + new Vector3(0f, yOffset, 0f);
    }

    public void Collapse()
    {
        // Collapse the particle to a specific state
        transform.position = startPosition;
        enabled = false;
    }
}
