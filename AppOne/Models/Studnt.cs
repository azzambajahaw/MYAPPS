namespace AppOne.Models
{
    public class Studnt
    {
        public int Id { get; set; } 
        public string Name { get; set; }    
        public string age { get; set; }    
        public int Classid { get; set; }    
        public Class Class { get; set; }    


    }
}
