﻿using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace CSharpTradeOffers
{
    /// <summary>
    /// Various extension methods used in the library.
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Converts the bool variable to its integer representation of 0 for false and 1 for true.
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int IntValue(this bool b)
        {
            return b ? 1 : 0;
        }

        public static string SerializeToXml<T>(this T value)
        {
            if (value == null) return string.Empty;

            try
            {
                var xmlserializer = new XmlSerializer(typeof (T));
                var stringWriter = new StringWriter();
                using (var writer = XmlWriter.Create(stringWriter))
                {
                    xmlserializer.Serialize(writer, value);
                    return stringWriter.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred", ex);
            }
        }
    }
}
