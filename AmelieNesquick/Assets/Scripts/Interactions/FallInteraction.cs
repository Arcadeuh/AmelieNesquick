using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FallInteraction : AbstractInteraction
{
    public float fallSpeed = 5.0f;
    public bool onlyFallOnSameLevel = false;

    [SerializeField] private UnityEvent breakEvent = new UnityEvent();
    private bool flag = false;

    public override void DoInteraction()
    {
        if (flag) { return; }
        Debug.Log("FALL INTERACTION");
        flag = true;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, Mathf.Infinity, LayerMask.GetMask("Ground"));
        float distance = hit.distance - GetComponent<SpriteRenderer>().bounds.size.y / 2;
        //StartCoroutine(RotateIt());

        if (hit.collider == null) { return; }

        StartCoroutine(MakeItFall(distance));
    }

    IEnumerator MakeItFall(float distance)
    {
        float currentDistance = distance;
        float initRotation = transform.localRotation.z;

        if (distance > 0 && !onlyFallOnSameLevel)
        {
            while (currentDistance > 0)
            {
                currentDistance -= fallSpeed * Time.deltaTime;
                transform.localPosition = new Vector3(
                    transform.position.x,
                    transform.position.y - fallSpeed * Time.deltaTime,
                    transform.position.z
                );
                transform.localRotation = Quaternion.Euler(new Vector3(
                    transform.localRotation.x,
                    transform.localRotation.y,
                    initRotation + (distance - currentDistance) / distance * 90
                ));
                yield return null;
            }
        }
        else
        {
            float rotationAdded = 0.0f;
            while (rotationAdded < 90)
            {
                rotationAdded += 750 * Time.deltaTime;
                transform.localRotation = Quaternion.Euler(new Vector3(
                    transform.localRotation.x,
                    transform.localRotation.y,
                    initRotation + rotationAdded
                ));
                yield return null;
            }
        }
        breakEvent.Invoke();
    }
}
