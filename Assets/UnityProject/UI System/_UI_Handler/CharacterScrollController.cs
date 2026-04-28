using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterScrollController : MonoBehaviour
{
    [Header("Scroll")]
    public ScrollRect scrollRect;

    [Header("Settings")]
    [Range(0f, 1f)]
    public float scrollStep = 0.33f;

    private float currentPos = 0f;

    public void ScrollRight()
    {
        currentPos += scrollStep;

        currentPos = Mathf.Clamp01(currentPos);

        MoveTo(currentPos);
    }

    public void ScrollLeft()
    {
        currentPos -= scrollStep;

        currentPos = Mathf.Clamp01(currentPos);

        MoveTo(currentPos);
    }

    void MoveTo(float targetPos)
    {
        StopAllCoroutines();
        StartCoroutine(SmoothScroll(targetPos));
    }

    IEnumerator SmoothScroll(float target)
    {
        float duration = 0.25f;
        float time = 0;

        float start = scrollRect.horizontalNormalizedPosition;

        while (time < duration)
        {
            time += Time.deltaTime;

            scrollRect.horizontalNormalizedPosition =
                Mathf.Lerp(start, target, time / duration);

            yield return null;
        }

        scrollRect.horizontalNormalizedPosition = target;
    }
}