using UnityEngine;
using Sora_UI;
using Sora_Item;
using Sora_Building;
using Sora_Meteor;

namespace Sora_System
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField]
        private MeteorData obj;

        [SerializeField]
        private ScoreVew vew;

        [SerializeField]
        private BuildingManger manager;

        [SerializeField]
        private MeteorVew meteorVew;

        private ScoreDataPresenter presenter = new();
        private MeteorModelPresenter meteorPresenter= new();
        private MeteorVewPresenter meteorVewPresenter = new();

        void Start()
        {
            IReadItemData item = new ItemDataModel();
            presenter.Inject(item, vew);
            manager.Inject(new ResultModel(), new BuildingRepair(item));
            meteorPresenter.Inject(manager, new MeteorModel(obj));
            meteorVewPresenter.Inject(meteorVew, manager);
        }
    }
}