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

        //建物を直して直したという履歴を残す
        public void RepairBuilding()
        {
            history = true;
            repairHistory.OnNext(history);
            brokenBuilding.SetActive(false);
            repairBuilding.SetActive(true);
        }

        //建物を壊す
        public void BuildingDestroy()
        {
            repairHistory.OnNext(false);
            brokenBuilding.SetActive(true);
            repairBuilding.SetActive(false);
        }

        //クリックされた時の処理
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