using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetShelterSpecification_APIEExam
{
    public class VirtualPetHostel
    {
        VirtualPet VirtualPet { get; set; } // ???

        Random random = new Random();

        public List<VirtualPet> allPetsInShelter;
        public VirtualPetHostel() 
        {
            allPetsInShelter = new List<VirtualPet>();
            AddInitialPetsToShelter();
        }
        public void AddInitialPetsToShelter()
        {
            allPetsInShelter.Add(new RobotDog("RobOtika", random.Next(1,51), random.Next(1, 51), random.Next(1, 51)));
            allPetsInShelter.Add(new RobotDog("RobOsztus", random.Next(1, 51), random.Next(1, 51), random.Next(1, 51)));
            allPetsInShelter.Add(new RobotDog("RobBanás", random.Next(1, 51), random.Next(1, 51), random.Next(1, 51)));
            allPetsInShelter.Add(new RobotCat("RobAj", random.Next(1, 51), random.Next(1, 51), random.Next(1, 51)));
            allPetsInShelter.Add(new RobotCat("RobInhood", random.Next(1, 51), random.Next(1, 51), random.Next(1, 51)));
            allPetsInShelter.Add(new RobotCat("RobErtgida", random.Next(1, 51), random.Next(1, 51), random.Next(1, 51)));
            allPetsInShelter.Add(new OrganicDog("OrgOgre", random.Next(1, 51), random.Next(1, 51), random.Next(1, 51), random.Next(1,51), random.Next(1,51), random.Next(1, 51)));
            allPetsInShelter.Add(new OrganicDog("OrgVillám", random.Next(1, 51), random.Next(1, 51), random.Next(1, 51), random.Next(1, 51), random.Next(1, 51), random.Next(1, 51)));
            allPetsInShelter.Add(new OrganicDog("OrgCaesar", random.Next(1, 51), random.Next(1, 51), random.Next(1, 51), random.Next(1, 51), random.Next(1, 51), random.Next(1, 51)));
            allPetsInShelter.Add(new OrganicCat("OrgLili", random.Next(1, 51), random.Next(1, 51), random.Next(1, 51), random.Next(1, 51), random.Next(1, 51)));
            allPetsInShelter.Add(new OrganicCat("OrgAnic", random.Next(1, 51), random.Next(1, 51), random.Next(1, 51), random.Next(1, 51), random.Next(1, 51)));
            allPetsInShelter.Add(new OrganicCat("OrgOna", random.Next(1, 51), random.Next(1, 51), random.Next(1, 51), random.Next(1, 51), random.Next(1, 51)));
        }
        // Optional to check if any pet has 0 happiness to end the game
        public bool IsAnyPetHappinessZero()
        {
            foreach (var pet in allPetsInShelter)
            {
                if (pet.GetHappinessLevel() == 0)
                {
                    return true;
                }
            }
            return false;
        }
        public void ListAllPetsInShelter()
        {
            foreach (var p in allPetsInShelter)
            {
                Console.WriteLine(p.ToString());
                Console.WriteLine();
            }
        }
        public void ListAllPetNamesInShelter()
        {
            foreach (var p in allPetsInShelter)
            {
                Console.Write(p.GetPetName() + "   ");
            }
        }
        // ooo Added it optionally ooo
        public VirtualPet CheckIfPetNameMatch(string userInput)
        {
            bool exist = false;
            VirtualPet selectedPet = null;
            do
            {
                foreach (var pet in allPetsInShelter)
                {
                    if (pet.GetPetName() == userInput)
                    {
                        if (pet is RobotDog)
                        {
                            return (RobotDog)pet;
                        }
                        else if (pet is RobotCat)
                        {
                            return (RobotCat)pet;
                        }
                        else if (pet is OrganicDog)
                        {
                            return (OrganicDog)pet;
                        }
                        else return (OrganicCat)pet;
                        exist = true;
                    }
                }
            } 
            while (!exist);
            return selectedPet;
        }
        // +++ I dont use this --------> I start using it for check if pet exist in the shelter
        public VirtualPet RetrievePetByName(string requestedPetName)
        {
            VirtualPet selectedPet = null;
            foreach (var pet in allPetsInShelter)
            {
                if (pet.GetPetName() == requestedPetName)
                    selectedPet = pet;
            }
            return selectedPet;
        }
        public void AddHomelessPetToShelter(VirtualPet homelessPet)
        {
            allPetsInShelter.Add(homelessPet);
        }
        public void GiveUpPetForAdoption(string petNameToBeAdopted)
        {
            foreach (var pet in allPetsInShelter)
            {
                if (pet.GetPetName() == petNameToBeAdopted)
                {
                    allPetsInShelter.Remove(pet);
                    break;
                }
            }
        }
        public List<OrganicPet> GetAllOrganicPets(List<VirtualPet> allPetsInShelter)
        {
            List<OrganicPet> organicPets = new List<OrganicPet>();
            foreach (var pet in allPetsInShelter)
            {
                if (pet is OrganicPet)
                {
                    organicPets.Add((OrganicPet)pet);
                }
            }
            return organicPets;
        }
        public List<RobotPet> GetAllRoboticPets(List<VirtualPet> allPetsInShelter)
        {
            List<RobotPet> robotPets = new List<RobotPet>();
            foreach (var pet in allPetsInShelter)
            {
                if (pet is RobotPet)
                {
                    robotPets.Add((RobotPet)pet);
                }
            }
            return robotPets;
        }
        public List<OrganicDog> GetAllOrganicDogs(List<VirtualPet> allPetsInShelter)
        {
            List<OrganicDog> organicDogs = new List<OrganicDog>();
            foreach (var pet in allPetsInShelter)
            {
                if (pet is OrganicDog)
                {
                    organicDogs.Add((OrganicDog)pet);
                }
            }
            return organicDogs;
        }
        public List<VirtualPet> GetAllDogs(List<VirtualPet> allPetsInShelter)
        {
            List<VirtualPet> allDogs = new List<VirtualPet>();
            foreach (var pet in allPetsInShelter)
            {
                switch (pet)
                {
                    case OrganicDog:
                        allDogs.Add((VirtualPet)pet); 
                        break;

                    case RobotDog:
                        allDogs.Add((VirtualPet)pet);
                        break;

                    default: 
                        break;
                }
            }
            return allDogs;
        }
        // +++ IDog interface
        public void WalkAllDogs()
        {
            List<VirtualPet> allDogs = GetAllDogs(allPetsInShelter);
            foreach (var pet in allDogs)
            {
                switch (pet)
                {
                    case RobotDog: 
                        var rDog = (RobotDog)pet;
                        rDog.Walk();
                        // +++ Check if it works
                        rDog.SetPropertyMaxValue();
                        break;
                    case OrganicDog:
                        var oDog = (OrganicDog)pet;
                        oDog.Walk();
                        // +++ Check if it works
                        oDog.SetPropertyMaxValue();
                        break;
                    // I think there can't be No Dog, so default is unneccesary
                }
            }
        }
        public void CleanCagesForAllOrganicDogs()
        {
            foreach (var pet in GetAllOrganicDogs(allPetsInShelter))
            {
                pet.CleanOrganicDogCage();
            }
        }
        public void OilAllRoboticPets()
        {
            foreach (var pet in GetAllRoboticPets(allPetsInShelter))
            {
                pet.OilPet();
            }
        }
        public void FeedAllOrganicPets()
        {
            foreach (var pet in GetAllOrganicPets(allPetsInShelter))
            {
                pet.FeedPet();
            }
        }
        public void WaterAllOrganicPets()
        {
            foreach (var pet in GetAllOrganicPets(allPetsInShelter))
            {
                pet.GivePetWater();
            }
        }
        public void BathroomBreakAllOrganicPets()
        {
            foreach (var pet in GetAllOrganicPets(allPetsInShelter))
            {
                pet.WastePet();
            }
        }
        public void PlayWithPet(string name)
        {
            // +++ Check null
            // It could be neccesary to check if the nams is wrong! --- ??? Is it possible to use 2 methods on an instance in 1 line? ???
            var pet = RetrievePetByName(name);
            pet.PlayWithPet();
            pet.SetPropertyMaxValue();
        }
        public void TickAllPets()
        {
            foreach (var pet in allPetsInShelter)
            {
                pet.Tick();
            }
        }
        // It should never return 'null' and i think it must break; after find the first pet in needs -------- Does it work properly?
        public bool AreNeedsTooHighForAnyPet(List<VirtualPet> allVirtualPets)
        {
            foreach (var pet in allVirtualPets)
            {
                if (pet.AreNeedsTooHigh())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
