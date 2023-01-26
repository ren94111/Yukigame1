using UnityEngine;
using Sora_Item;

namespace Sora_Building
{
    public class BuildingController : MonoBehaviour
    {
        [SerializeField]
        private GameObject brokenBuilding;

        [SerializeField]
        private GameObject repairBuilding;

        private bool repairHistory = false;

        private RepairPresenter presenter = new();

        private void Start()
        {
            presenter.Inject(new BuildingRepair(new ItemDataModel()),this);
        }

        public void RepairBuilding()
        {
            repairHistory = true;
        }
    }
}