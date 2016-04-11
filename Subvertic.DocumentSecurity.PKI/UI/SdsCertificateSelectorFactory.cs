using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subvertic.DocumentSecurity.PKI.UI
{
    // ------------------------------------------------------------------------------------------------------------------------------------ //
    // CLASS CERTIFICATE SELECTOR FACTORY                                                                                                   //
    // ------------------------------------------------------------------------------------------------------------------------------------ //
    /// <summary>
    ///     Creates instances of implementations of ISdsCertificateSelector and allows to select whicj type of implementations need to be 
    ///     used. 
    /// </summary>
    public class SdsCertificateSelectorFactory
    {
        public ISdsCertificateSelector GetInstance(string selectorType)
        {
            ISdsCertificateSelector selector;
            if (!string.IsNullOrEmpty(selectorType))
            {
                switch (selectorType)
                {
                    case "default":
                    default:
                        selector = new SdsDefaultCertificateSelector();
                        break;
                } // SWITCH ENDS
            } // IF ENDS
            else
            {
                selector = null;
                throw new ArgumentNullException(nameof(selectorType));
            } // ELSE ENDS
            return selector;
        } // METHOD GET INSTANCE ENDS ----------------------------------------------------------------------------------------------------- //
    } // METHOD SDS CERTIFICATE SELECTOR FACTORY ------------------------------------------------------------------------------------------ //
}
