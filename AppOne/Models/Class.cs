using System.ComponentModel.DataAnnotations.Schema;

namespace AppOne.Models
{
    public class Class
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string name { get; set; }    
    }
}
