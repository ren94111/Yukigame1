using UniRx;
using Sora_Building;

namespace Sora_UI
{
    public class MeteorVewPresenter
    {
        private MeteorVew vew;
        private BuildingManger manager;

        public void Inject(MeteorVew _meteorVew, BuildingManger _manager)
        {
            vew = _meteorVew;
            manager = _manager;

            //隕石が降ってきたら
            manager.GetMeteorFlag()
                .Subscribe(_ =>
                {
                    vew.OpneWindow(manager.GetMeteorAttackValue());
                });

            //はいかいいえのボタンを押したら
            vew.GetInterseptFlag()
                .Subscribe(x =>
                {
                    vew.CloseWindow();
                    manager.Broken(x);
                });

            //隕石が迎撃できたかの確認テキスト
            manager.GetMeteorRezult()
                .Subscribe(x =>
                {
                    vew.RezultText(x);
                });
        }
    }
}