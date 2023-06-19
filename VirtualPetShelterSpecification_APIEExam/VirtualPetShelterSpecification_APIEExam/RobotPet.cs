using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetShelterSpecification_APIEExam
{
    public class RobotPet : VirtualPet
    {
        int _maintenanceNeedLevel;
        public RobotPet(string petName) : base(petName) { }
        public RobotPet(string petName, int healthLevel, int happinessLevel, int maintenanceNeedLevel) : base(petName, healthLevel, happinessLevel)
        {
            _maintenanceNeedLevel = maintenanceNeedLevel;
        }
        public override void PlayWithPet() { }
        public override void FeedPet() { }
        public override bool AreNeedsTooHigh()
        {
            if (_happinessLevel < 10 || _healthLevel < 10 || _maintenanceNeedLevel > 40)
            {
                return true;
            }
            else return false;
        }
        // +++ Cant call this method ???
        public virtual void OilPet()
        {
            this._maintenanceNeedLevel = 0;
            this._maintenanceNeedLevel++;
            SetPropertyMaxValue();
        }
        public int GetMaintenanceNeedLevel(int maintenanceNeedLevel)
        {
            return _maintenanceNeedLevel;
        }
        public override void Tick()
        {
            _happinessLevel += 7;
            SetPropertyMaxValue();
        }
        public override void SetPropertyMaxValue()
        {
            base.SetPropertyMaxValue();
            if (_maintenanceNeedLevel > 50) { _maintenanceNeedLevel = 50; }
        }
        public override void SimulateRound() { }
    }
}
