using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTycoon.Patterns
{
    /// <summary>
    /// Clasă statică ce implementează șablonul de proiectare Factory Method.
    /// Se ocupă de instanțierea dinamică a angajaților pe baza unui identificator de tip text.
    /// </summary>
    public static class EmployeeFactory
    {
        /// <summary>
        /// Creează și returnează o instanță nouă a unui angajat în funcție de tipul cerut.
        /// </summary>
        /// <param name="type">Tipul de angajat sub formă de string (ex: "intern", "junior", "senior", "sysarchitect").</param>
        /// <returns>O instanță de obiect care implementează interfața <see cref="IEmployee"/>.</returns>
        /// <exception cref="ArgumentException">Aruncată dacă textul primit nu corespunde niciunui tip cunoscut de angajat.</exception>
        public static IEmployee CreateEmployee(string type)
        {
            switch (type.ToLower())
            {
                case "intern":
                    return new InternDev();

                case "junior":
                    return new JuniorDev();

                case "senior":
                    return new SeniorDev();

                case "sysarchitect":
                    return new SysArchiDev();
                default:
                    throw new ArgumentException("Unknown employee type.");
            }
        }

        /// <summary>
        /// Metodă utilitară pentru a afla pragul de deblocare al unui anumit tip de angajat fără a-l adăuga în echipă.
        /// </summary>
        /// <param name="type">Tipul de angajat.</param>
        /// <returns>Valoarea proprietății UnlockAt a angajatului respectiv.</returns>
        public static double GetUnlockAt(string type)
        {
            return CreateEmployee(type).UnlockAt;
        }

        /// <summary>
        /// Metodă utilitară pentru a obține numele oficial de afișare al unui tip de angajat.
        /// </summary>
        /// <param name="type">Tipul de angajat.</param>
        /// <returns>String-ul cu numele frumos formatat (ex: "System Architect").</returns>
        public static string GetDisplayName(string type)
        {
            return CreateEmployee(type).Name;
        }
    }
}