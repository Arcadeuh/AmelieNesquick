using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumpInteraction : AbstractInteraction
{
    public AnimationCurve bumpCurve;
    public float bumpTime = 0.5f;

    private Vector3 initScale;

    private void Start()
    {
        initScale = transform.localScale;
    }

    public override void DoInteraction()
    {
        StartCoroutine(Bump());
        Debug.Log("BUMP INTERACTION");
    }

    IEnumerator Bump()
    {
        float currentTime = 0.0f;
        while (currentTime < bumpTime)
        {
            currentTime += Time.deltaTime;
            float valueEvaluated = bumpCurve.Evaluate(currentTime / bumpTime);
            transform.localScale = new Vector3(
                valueEvaluated * initScale.x,
                valueEvaluated * initScale.y,
                initScale.z
            );
            yield return null;
        }
    }
}
