using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMouseClick : MonoBehaviour
{
    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started){ return; }
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        if (hit.collider != null)
        {
            Interactable interactable = null;
            hit.collider.gameObject.TryGetComponent<Interactable>(out interactable);
            if (interactable == null) { return; }

            interactable.OnClick();
        }
    }
}
