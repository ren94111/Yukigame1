using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sora_UI;
using Sora_Item;
using Sora_Building;

namespace Sora_System
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField]
        private ScoreVew vew;

        [SerializeField]
        private BuildingManger manager;

        private ScoreDataPresenter presenter = new();

        void Start()
        {
            IReadItemData item = new ItemDataModel();
            presenter.Inject(item, vew);
            manager.Inject(new ResultModel(), new BuildingRepair(item));
        }
    }
}