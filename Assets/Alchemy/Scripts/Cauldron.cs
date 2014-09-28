using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[RequireComponent(typeof(CircleCollider2D))]
public class Cauldron : MonoSingleton<Cauldron> {

    public bool isHovered {
        get {
            var dist = Vector2.Distance(Element.GetWorldCursor(), transform.position);
            var coll = GetComponent<CircleCollider2D>();

            return dist <= coll.radius;
        }
    }

    public Element frog;
    public GameObject[] failEffects;

    [System.Serializable]
    public class ElementEvent : UnityEvent<Element> {}
    public ElementEvent onPut;

    public UnityEvent onFrogPut;

    [HideInInspector]
    public List<Element> elements;

    public void Clear() {
        elements.Clear();
    }

    public void AddElement(Element e) {
        if (e == frog) {
            var combo = CheckCombo();
            if (combo != null)
                combo.Apply();
            else
                Instantiate(failEffects[Random.Range(0, failEffects.Length)]);

            onFrogPut.Invoke();
            return;
        }

        elements.Add(e);

        if (e.effect != null)
            Instantiate(e.effect);
        else
            Debug.Log("Element " + e.name + " put");

        onPut.Invoke(e);
    }

    public Combination CheckCombo() {
        foreach (var candidate in FindObjectsOfType<Combination>())
            if (candidate.Equals(elements))
                return candidate;

        return null;
    }
}
