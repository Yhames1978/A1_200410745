using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace A1_200410745.Models
{
    public class PetFood
    {   // this is the primary key for the PetFood-Model(table in database)
        [Key]
        public virtual int PetFoodId { get; set; }
        //Required forces the user to only enter the values(datatype) that are defined in the method
        [Required]
        //this changes the decimal to currency($)
        [DataType(DataType.Currency)]
        public virtual decimal Price  { get; set; }
        [Required]
        public virtual String Name { get; set; }
        [Required]
        public virtual String Description { get; set; }
        [Required]
        public virtual String NutritionalInformation { get; set; }
        [Required]
        public virtual decimal Weight { get; set; }
        [Required]
        public virtual String Brand { get; set; }
        //This is the colunm that is the same in my PetFood table so I can Have a foreign key
        public virtual int AnimalId { get; set; }
        //this changes the display name to 'Animal Food is for' instead of PetFoodAnimal
        [Display(Name = "Animal Food is for")]
        //this makes the connection for the foreign key
        public virtual Animal PetFoodAnimal { get; set; }
        



    }
}
