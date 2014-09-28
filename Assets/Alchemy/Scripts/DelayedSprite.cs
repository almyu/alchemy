using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class DelayedSprite : MonoBehaviour {

    public float delay = 1.0f;

    private void Awake() {
        GetComponent<SpriteRenderer>().enabled = false;
        Invoke("Show", delay);
    }

    private void Show() {
        GetComponent<SpriteRenderer>().enabled = true;
    }
}
