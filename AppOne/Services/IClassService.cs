namespace AppOne.Services
{
    public interface IClassService
    {
        Task<IEnumerable<Class>> GetAll();
        Task<Class> GetById(int id);
        Task<Class> Add(Class clas);
        Class Update(Class clas);
        Class Delate(Class clas);
        Task<bool> IsValidClass(int id);

    }
}
