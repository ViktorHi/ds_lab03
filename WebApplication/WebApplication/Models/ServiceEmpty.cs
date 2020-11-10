using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class ServiceEmpty
    {
        private Visit[] visits = new Visit[]
{
            new Visit(1, "ivanov", "petrov", DateTime.Now, "pediatr" ),
            new Visit(2, "sidorov", "petrov", DateTime.Now, "lor" ),
            new Visit(3, "ivanov", "petrov", DateTime.Now, "mehanic" ),
};

        private Token[] tokens = new Token[]
{
            new Token("1", "122", Functions.Create, DateTime.Now, DateTime.Now),
            new Token("2", "1322", Functions.Create, DateTime.Now, DateTime.Now),
            new Token("3", "1242", Functions.Delete, DateTime.Now, DateTime.Now),
            new Token("4", "1252", Functions.Get, DateTime.Now, DateTime.Now),
            new Token("5", "1226", Functions.Update, DateTime.Now, DateTime.Now),

};

        public Visit[] GetVisits()
        {
            return visits;
        }

        public bool IsTokenExists(Functions functions, User user) { return true; }
        public void UpdateVisit(Visit visit) { }
        public void DeleteVisit(int id) { }
        public void CreateVisit(User user, Visit visit) { }
        public void AddUser(User user) { }
        public bool IsUser(User user) { return true; }
        public Token[] GetTokens() { return tokens; }
        public void AddToken(User user, Functions function, DateTime day1, DateTime day2) { }
    }
}
