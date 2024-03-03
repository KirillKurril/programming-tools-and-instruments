namespace MLWD.Services
{
    public interface IDbService<Parent, Child>
    {
        IEnumerable<Parent> GetHalls();
        IEnumerable<Child> GetExhibitsByHall(int id);
        void Init();
    }
}
