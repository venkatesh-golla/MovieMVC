using MovieMVC.Model;

namespace MovieMVC.Data_Access.Repository.IRepository
{
    public interface IMovieRepository : IRepository<Movie>
    {
        void Update(Movie movie);
    }
}
