using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class Combination : MonoBehaviour {

    public Element[] elements;
    public GameObject effect;

    public bool Equals(IEnumerable<Element> otherElements) {
        return Enumerable.SequenceEqual(elements, otherElements);
    }

    public void Apply() {
        if (effect != null)
            Instantiate(effect);
        else
            Debug.Log("Combination " + name + "!");
    }
}
