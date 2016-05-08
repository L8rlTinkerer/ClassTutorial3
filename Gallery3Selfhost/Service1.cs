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
            using (Gallery_DataEntities lcContext = new Gallery_DataEntities())
                return lcContext.Artists.Select(lcArtist => lcArtist.Name).ToList();
        }

    }
}
