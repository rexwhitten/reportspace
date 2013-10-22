using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReportSpace
{
    public static class Extensions
    {
        public static bool ErrorOn<TException>(this Object obj, Action actor) where TException: Exception 
        {
            bool result = false;
            try
            {
                actor.Invoke();
                result = false;
            }
            catch (TException x)
            {
                result = true;
            }
            return result;
        }
    }
}