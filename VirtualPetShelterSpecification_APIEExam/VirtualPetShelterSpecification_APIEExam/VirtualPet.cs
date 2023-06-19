using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetShelterSpecification_APIEExam
{
    public abstract class VirtualPet
    {
        string _petName;
        public int _healthLevel;
        public int _happinessLevel;
        public VirtualPet(string petName) 
        { 
            _petName = petName;
            _happinessLevel = 50;
        }
        public VirtualPet(string petName, int healthLevel, int happinessLevel)
        {
            _petName = petName;
            _healthLevel = healthLevel;
            _happinessLevel = happinessLevel;
        }
        public string GetPetName()
        {
            return _petName;
        }
        public int GetHealthLevel()
        {
            return _healthLevel;
        }
        public int GetHappinessLevel()
        {
            return _happinessLevel;
        }
        // Probably a virtual could be better to fine tuning the values 
        public abstract void PlayWithPet();
        public abstract void FeedPet();
        public abstract bool AreNeedsTooHigh();
        public abstract void Tick();
        public abstract void SimulateRound();
        public override string ToString()
        {
            return $"Név: {this._petName}\nÉleterő: {this._healthLevel}\nBoldogság: {this._happinessLevel}";
        }
        // ??? I made it to code less to set Properties' max value ???
        public virtual void SetPropertyMaxValue()
        {
            if (_healthLevel > 50) { _healthLevel = 50; }
            if (_happinessLevel > 50) { _happinessLevel = 50; }
        }
    }
}
