/*!

\author         Oliver Blaser

\date           15.12.2020

\copyright      GNU GPLv3 - Copyright (c) 2020 Oliver Blaser

\brief          

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPosMgr.Middleware.Util
{
    /*
    ...

    */

    public static class Misc
    {
        public static T ParseEnum<T>(string value)
        {
            return Middleware.Util.Misc.ParseEnum<T>(value, false);
        }

        public static T ParseEnum<T>(string value, bool ignoreCase)
        {
            return (T)Enum.Parse(typeof(T), value, ignoreCase);
        }

        /*  
        ...

        */
    }
}
