using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

    public static class ClassExtensions
    {
        public static bool KeyExists(this HttpSessionStateBase session, string sessionKey)
        {
            bool isSelected = false;

            foreach (string key in session.Keys)
                if (key == sessionKey)
                    isSelected = true;

            return isSelected;

        }

        public static string GetString(this HttpSessionStateBase session, string key)
        {
            if (session == null)
            {
                return string.Empty;
            }
            var value = session["key"];
            if (value == null)
            {
                return string.Empty;
            }
            return Convert.ToString(value);
        }
    }
