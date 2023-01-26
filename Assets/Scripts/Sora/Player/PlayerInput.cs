using UnityEngine;
using UnityEngine.InputSystem;
using Sora_Item;
using Sora_Building;

namespace Sora_PlayerInput
{
    public class PlayerInput : MonoBehaviour
    {
        private Vector2 mousePos = Vector2.zero;

        public void GetMousePos(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                //mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, 100);

                if (hit.collider)
                {
                    if (hit.transform.CompareTag("Item"))
                    {
                        hit.transform.GetComponent<GetItem>().OnClickThis();
                    }
                    else if(hit.collider.CompareTag("Building"))
                    {
                        hit.transform.GetComponentInParent<BuildingController>().ClickThis();
                    }
                }
            }
        }
    }
}