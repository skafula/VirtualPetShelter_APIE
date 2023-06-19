using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetShelterSpecification_APIEExam
{
    public class OrganicCat : OrganicPet
    {
        string PetName { get; set; }
        int HealthLevel { get; set; } 
        int HappinessLevel { get; set; } 
        int HungerLevel { get; set; }
        int ThirstLevel { get; set; }
        int WasteLevel { get; set; }
        public OrganicCat(string name) : base(name)
        {
            PetName = name;
            HealthLevel = 50;
            HappinessLevel = 10;
            HungerLevel = 50;
            ThirstLevel = 40;
            WasteLevel = 25;
        }
        public OrganicCat(string petName, int healthLevel, int happinessLevel, int hungerLevel, int thirstLevel, int wasteLevel) : base(petName, healthLevel, happinessLevel, hungerLevel, thirstLevel, wasteLevel) 
        {
            PetName = petName;
            HealthLevel = healthLevel;
            HappinessLevel = happinessLevel;
            HungerLevel = hungerLevel;
            ThirstLevel = thirstLevel;
            WasteLevel = wasteLevel;
        }
        public override bool AreNeedsTooHigh()
        {
            if (HungerLevel > 40 || ThirstLevel > 40 || HappinessLevel < 40 || HealthLevel < 10 || WasteLevel > 40)
            {
                return true;
            }
            else return false;
        }
        public override void FeedPet()
        {
            HungerLevel = 0;
            WasteLevel += 10;
            SetPropertyMaxValue();
        }
        public override void GivePetWater()
        {
            ThirstLevel = 0;
            WasteLevel += 5;
            SetPropertyMaxValue();
        }
        public override void PlayWithPet()
        {
            // +++ NEED TO CHECK IF IT WORKS PROPERLY +++
            HungerLevel += 5;
            ThirstLevel += 7;
            HealthLevel += 5;
            HappinessLevel += 10;
            WasteLevel++;
            SetPropertyMaxValue();
        }
        public override void WastePet()
        {
            WasteLevel = 0;
            HappinessLevel += 8;
            ThirstLevel += 5;
            HungerLevel += 10;
            SetPropertyMaxValue();
        }
        // Return string to print data of the animal

        // IMO it doesn't need to inherite from OrganicPet so i only make this method at this final level
        public override string ToString()
        {
            return $"Név: {PetName}\nÉleterő: {HealthLevel}\nBoldogság: {HappinessLevel}\nÉhség: {HungerLevel}\nSzomjúság: {ThirstLevel}\nElhanyagoltság: {WasteLevel}";
        }
        public override void SetPropertyMaxValue()
        {
            if (HealthLevel > 50) { HealthLevel = 50; }
            if (HappinessLevel > 50) { HappinessLevel = 50; }
            if (HungerLevel > 50) { HungerLevel = 50; }
            if (ThirstLevel > 50) { ThirstLevel = 50; }
            if (WasteLevel < 0) { WasteLevel = 0; }
        }
        public override void SimulateRound()
        {
            HealthLevel -= 5;
            if (HealthLevel < 1) { HealthLevel = 1; }
            HappinessLevel -= 5;
            if (HappinessLevel < 1) { HappinessLevel = 1; }
            HungerLevel += 5;
            ThirstLevel += 5;
            WasteLevel += 5;
            SetPropertyMaxValue();
        }
    }
}
