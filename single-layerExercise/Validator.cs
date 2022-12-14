using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace single_layerExercise
{
    public static class Validator
    {
        public static bool UserEmailValidator<T>(string propName, T obj)
        {
            Func<string, T, bool> validate = (propName, obj) =>
            {
                PropertyInfo property = obj.GetType().GetProperty(propName);

                ContainsCharacterAttribute cca = property.GetCustomAttributes(typeof(ContainsCharacterAttribute), false).SingleOrDefault() as ContainsCharacterAttribute;

                string propertyContent = property.GetValue(obj).ToString();

                foreach (char character in cca.CharacterCheck)
                {
                    if (!propertyContent.Contains(character))
                        return false;
                }
                return true;
            };

            return validate(propName, obj);
        }

    }
}
