using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class ElementDisplay : MonoBehaviour {

    public RectTransform template;
    public int groupSize = 3;

    public void Clear() {
        for (int i = transform.childCount; i-- > 0; )
            DestroyImmediate(transform.GetChild(i).gameObject);
    }

    public void Add(Element e) {
        var obj = (RectTransform) Instantiate(template);
        obj.gameObject.SetActive(true);
        GetComponent<RectTransform>().AddChild(obj);

        var n = transform.childCount - 1;
        obj.anchoredPosition = Vector2.right * obj.sizeDelta.x * (n + n / groupSize * 0.5f);

        obj.GetComponentInChildren<Image>().sprite = e.GetComponent<SpriteRenderer>().sprite;
    }
}
