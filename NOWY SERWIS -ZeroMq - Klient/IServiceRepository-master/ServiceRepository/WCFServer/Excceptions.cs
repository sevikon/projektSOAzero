using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NServiceRepository
{
    /**
     * Klasa bazowa dla wyjątków z IServiceRepository
     * */
    public class ServiceRepositoryException : System.ApplicationException
    {
        /**
         * Komunikat w przypadku rzuczenia wyjątku
         * */
        public override String Message
        {
            get
            {
                return "Error: Nieznany blad!";
            }
        }
    }

    /**
     * Wyjątek rzucany w przypadku nie podania nazwy lub adresu serwisu
     * */
    public class EmptyAddressOrNameException : ServiceRepositoryException
    {
        public override String Message
        {
            get
            {
                return "Error: Pusty adres lub nazwa serwisu!";
            }
        }
    }

    /**
     * Wyjątek rzucany w przypadku nie znalezienia serwisu
     * */
    public class ServiceNotFoundException : ServiceRepositoryException
    {
        public override String Message
        {
            get
            {
                return "Error: Nie zarejestrowano takiego serwisu!";
            }
        }
    }

    /**
     * Wyjątek rzucany w przypadku gdy serwis już istnieje w bazie
     * */
    public class ServiceAlreadyExistsException : ServiceRepositoryException
    {
        public override String Message
        {
            get
            {
                return "Error: Taki serwis jest już zarejestrowany!";
            }
        }
    }
}
