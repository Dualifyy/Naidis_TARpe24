using Naidis_TARpe24.Resources.Animals;
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace Naidis_TARpe24.Services
{
    public class AnimalViewModel : INotifyPropertyChanged
    {
        private string _currentAnimalImage;


        public string CurrentAnimalImage
        {
            get => _currentAnimalImage;
            set
            {
                _currentAnimalImage = value;
                OnPropertyChanged();
            }
        }
        public AnimalViewModel()
        {
            // Algseis: kasutame ressursside failist väärtust
            CurrentAnimalImage = AppResources.AnimalCat;
        }

        // Meetod pildi muutmiseks (näiteks nupu vajutusel)
        public void ChangeAnimal(string type)
        {
            CurrentAnimalImage = type switch
            {
                "Dog" => AppResources.AnimalDog,
                "Fish" => AppResources.AnimalFish,
                _ => AppResources.AnimalCat
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

}

