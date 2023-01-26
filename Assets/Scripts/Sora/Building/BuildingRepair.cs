using Sora_Item;

namespace Sora_Building
{
    public interface IReadBuidingRepair
    {
        bool RepairCheck();
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

        public bool RepairCheck()
        {
            return dataModel.BuildingRepairCheck(requiredValue);
        }

        public void Repair()
        {
            dataModel.Repair(requiredValue);
            requiredValue += addValue;
        }
    }
}