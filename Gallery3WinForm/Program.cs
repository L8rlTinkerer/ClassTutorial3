using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;

namespace Gallery3WinForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        public static ServiceReference2.Service1Client SvcClient = new ServiceReference2.Service1Client();



        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //clsPainting.LoadPaintingForm = new clsPainting.LoadPaintingFormDelegate(frmPainting.Run);
            //clsPhotograph.LoadPhotographForm = new clsPhotograph.LoadPhotographFormDelegate(frmPhotograph.Run);
            //clsSculpture.LoadSculptureForm = new clsSculpture.LoadSculptureFormDelegate(frmSculpture.Run);
            Application.Run(frmMain.Instance);

            if (SvcClient != null && SvcClient.State != System.ServiceModel.CommunicationState.Closed)
                SvcClient.Close();
        }
    }
}
