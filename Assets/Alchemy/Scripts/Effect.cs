using UnityEngine;

public class Effect : MonoBehaviour {

    public float lifetime = -1.0f;

    public void Awake() {
        //transform.parent = ...;
        //transform.position = ...;

        if (lifetime <= 0.0f)
            lifetime = EstimateLifetime();

        if (lifetime > 0.0f)
            Destroy(gameObject, lifetime);
    }

    public float EstimateLifetime() {
        var estimate = 0.0f;

        foreach (var ps in GetComponentsInChildren<ParticleSystem>())
            if (estimate < ps.startLifetime)
                estimate = ps.startLifetime;

        return estimate * 1.5f;
    }
}
