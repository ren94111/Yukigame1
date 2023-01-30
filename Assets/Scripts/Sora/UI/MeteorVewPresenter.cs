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

            //覐΂��~���Ă�����
            manager.GetMeteorFlag()
                .Subscribe(_ =>
                {
                    vew.OpneWindow(manager.GetMeteorAttackValue());
                });

            //�͂����������̃{�^������������
            vew.GetInterseptFlag()
                .Subscribe(x =>
                {
                    vew.CloseWindow();
                    manager.Broken(x);
                });

            //覐΂��}���ł������̊m�F�e�L�X�g
            manager.GetMeteorRezult()
                .Subscribe(x =>
                {
                    vew.RezultText(x);
                });
        }
    }
}