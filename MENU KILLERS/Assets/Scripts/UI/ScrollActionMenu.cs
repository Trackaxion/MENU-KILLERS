using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollActionMenu : MonoBehaviour
{
    public ScrollRect scrollRect;
    public RectTransform viewportRect;
    public GameObject lastSelected;
    public GameObject firstSelectedButton;

    void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(firstSelectedButton);
    }

    void Start()
    {
        viewportRect = scrollRect.viewport;
    }

    void Update()
    {
        GameObject currentSelected = EventSystem.current.currentSelectedGameObject;

        if (currentSelected == null || currentSelected == lastSelected) return;

        // Verify the selected object belongs to this specific ScrollRect content
        if (currentSelected.transform.IsChildOf(scrollRect.content))
        {
            lastSelected = currentSelected; // Update lastSelected BEFORE scrolling to avoid loops
            UpdateScrollPosition(currentSelected.GetComponent<RectTransform>());
        }
    }

    void UpdateScrollPosition(RectTransform target)
    {
        // Calculate the target's position relative to the viewport
        Vector3 targetLocalPos = viewportRect.InverseTransformPoint(target.position);

        float viewportHeight = viewportRect.rect.height;
        float contentHeight = scrollRect.content.rect.height;

        if (contentHeight <= viewportHeight) return;

        // Normalize the position between 0 and 1 for the vertical scrollbar
        float currentScrollObjY = scrollRect.content.anchoredPosition.y + targetLocalPos.y;
        float targetNormalizedY = 1f - (-currentScrollObjY / (contentHeight - viewportHeight));

        // Clamp values to keep scrollbar in normal 0-1 boundaries
        scrollRect.verticalNormalizedPosition = Mathf.Clamp01(targetNormalizedY);
    }
}
