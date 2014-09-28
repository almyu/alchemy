using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Element : MonoBehaviour {

    public GameObject effect;

    private bool picked;
    private Vector2 pickOffset, initialPosition;


    public static Vector2 GetWorldCursor() {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Awake() {
        initialPosition = transform.position;
    }

    private void OnMouseDown() {
        picked = true;
        pickOffset = (Vector2) transform.position - GetWorldCursor();
    }

    private void OnMouseUp() {
        picked = false;
        transform.position = initialPosition;

        if (Cauldron.instance.isHovered)
            Cauldron.instance.AddElement(this);
    }

    private void Update() {
        if (!picked) return;

        transform.position = GetWorldCursor() + pickOffset;
    }
}
