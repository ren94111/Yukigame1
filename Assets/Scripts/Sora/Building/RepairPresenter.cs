using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Sora_Building
{
    public class RepairPresenter
    {
        private static IReadBuidingRepair buidingRepair;

        private BuildingController controller;

        public void Inject(IReadBuidingRepair _readRepair,BuildingController _controller)
        {
            if (buidingRepair == null)
            {
                buidingRepair = _readRepair;
            }
            controller = _controller;
        }

        //直せるなら直す
        public void RepairCheck()
        {
            if (buidingRepair.RepairCheck())
            {
                controller.RepairBuilding();
            }
        }

    }
}