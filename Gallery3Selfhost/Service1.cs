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

    }
}
