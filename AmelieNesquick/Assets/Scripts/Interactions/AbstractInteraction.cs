using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
public abstract class AbstractInteraction : MonoBehaviour
{

    public virtual void DoInteraction()
    {
        Debug.Log("INTERACTION WAW !");
    }
}
