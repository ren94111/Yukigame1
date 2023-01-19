using UnityEngine;
using UnityEngine.InputSystem;
using Sora_Item;

namespace Sora_PlayerInput
{
    public class PlayerInput : MonoBehaviour
    {
        private Vector2 mousePos = Vector2.zero;

        public void GetMousePos(InputAction.CallbackContext context)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            RaycastHit2D hit;

            if (Physics2D.Raycast(mousePos, out hit,100))
            {
                if (hit.transform.CompareTag("Item"))
                {
                    hit.transform.GetComponent<GetItem>().OnClickThis();
                }
            }
        }
    }
}