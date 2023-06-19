using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetShelterSpecification_APIEExam
{
    public class OrganicPet : VirtualPet
    {
        int _hungerLevel;
        int _thirstLevel;
        public int _wasteLevel;
        public OrganicPet(string name) : base(name)
        {

        }
        public OrganicPet(string petName, int healthLevel, int happinessLevel, int hungerLevel, int thirstLevel, int wasteLevel) : base(petName, healthLevel, happinessLevel)
        {
            _hungerLevel = hungerLevel;
            _thirstLevel = thirstLevel; 
            _wasteLevel = wasteLevel;
        }

        public int GetHungerLevel() 
        {
            return _hungerLevel;
        }
        public int GetThirstLevel() 
        {
            return _thirstLevel;
        }
        public int GetWateLevel()
        {
            return _wasteLevel;
        }
        public override void FeedPet()
        {
            _hungerLevel = 0;
            _wasteLevel += 10;
            SetPropertyMaxValue();
        }
        public virtual void GivePetWater()
        {
            _thirstLevel = 0;
            _wasteLevel += 5;
            SetPropertyMaxValue();
        }
        public override void PlayWithPet() { }
        public override bool AreNeedsTooHigh()
        {
            if (_hungerLevel > 40 || _thirstLevel > 40 || _happinessLevel < 40 || _healthLevel < 10 || _wasteLevel > 40)
            {
                return true;
            }
            else return false;
        }
        // +?+?+? Added it optionalli to make a method for VirtualPetHostel.BathroomBreak();
        public virtual void WastePet()
        {
            _wasteLevel = 0;
            _happinessLevel += 8;
            _thirstLevel += 5;
            _hungerLevel += 10;
            SetPropertyMaxValue();
        }
        public override void Tick()
        {
            _happinessLevel += 15;
            SetPropertyMaxValue();
        }
        public override void SetPropertyMaxValue()
        {
            base.SetPropertyMaxValue();
            if (_hungerLevel > 50) { _hungerLevel = 50; }
            if (_thirstLevel > 50) { _thirstLevel = 50; }
            if (_wasteLevel < 0) { _wasteLevel = 0; }
        }
        public override void SimulateRound() { }
    }
}
