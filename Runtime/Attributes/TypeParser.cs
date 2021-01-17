using System;

namespace IniConfiguration.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Method)]
    public class TypeParser : System.Attribute
    {
        /// <summary>
        /// Attribute use to define new parser methode for param type
        /// </summary>
        /// <param name="type">type parse by this delegate</param>
        public TypeParser(Type type)
        {
            this.type = type;
        }

        public Type type;
    } 
}