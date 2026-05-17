using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTycoon.Engine
{
    /// <summary>
    /// Excepție personalizată aruncată atunci când jucătorul încearcă să cumpere un element 
    /// fără a avea cantitatea necesară de Linii de Cod.
    /// </summary>
    public class NotEnoughCodeException : Exception
    {
        /// <summary>
        /// Creează o nouă instanță a excepției cu un mesaj detaliat.
        /// </summary>
        /// <param name="message">Mesajul care explică de ce operațiunea a eșuat.</param>
        public NotEnoughCodeException(string message) : base(message) { }
    }
}
