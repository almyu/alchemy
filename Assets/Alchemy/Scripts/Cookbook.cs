using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class Cookbook : MonoSingleton<Cookbook> {

    public CookbookPage page {
        get { return GetComponentInChildren<CookbookPage>(); }
    }

    private void Awake() {
        bool setActive = true;

        foreach (Transform child in transform) {
            child.gameObject.SetActive(setActive);
            setActive = false;
        }
    }

    public void NextPage() {
        GameObject lastActive = null;

        foreach (Transform child in transform) {
            if (child.gameObject.activeSelf)
                lastActive = child.gameObject;

            else if (lastActive != null) {
                child.gameObject.SetActive(true);
                lastActive.SetActive(false);
                return;
            }
        }
    }

    public void PrevPage() {
        GameObject lastInactive = null;

        foreach (Transform child in transform) {
            if (!child.gameObject.activeSelf)
                lastInactive = child.gameObject;

            else if (lastInactive != null) {
                child.gameObject.SetActive(false);
                lastInactive.SetActive(true);
                return;
            }
        }
    }
}
