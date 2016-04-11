using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Subvertic.DocumentSecurity.PKI.UI
{
    // ------------------------------------------------------------------------------------------------------------------------------------ //
    // INTERFACE CERTIFICATE SELECTOR                                                                                                       //
    // ------------------------------------------------------------------------------------------------------------------------------------ //
    /// <summary>
    ///     Provides a set of methods to provide the user for a graphics interface where he or she can view the certificates installed on
    ///     an specific certificate store and select the corresponding certificate they what to use for a cryptographic operation
    ///     <author>Pedro Guzmán (pedro@subvertic.com)</author>
    /// </summary>
    public interface ISdsCertificateSelector
    {
        // -------------------------------------------------------------------------------------------------------------------------------- //
        // METHOD LOAD                                                                                                                      //
        // -------------------------------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     Loads the collection object that conatins the cerificate references that are going to be displayed to the user for selection
        /// </summary>
        /// <param name="collection">Collection of certificate choices that will be displayed to the user</param>
        void Load(X509Certificate2Collection collection);

        // -------------------------------------------------------------------------------------------------------------------------------- //
        // METHOD DISPLAY SELECTOR                                                                                                          //
        // -------------------------------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     Given a collection of certificates, this methods displays a dialog that allows the user to select de certificate that he or
        ///     she whats to use for a cryptographic transaction.
        /// </summary>
        /// <param name="header">Message to be displayed on the header of the window</param>
        /// <param name="message">Message to be displayed as the instructions on the message box</param>
        void DisplaySelector(string header, string message);

        // -------------------------------------------------------------------------------------------------------------------------------- //
        // METHOD GET SELECTED                                                                                                              //
        // -------------------------------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     Gets the certficate reference selected by the user. In case the certificate is not selected or not accessible, then null
        ///     is returned. 
        /// </summary>
        /// <returns>X509Certificate2</returns>
        X509Certificate2 GetSelected();

    } // INTERFACE CERTIFICATE SELECTOR --------------------------------------------------------------------------------------------------- //
}