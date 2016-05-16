using Gallery3Selfhost.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery3Selfhost
{
    class Service1:IService1
    {


        // The keyword using allows us to create objects that will be disposed of orderly when no longer needed, even in case of exceptions; an important feature where database connections are concerned: 
        public List<string> GetArtistNames()
        { // service function that retrieves a list of all artist names
            using (Gallery_DataEntities2 lcContext = new Gallery_DataEntities2())
                return lcContext.Artists.Select(lcArtist => lcArtist.Name).ToList();
        }


        //  a service method that uses the Gallery3Selfhost.DTO class clsArtist:
        public clsArtist GetArtist(string prArtistName)
        {
            using (Gallery_DataEntities2 lcContext = new Gallery_DataEntities2())
            {
                Artist lcArtist = lcContext.Artists.Include("Works").Where(Artist => Artist.Name == prArtistName).FirstOrDefault();
                clsArtist lcArtistDTO = new clsArtist() { Name = lcArtist.Name, Speciality = lcArtist.Speciality, Phone = lcArtist.Phone };
                return lcArtistDTO;
            }
        }

        //  generic method that can do create, update and delete with any entity
        private int process<TEntity>(TEntity prItem, System.Data.Entity.EntityState prState) where TEntity : class //  TEntity is any kind of class
        {
            using (Gallery_DataEntities2 lcContext = new Gallery_DataEntities2())
            {
                lcContext.Entry(prItem).State = prState; // sets the state of the item
                int lcCount = lcContext.SaveChanges(); // SaveChanges() writes the data back to the database and returns the number of rows affected
                return lcCount;
            }
        }


        public int UpdateArtist(clsArtist prArtist)
        {
            return process(prArtist.MapToEntity(), System.Data.Entity.EntityState.Modified);
        }


        public int InsertArtist(clsArtist prArtist)
        {
            return process(prArtist.MapToEntity(), System.Data.Entity.EntityState.Added);
        }

    }
}
