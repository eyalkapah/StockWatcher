using System;

namespace StockWatcher.Models.Exceptions
{
    public class UnauthenticatedUserException : Exception
    {
        public UnauthenticatedUserException():base("Unauthenticated user, please sign out and re-login")
        {
            
        }
    }
}
