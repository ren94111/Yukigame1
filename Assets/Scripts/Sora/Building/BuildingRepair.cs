using Sora_Item;
using UnityEngine;

namespace Sora_Building
{
    public interface IReadBuidingRepair
    {
        bool RepairCheck(bool _fixed);
        bool InterseptCheck(int _value);
        void Repair();
    }

    public class BuildingRepair : IReadBuidingRepair
    {
        private static int requiredValue = 5;
        private static int addValue = 5;

        private IReadItemData dataModel;

        public BuildingRepair(IReadItemData _data)
        {
            dataModel = _data;
        }

        public bool RepairCheck(bool _fixed)
        {
            if (_fixed)
            {
                int temp = (int)(requiredValue * 1.5f);
                return dataModel.BuildingRepairCheck(temp);
            }
            else
            {
                return dataModel.BuildingRepairCheck(requiredValue);
            }
        }

        public bool InterseptCheck(int _value)
        {
            return dataModel.BuildingRepairCheck(_value);
        }

        public void Repair()
        {
            dataModel.Repair(requiredValue);
            requiredValue += addValue;
        }
    }
}