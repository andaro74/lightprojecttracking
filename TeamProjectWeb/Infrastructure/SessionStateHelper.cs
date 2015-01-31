﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamProjectWeb.Infrastructure
{
    public enum SessionStateKeys
    { 
        MenuWorkItemsSessionKey,
        ProjectViewModelSessionKey,
        ProjectIdKey,
        SelectedStatusKey
    }

    public static class SessionStateHelper
    {
        public static object Get(SessionStateKeys key)
        {
            string keyString = Enum.GetName(typeof(SessionStateKeys), key);
            return HttpContext.Current.Session[keyString];

        }

        public static object Set(SessionStateKeys key, object value)
        {
            string keyString = Enum.GetName(typeof(SessionStateKeys), key);
            return HttpContext.Current.Session[keyString] = value;
        }

    }
}