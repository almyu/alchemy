using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class ElementDisplay : MonoBehaviour {

    public RectTransform template;

    public void Clear() {
        for (int i = transform.childCount; i-- > 0; )
            DestroyImmediate(transform.GetChild(i).gameObject);
    }

    public void Add(Element e) {
        var obj = (RectTransform) Instantiate(template);
        obj.gameObject.SetActive(true);
        GetComponent<RectTransform>().AddChild(obj);

        obj.pivot = Vector2.right * (1 - transform.childCount);
        obj.anchoredPosition = Vector2.zero;

        obj.GetComponentInChildren<Image>().sprite = e.GetComponent<SpriteRenderer>().sprite;
    }
}
