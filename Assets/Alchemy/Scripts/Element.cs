using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Element : MonoBehaviour {

    public GameObject effect;
    public float flightSmoothness = 5.0f;

    private bool picked, returning;
    private Vector2 pickOffset, initialPosition;


    public static Vector2 GetWorldCursor() {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Awake() {
        initialPosition = transform.position;
    }

    private void OnMouseDown() {
        returning = false;
        picked = true;
        pickOffset = (Vector2) transform.position - GetWorldCursor();
    }

    private void OnMouseUp() {
        picked = false;

        if (Cauldron.instance.isHovered) {
            Cauldron.instance.AddElement(this);
            transform.position = initialPosition;
        }
        else {
            returning = true;
        }
    }

    private void Update() {
        if (picked)
            transform.position = GetWorldCursor() + pickOffset;
        else if (returning) {
            transform.position = Vector2.Lerp(transform.position, initialPosition, Time.deltaTime * flightSmoothness);

            if ((Vector2) transform.position == initialPosition)
                returning = false;
        }
    }
}
