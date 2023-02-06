using UnityEngine;
using Sora_UI;
using Sora_Item;
using Sora_Building;
using Sora_Meteor;
using Sora_Field;
using Sora_System;
using SceneaManger;

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

        [SerializeField]
        private SceneChengeView sceneChengeView;

        [SerializeField]
        private SceneChengeController sceneChengeController;

        [SerializeField]
        private SceneManagerController sceneManagerController;

        private ScoreDataPresenter presenter = new();
        private MeteorModelPresenter meteorPresenter = new();
        private MeteorVewPresenter meteorVewPresenter = new();

        private MeteorModel meteorModel;
        private SceneChengePresenter sceneChengePresenter = new();
        private SceneMangerPresenter sceneMangerPresenter = new();
        private SceneChengeControllerPresenter sceneChengeControllerPresenter = new();

        void Start()
        {
            meteorModel = new MeteorModel(obj);
            IReadItemData item = new ItemDataModel();
            IReadSceneChaege sceneChenge = new SceneChenge();
            presenter.Inject(item, vew);
            manager.Inject(new ResultModel(), new BuildingRepair(item));
            meteorPresenter.Inject(manager, meteorModel);
            meteorVewPresenter.Inject(meteorVew, manager);
            sceneChengePresenter.Inject(sceneChenge, sceneChengeView);
            sceneChengeControllerPresenter.Inject(sceneChenge, sceneChengeController);
            sceneMangerPresenter.Inject(sceneManagerController,new ResultModel());
        }

        private void OnDestroy() {
            presenter.DestroyThis();
            manager.Dispose();
            sceneChengePresenter.Dispose();
            sceneChengeControllerPresenter.Dispose();
            sceneMangerPresenter.Dispose();
            meteorModel.EndTimer();
        }
    }
}