using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreWithMVC.Models
{
    public class Person //Entity - Klasse -> Poco Klasse = Beinhaltet Properties, keine Logik enthalten (Methoden) 
    {
        public int Id { get; set; } //EF Core verwendet Konventionen, diese erkennen, das Poperty (id, Id, ID) ein Primary-Key ist
        
        
        [Required(ErrorMessage = "Geschlechtsangabe fehlt")]
        public GenderEnum Gender { get; set; }
        
        [Required (ErrorMessage = "Der Vorname wird benötigt")] //Firstname ist ein Muss-Feld
        public string FirstName { get; set; }

        [MaxLength(30, ErrorMessage = "Bis zu 30 Zeichnen")]
        public string LastName { get; set; }

        [Required]
        public string Birthday { get; set; }
    }

    public enum GenderEnum { Male=1, Female, Other}
}
