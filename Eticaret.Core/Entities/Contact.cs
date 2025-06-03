using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret.Core.Entities
{
    public class Contact:IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Adı")]

        public string Name { get; set; }
        [Display(Name = "Soyadı")]

        public string Surname { get; set; }
        public string? Email { get; set; }
        [Display(Name = "Telefon")]

        public string? Phone { get; set; }
        [Display(Name = "Mesaj")]

        public string Message { get; set; }
        [Display(Name = "Kayıt Tarihi"), ScaffoldColumn(false)]

        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
