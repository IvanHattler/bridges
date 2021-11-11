using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITS.Core.Bridges.Domain.Base
{
    /// <summary>
    /// Базовый класс для конвертеров перечислений
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class EnumStrings<T>
        where T : struct, IConvertible
    {
        public abstract string GetFullName(T element);
        /// <summary>
		/// Метод для элемента перечисления из строкового представления
		/// </summary>
		/// <param name="name">Строковое представление элемента перечисления</param>
		/// <returns>Соответствующий элемент перечисления</returns>
        public abstract T GetElement(string name);
        /// <summary>
        /// Метод для получения строкового представления элемента перечисления
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public string GetName(T element)
        {
            //var fullName = GetFullName(element);
            //var tmp = fullName.Split(new[] { "//" }, StringSplitOptions.RemoveEmptyEntries);
            //if (tmp.Length > 1)
            //{

            //}
            return GetFullName(element);
        }
    }
}
