using MovieMVC.Data_Access.Data;
using MovieMVC.Data_Access.Repository.IRepository;
using MovieMVC.Model;
using System.Linq;

namespace MovieMVC.Data_Access.Repository
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        private readonly ApplicationDbContext _db;
        public MovieRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Movie movie)
        {

            var objFromDb = _db.Movies.FirstOrDefault(s => s.Id == movie.Id);
            if (objFromDb != null)
            {
                if (movie.ImageUrl != null)
                {
                    objFromDb.ImageUrl = movie.ImageUrl;
                }
                objFromDb.ISBN = movie.ISBN;
                objFromDb.Price = movie.Price;
                objFromDb.Price50 = movie.Price50;
                objFromDb.Price100 = movie.Price100;
                objFromDb.ListPrice = movie.ListPrice;
                objFromDb.Title = movie.Title; 
                objFromDb.Director = movie.Director;
                objFromDb.Description = movie.Description;
                objFromDb.CategoryId = movie.CategoryId;
                objFromDb.DeliveryTypeId = movie.DeliveryTypeId;
            }
        }
    }
}
