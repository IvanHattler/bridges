using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ITS.Core.Bridges.Helpers
{
    public static class DefectParamsParser
    {
        static readonly Dictionary<string, string> types = new Dictionary<string, string>
        {
            //todo: исправить, это не оптимально
            //{ "float", @"\d+.\d+" },
            //{ "int", @"\d+" },
            //{ "bool", @"\w+" }
            { "float", @"[^;]+" },
            { "int", @"[^;]+" },
            { "bool", @"[^;]+" },
        };
        /// <summary>
        /// Возвращает null, если  у дефекта нет параметров
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetRules(string pattern)
        {
            if (string.IsNullOrEmpty(pattern))
            {
                return null;
            }
            //Regex r = new Regex(@"(\w*\s*\w*\s*\w+,\w+:\w+)|(\w*\s*\w*\s*\w+:\w+)|(\w+:\w+)", RegexOptions.Compiled | RegexOptions.CultureInvariant
            Regex r = new Regex(@"([^\n:;]+:\w+)", RegexOptions.Compiled | RegexOptions.CultureInvariant
                | RegexOptions.IgnoreCase);
            var rules = r.Matches(pattern);
            if (rules.Count < 1)
            {
                throw new ArgumentException("Неправильный паттерн");
            }
            var res = new Dictionary<string, string>();
            foreach (var rule in rules)
            {
                var a = (rule as Match).Value.Split(':');
                if (types.ContainsKey(a[1]))
                {
                    res.Add(a[0], a[1]);
                }
                else
                {
                    throw new ArgumentException("Неправильный паттерн");
                }
            }
            return res;
        }
        /// <summary>
        /// Возвращает null, если  у дефекта нет параметров
        /// </summary>
        /// <param name="value"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static Dictionary<string, string> Parse(string value, string pattern)
        {
            var res = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(pattern))
            {
                return null;
            }
            if (!string.IsNullOrEmpty(value))
            {
                var rules = GetRules(pattern);
                foreach (var rule in rules)
                {
                    var len = rule.Key.Length + 1;
                    var match = new Regex(rule.Key + '=' + types[rule.Value], RegexOptions.Compiled | RegexOptions.CultureInvariant).Match(value);
                    if (match != null && match.Success)
                    {
                        res.Add(rule.Key, match.Value.Substring(len));
                    }
                }
            }
            return res;
        }
        public static string Box(Dictionary<string, string> paramsValues)
        {
            if (paramsValues == null || paramsValues.Count == 0)
            {
                return "";
            }
            StringBuilder sb = new StringBuilder();
            foreach (var item in paramsValues)
            {
                sb.Append(item.Key);
                sb.Append("=");
                sb.Append(item.Value);
                sb.Append(";");
            }
            return sb.ToString();
        }
    }
}
