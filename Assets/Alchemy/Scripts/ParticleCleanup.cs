using UnityEngine;

public class ParticleCleanup : MonoBehaviour {

    public void Cleanup() {
        foreach (var ps in FindObjectsOfType<ParticleSystem>())
            if (ps)
                Destroy(ps.gameObject);
    }
}
