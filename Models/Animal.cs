using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace A1_200410745.Models
{
    public class Animal

    {
        public Animal() { }
        //Constructor so we can have a new instance and used this keyword to avoid conflict without having to rename them
        public Animal(int AnimalId, String Name, String Description)
        {
            this.AnimalId = AnimalId;
            this.Name = Name;
            this.Description = Description;

        }
        [Key]
        public virtual int AnimalId { get; set; }
        public virtual String Name { get; set; }
        public virtual String Description { get; set; }
        
        public virtual List<PetFood> GetPetFoods { get; set; }
    }
}
