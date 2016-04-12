using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Subvertic.DocumentSecurity.PKI.UI
{
    // ------------------------------------------------------------------------------------------------------------------------------------ //
    // CLASS SDS DEFAULT CERTIFICATE SELECTOR                                                                                               //
    // ------------------------------------------------------------------------------------------------------------------------------------ //
    /// <summary>
    /// 
    ///     <author>Pedro Guzmán (pedro@subvertic.com)</author>
    /// </summary>
    public class SdsDefaultCertificateSelector : ISdsCertificateSelector
    {
        private X509Certificate2Collection localCollection;
        private X509Certificate2 x509Selected;

        // -------------------------------------------------------------------------------------------------------------------------------- //
        // METHOD LOAD                                                                                                                      //
        // -------------------------------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     Loads the collection object that conatins the cerificate references that are going to be displayed to the user for selection
        /// </summary>
        /// <param name="collection">Collection of certificate choices that will be displayed to the user</param>
        public void Load(X509Certificate2Collection collection)
        {
            if (collection != null && collection.Count > 0)
            {
                localCollection = collection;
            } // IF ENDS
            else
            {
                throw new ArgumentNullException(nameof(collection));
            } // ELSE ENDS
        } // METHOD LOAD ENDS ------------------------------------------------------------------------------------------------------------- //

        // -------------------------------------------------------------------------------------------------------------------------------- //
        // METHOD DISPLAY SELECTOR                                                                                                          //
        // -------------------------------------------------------------------------------------------------------------------------------- //
        /// <summary>
        /// 
        /// </summary>
        /// <param name="header"></param>
        /// <param name="message"></param>
        public void DisplaySelector(string header, string message)
        {
            var scollection = X509Certificate2UI.SelectFromCollection(this.localCollection,
                header, message, X509SelectionFlag.SingleSelection);
            if (scollection.Count <= 0) return;
            foreach (var cert in scollection)
            {
                this.x509Selected = cert;
            } // FOREACH ENDS
        } // METHOD DISPLAY SELECTOR ENDS ------------------------------------------------------------------------------------------------- //

        // -------------------------------------------------------------------------------------------------------------------------------- //
        // METHOD GET SELECTED                                                                                                              //
        // -------------------------------------------------------------------------------------------------------------------------------- //
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public X509Certificate2 GetSelected()
        {
            X509Certificate2 selected;
            if (this.x509Selected != null && this.x509Selected.HasPrivateKey)
            {
                selected = this.x509Selected;
            } // IF ENDS
            else
            {
                selected = null;
            } // ELSE ENDS
            return selected;
        } // METHOD GET SELECTED ENDS ----------------------------------------------------------------------------------------------------- //
    }
}
