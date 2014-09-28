using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D), typeof(SpriteRenderer))]
public class Element : MonoBehaviour {

    public GameObject effect;
    public float flightSmoothness = 5.0f;
    public int pickedOrder = 10;

    private SpriteRenderer cachedRenderer;
    private int initialOrder;
    private bool picked, returning;
    private Vector2 pickOffset, initialPosition;


    public static Vector2 GetWorldCursor() {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Awake() {
        cachedRenderer = GetComponent<SpriteRenderer>();
        initialOrder = cachedRenderer.sortingOrder;

        initialPosition = transform.position;
    }

    private void OnMouseDown() {
        returning = false;
        picked = true;
        pickOffset = (Vector2) transform.position - GetWorldCursor();
        cachedRenderer.sortingOrder = pickedOrder;
    }

    private void OnMouseUp() {
        picked = false;
        cachedRenderer.sortingOrder = initialOrder;

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
