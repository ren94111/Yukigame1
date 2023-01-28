using UnityEngine;
using Sora_Item;
using UniRx;
using System;

namespace Sora_Building
{
    public class BuildingController : MonoBehaviour
    {
        [SerializeField]
        private GameObject brokenBuilding;

        [SerializeField]
        private GameObject repairBuilding;

        private bool history = false;
        private Subject<bool> repairHistory = new();

        private RepairPresenter presenter = new();

        private void Start()
        {
            brokenBuilding.SetActive(true);
            repairBuilding.SetActive(false);
            presenter.Inject(new BuildingRepair(new ItemDataModel()),this);
        }

        public void RepairBuilding()
        {
            history = true;
            repairHistory.OnNext(history);
            brokenBuilding.SetActive(false);
            repairBuilding.SetActive(true);
        }

        public void BuildingDestroy()
        {
            history = false;
            repairHistory.OnNext(history);
            brokenBuilding.SetActive(true);
            repairBuilding.SetActive(false);
        }

        public void ClickThis()
        {
            presenter.RepairCheck(history);
        }

        public IObservable<bool> GetRepairHistory()
        {
            return repairHistory;
        }
    }
}