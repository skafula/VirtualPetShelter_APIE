using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetShelterSpecification_APIEExam
{
    public class RobotCat : RobotPet
    {
        string PetName { get; set; }
        int HealthLevel { get; set; }
        int HappinessLevel { get; set; }
        int MaintenanceNeedLevel { get; set; }
        public RobotCat(string petName) : base(petName)
        {
            PetName = petName;
            HealthLevel = 50;
            HappinessLevel = 50;
            MaintenanceNeedLevel = 25;
        }
        public RobotCat(string petName, int healthLevel, int happinessLevel, int maintenanceNeedLevel) : base(petName, healthLevel, happinessLevel, maintenanceNeedLevel)
        {
            PetName = petName;
            HealthLevel = healthLevel;
            HappinessLevel = happinessLevel;
            MaintenanceNeedLevel = maintenanceNeedLevel;
        }
        public override void OilPet()
        {
            MaintenanceNeedLevel = 0;
            MaintenanceNeedLevel++;
            SetPropertyMaxValue();
        }
        public override bool AreNeedsTooHigh()
        {
            if (HappinessLevel < 10 || HealthLevel < 10 || MaintenanceNeedLevel > 40)
            {
                return true;
            }
            else return false;
        }
        public override void PlayWithPet()
        {
            // +++ NEED TO CHECK IF IT WORKS PROPERLY +++
            HealthLevel += 5;
            HappinessLevel += 10;
            MaintenanceNeedLevel += 10;
            SetPropertyMaxValue();
        }
        // Return string to print data of the animal

        // IMO it doesn't need to inherite from OrganicPet so i only make this method at this final level
        public override string ToString()
        {
            return $"Név: {PetName}\nÉleterő: {HealthLevel}\nBoldogság: {HappinessLevel}\nKarbantartási szükséglet szintje: {MaintenanceNeedLevel}";
        }
        public override void SetPropertyMaxValue()
        {
            if (HealthLevel > 50) { HealthLevel = 50; }
            if (HappinessLevel > 50) { HappinessLevel = 50; }
            if (MaintenanceNeedLevel > 50) { MaintenanceNeedLevel = 50; }
        }
        public override void SimulateRound()
        {
            HealthLevel -= 5;
            if (HealthLevel < 1) { HealthLevel = 1; }
            HappinessLevel -= 5;
            if (HappinessLevel < 1) { HappinessLevel = 1; }
            MaintenanceNeedLevel += 5;
            SetPropertyMaxValue();
        }
    }
}
