using UnityEngine;
using UniRx;

namespace Sora_Item {
    public class ItemDataPresesnter : MonoBehaviour
    {
        [SerializeField]
        private ItemController controller;

        private ItemDataModel model = new();

        void Start()
        {

            model.GetEndCreate()
                .Subscribe(_ => controller.SetInit(model.GetCreateLimit(),model));

            controller.GetItemCheck()
                .Subscribe(_ => model.GetItem());
                

            model.Init(controller.GetScriptableAddress());
        }
    }
}