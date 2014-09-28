using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FrogReplacer : MonoBehaviour {

    private void Awake() {
        GameObject.Find("Frog").GetComponentInChildren<SpriteRenderer>().enabled = false;
    }

    private void OnDestroy() {
        var frog = GameObject.Find("Frog");
        if (frog)
            frog.GetComponentInChildren<SpriteRenderer>().enabled = true;
    }
}
