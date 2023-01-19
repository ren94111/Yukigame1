using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sora_Item
{
    public class GetItem : MonoBehaviour
    {
        private ItemController controller;

        public void Init(ItemController _controller)
        {
            controller = _controller;
        }

        public void OnClickThis()
        {
            controller.GetItem(this.gameObject);
        }
    }
}