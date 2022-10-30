using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace single_layerExercise
{
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class ContainsCharacterAttribute : Attribute
    {
        public string CharacterCheck { get; set; }
        public ContainsCharacterAttribute(string characterCheck)
        {
            this.CharacterCheck = characterCheck;
        }
    }
}

