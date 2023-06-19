using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetShelterSpecification_APIEExam
{
    public class OrganicDog : OrganicPet
    {
        string PetName { get; set; }
        int HealthLevel { get; set; }
        int HappinessLevel { get; set; }
        int HungerLevel { get; set; }
        int ThirstLevel { get; set; }
        int WasteLevel { get; set; }
        int CageSoilLevel { get; set; }
        public OrganicDog(string name) : base(name) 
        {
            PetName = name;
            HealthLevel = 50;
            HappinessLevel = 10;
            HungerLevel = 50;
            ThirstLevel = 40;
            WasteLevel = 25;
            CageSoilLevel = 0;
        }
        public OrganicDog(string petName, int healthLevel, int happinessLevel, int hungerLevel, int thirstLevel, int wasteLevel, int cageSoilLevel) : base(petName, healthLevel, happinessLevel, hungerLevel, thirstLevel, wasteLevel)
        {
            PetName = petName;
            HealthLevel = healthLevel;
            HappinessLevel = happinessLevel;
            HungerLevel = hungerLevel;
            ThirstLevel = thirstLevel;
            WasteLevel = wasteLevel;
            CageSoilLevel = cageSoilLevel;
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
        // Return string to print data of the animal

        // IMO it doesn't need to inherite from OrganicPet so i only make this method at this final level
        public override string ToString()
        {
            return $"Név: {PetName}\nÉleterő: {HealthLevel}\nBoldogság: {HappinessLevel}\nÉhség: {HungerLevel}\nSzomjúság: {ThirstLevel}\nElhanyagoltság: {WasteLevel}\nKetrecSzint: {CageSoilLevel}";
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
        public void Walk()
        {
            HealthLevel += 15;
            HappinessLevel += 10;
            HungerLevel += 10;
            ThirstLevel += 15;
            WasteLevel = 0;

        }
        public override bool AreNeedsTooHigh()
        {
            if (HungerLevel > 40 || ThirstLevel > 40 || HappinessLevel < 40 || HealthLevel < 10 || WasteLevel > 40)
            {
                return true;
            }
            else return false;
        }
        public override void WastePet()
        {
            WasteLevel = 0;
            HappinessLevel += 8;
            ThirstLevel += 5;
            HungerLevel += 10;
            SetPropertyMaxValue();
        }
        public void CleanOrganicDogCage()
        {
            CageSoilLevel = 0;
            HappinessLevel += 15;
            SetPropertyMaxValue();
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
