using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleSorter : MonoBehaviour {

    public string sortingLayerName;
    public int sortingOrder;

    private void Awake() {
        var ren = GetComponent<ParticleSystem>().GetComponent<Renderer>();

        ren.sortingLayerName = sortingLayerName;
        ren.sortingOrder = sortingOrder;
    }
}
