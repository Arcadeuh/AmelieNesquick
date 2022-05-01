using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private List<AbstractInteraction> interactions = new List<AbstractInteraction>();

    // Start is called before the first frame update
    void Start()
    {
        interactions = new List<AbstractInteraction>(gameObject.GetComponents<AbstractInteraction>());
        if (interactions.Count == 0)
        {
            Debug.LogError("No interactions on this gameobject");
        }
    }

    public void OnClick()
    {
        foreach(AbstractInteraction interaction in interactions)
        {
            interaction.DoInteraction();
        }
    }
}
