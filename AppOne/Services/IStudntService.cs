namespace AppOne.Services
{
    public interface IStudntService
    {
        Task<IEnumerable<Studnt>> GetAll();
        Task<Studnt> GetById(int id);
        Task<Studnt> GetByClassId(int classid);
        Task<Studnt> Add(Studnt student);
        Studnt Update(Studnt student);
        Studnt Delate(Studnt student);
    }
}
