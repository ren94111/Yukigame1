using Sora_Item;

namespace Sora_Building
{
    public interface IReadBuidingRepair
    {
        bool RepairCheck(bool _fixed);
        void Repair();
    }

    public class BuildingRepair : IReadBuidingRepair
    {
        private int requiredValue = 5;
        private int addValue = 5;

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

        public void Repair()
        {
            dataModel.Repair(requiredValue);
            requiredValue += addValue;
        }
    }
}