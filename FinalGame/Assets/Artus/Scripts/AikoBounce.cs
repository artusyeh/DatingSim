using System.Collections;
using UnityEngine;

public class AikoBounce : MonoBehaviour
{
    [Header("Bounce Settings")]
    public float bounceHeight = 0.25f;   // how high she jumps
    public float bounceDuration = 0.2f;  // time to go up or down
    public int bounceCount = 2;          // how many little hops

    private bool isBouncing = false;
    private Vector3 originalLocalPos;

    void Awake()
    {
        originalLocalPos = transform.localPosition;
    }


    public void PlayBounce()
    {
        if (isBouncing)
            return; 

        StartCoroutine(BounceRoutine());
    }

    private IEnumerator BounceRoutine()
    {
        isBouncing = true;

        for (int i = 0; i < bounceCount; i++)
        {
            // Jump up
            yield return MoveLocalY(originalLocalPos.y, originalLocalPos.y + bounceHeight, bounceDuration);
            // Fall down
            yield return MoveLocalY(originalLocalPos.y + bounceHeight, originalLocalPos.y, bounceDuration);
        }
        transform.localPosition = originalLocalPos;
        isBouncing = false;
    }

    private IEnumerator MoveLocalY(float fromY, float toY, float duration)
    {
        float t = 0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            float lerp = t / duration;
            float newY = Mathf.Lerp(fromY, toY, lerp);
            transform.localPosition = new Vector3(
                originalLocalPos.x,
                newY,
                originalLocalPos.z
            );
            yield return null;
        }
    }
}