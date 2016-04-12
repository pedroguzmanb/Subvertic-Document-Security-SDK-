using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Subvertic.DocumentSecurity.PKI.UI;

namespace Subvertic.DocumentSecurity.PKI.StoreManager
{
    // ------------------------------------------------------------------------------------------------------------------------------------ //
    // CLASS X509 STORE MANAGER                                                                                                             //
    // ------------------------------------------------------------------------------------------------------------------------------------ //
    /// <summary>
    ///     This class is used to manage access operation to an X509 Certificate Store and the resources it contains
    ///     <author>Pedro Guzmán (pedro@subvertic.com)</author>
    /// </summary>
    public class X509StoreManager
    {

        // -------------------------------------------------------------------------------------------------------------------------------- //
        // CLASS PRIVATE ATTRIBUTES                                                                                                         //
        // -------------------------------------------------------------------------------------------------------------------------------- //

        private X509Store certificateStore;
        private bool storeOpen;
        private X509Certificate2Collection currentSelection;

        // -------------------------------------------------------------------------------------------------------------------------------- //
        // CLASS DESTRUCTOR                                                                                                                 //
        // -------------------------------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     Releases resources used by this class 
        /// </summary>
        ~X509StoreManager()
        {
            Close();
            GC.Collect();
        } // DESTRUCTOR METHOD ENDS ------------------------------------------------------------------------------------------------------- //


        // -------------------------------------------------------------------------------------------------------------------------------- //
        // METHOD GET CURRENT SELECTION                                                                                                     //
        // -------------------------------------------------------------------------------------------------------------------------------- //
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public X509Certificate2Collection GetCurrentSelection()
        {
            if (currentSelection != null && currentSelection.Count > 0)
                return currentSelection;
            else
            {
                currentSelection = (X509Certificate2Collection)certificateStore.Certificates;
            }
            return currentSelection;
        } // METHOD GET CURRENT SELECTION ENDS -------------------------------------------------------------------------------------------- //

        // -------------------------------------------------------------------------------------------------------------------------------- //
        // METHOD SELECT CERTIFICATE WITH UI                                                                                                //
        // -------------------------------------------------------------------------------------------------------------------------------- //
        /// <summary>
        /// 
        /// </summary>
        /// <param name="findType"></param>
        /// <param name="findVal"></param>
        /// <param name="header"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public X509Certificate2 SelectCertificateWithUi(X509FindType findType, object findVal, string header, string message)
        {
            X509Certificate2 cert = null;
            var collection = Select(findType, findVal);
            if (collection.Count <= 0) return cert;
            var selectorFactory = new SdsCertificateSelectorFactory();
            var selector = selectorFactory.GetInstance("default");
            selector.Load(collection);
            selector.DisplaySelector(header, message);
            return selector.GetSelected();
        } // METHOD SHOW CERTIFICATE SELECT DIALOG ENDS ----------------------------------------------------------------------------------- //

        // -------------------------------------------------------------------------------------------------------------------------------- //
        // METHOD SELECT                                                                                                                    //
        // -------------------------------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     Creates a sub-selection of certificates available on a specific store in order to display only valid options to the user.
        /// </summary>
        /// <param name="constraints">Find Type</param>
        /// <param name="findVal">Value to be matched or used as comparison value for find criteria</param>
        /// <returns></returns>
        public X509Certificate2Collection Select(X509FindType constraints, object findVal)
        {
            var collection = new X509Certificate2Collection(); // Create an empty collection
            if (!storeOpen) return collection;
            currentSelection =
                (X509Certificate2Collection)
                    certificateStore.Certificates.Find(constraints, findVal, validOnly: true);
            collection = currentSelection;
            return collection;
        } // METHOD SELECT ENDS ----------------------------------------------------------------------------------------------------------- //



        // -------------------------------------------------------------------------------------------------------------------------------- //
        // METHOD OPEN                                                                                                                      //
        // -------------------------------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     Opens the certificate store located on a given location and matching the specified store name
        /// </summary>
        /// <param name="name">Name of the certificate store</param>
        /// <param name="location">Location of the certificate store</param>
        /// <returns></returns>
        public bool Open(StoreName name, StoreLocation location)
        {
            
            var loadedSuccessfully = false;
            // Make access to the certificate store thread-safe
         
            try
            {
                certificateStore = new X509Store(name, location);
                certificateStore.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
                loadedSuccessfully = certificateStore.Certificates.Count > 0;
                storeOpen = loadedSuccessfully;
            } // TRY ENDS
            catch (CryptographicException ce)
            {
                Trace.TraceError(ce.Message);
                loadedSuccessfully = false;
                throw new CryptographicException("Unable to access certificate store", ce);
            } // CATCH ENDS
            catch (SecurityException se)
            {
                Trace.TraceError(se.Message);
                loadedSuccessfully = false;
                throw new SecurityException("Certificate Store Access Denied", se);
            } // CATCH ENDS
            catch (ArgumentException ae)
            {
                Trace.TraceError(ae.Message);
                loadedSuccessfully = false;
                throw new ArgumentException("Invalid certificate store arguments", ae);
            } // CATCH ENDS
            catch (Exception e)
            {
                Trace.TraceError(e.Message);
                loadedSuccessfully = false;
                throw new Exception("Cannot access certificate store", e);
            } // CATCH ENDS
            return loadedSuccessfully;
        } // METHOD OPEN ENDS ------------------------------------------------------------------------------------------------------------- //

        // -------------------------------------------------------------------------------------------------------------------------------- //
        // METHOD CLOSE                                                                                                                     //
        // -------------------------------------------------------------------------------------------------------------------------------- //
        /// <summary>
        /// 
        /// </summary>
        public void Close()
        {
            try
            {
                lock (certificateStore)
                {
                    certificateStore.Close();
                } // LOCK ENDS
            } // TRY ENDS
            catch (Exception e)
            {
                Trace.TraceError(e.Message);
            } // CATCH ENDS
        } // METHOD CLOSE ENDS ------------------------------------------------------------------------------------------------------------ //


    } // METHOD X509 STORE MANAGER ENDS --------------------------------------------------------------------------------------------------- //
}
