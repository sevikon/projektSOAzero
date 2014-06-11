using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NServiceRepository
{
    /**
     *  Klasa reprezentująca serwis w bazie
     * */
    public class Service
    {
        /**
         *  ID serwisu
         * */
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ServID { get; set; }
        /**
         *  Nazwa serwisu
         * */
        public String Name { get; set; }

        public DateTime LastSeen { get; set; }

        /**
         * Adres serwisu
         * */
        public String Adress { get; set; }

    }
}
