using Sora_Building;
using UniRx;

namespace Sora_Meteor
{
    public class MeteorModelPresenter
    {
        private bool firstCheck = false;

        private BuildingManger manager;
        private IReadMeteor model;

        public void Inject(BuildingManger _manager,IReadMeteor _meteor)
        {
            manager = _manager;
            model = _meteor;

            manager.GetMeteorCheck()
                .Where(flag => flag)
                .Subscribe(_ => 
                {
                    if (!firstCheck)
                    {
                        model.FirstMeteorTimer();
                        firstCheck = true;
                    }
                    else
                    {
                        model.ReStartTimer();
                    }
                });

            manager.GetMeteorCheck()
                .Where(flag => !flag)
                .Subscribe(_ =>
                {
                    model.StopTimer();
                });

            model.GetTimeEnd()
                .Subscribe(_ =>
                {
                    manager.Brokenbuild(model.GetMeteorAttack());
                    model.NextMeteorTimer();
                });
        }
    }
}