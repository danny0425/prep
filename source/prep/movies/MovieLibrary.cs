using System;
using System.Collections.Generic;

namespace code.prep.movies
{
  public class MovieLibrary
  {
    readonly IList<Movie> movies;

    public MovieLibrary(IList<Movie> list_of_movies)
    {
      this.movies = list_of_movies;
    }

    public IEnumerable<Movie> all_movies()
    {
      return movies;
    }

    public void add(Movie movie)
    {
      movies.Add(movie);
    }

        private IEnumerable<Movie> get_movies_by_production(ProductionStudio prd)
        {
            List<Movie> rtn = new List<Movie>();
            foreach (Movie mv in this.movies)
            {
                if (mv.production_studio == prd)
                    rtn.Add(mv);
            }
            return rtn;
        }

        public IEnumerable<Movie> all_movies_published_by_pixar()
    {
            return this.get_movies_by_production(ProductionStudio.Pixar);
    }

    public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
    {
            List<Movie> rtn = new List<Movie>();
            rtn.AddRange(get_movies_by_production(ProductionStudio.Pixar));
            rtn.AddRange(get_movies_by_production(ProductionStudio.Disney));
            return rtn;
        }

    public IEnumerable<Movie> all_movies_not_published_by_pixar()
    {
            List<Movie> rtn = new List<Movie>(this.all_action_movies());
            for (int i= rtn.Count; i > 0; i--)
            {
                if(rtn[i-1].production_studio == ProductionStudio.Pixar)
                    rtn.RemoveAt(i - 1);
            }

            return rtn;
    }

    public IEnumerable<Movie> all_movies_published_after(int year)
    {
            return all_movies_published_between_years(year, int.MaxValue);
    }

    public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
    {
            List<Movie> rtn = new List<Movie>();
            foreach(Movie m in this.movies)
            {
                if ((m.date_published.Year > startingYear) && ((m.date_published.Year < endingYear)))
                    rtn.Add(m);
            }

            return rtn;
        }
        private IEnumerable<Movie> get_movies_by_genre(Genre g)
        {
            List<Movie> rtn = new List<Movie>();
            foreach (Movie m in this.movies)
            {
                if (m.genre == g)
                    rtn.Add(m);
            }

            return rtn;
        }
        public IEnumerable<Movie> all_kid_movies()
    {
            return get_movies_by_genre(Genre.kids);
        }

    public IEnumerable<Movie> all_action_movies()
    {
            return get_movies_by_genre(Genre.action);
    }

    public IEnumerable<Movie> sort_all_movies_by_title_descending()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_title_ascending()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
    {
      throw new NotImplementedException();
    }
  }
}
