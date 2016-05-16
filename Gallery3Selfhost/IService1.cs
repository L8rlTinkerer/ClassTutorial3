using Gallery3Selfhost.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Gallery3Selfhost
{
    //  attribute necessary for WCF services
    [ServiceContract] 
    interface IService1
    {
        //  attribute necessary for WCF services
        [OperationContract]
        List<string> GetArtistNames();

        [OperationContract]
        clsArtist GetArtist(string prArtistName);

        [OperationContract]
        int UpdateArtist(clsArtist prArtist);

        [OperationContract]
        int InsertArtist(clsArtist prArtist);


    }


    
}
