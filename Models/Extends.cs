using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace editor.Models
{
    public static class Extends
    {
        public static string LimitLength(this string s, int limit)
        {
            if (String.IsNullOrWhiteSpace(s) || s.Length < limit) return s;
            else return s.Substring(0, limit) + "...";
        }
    }
}
