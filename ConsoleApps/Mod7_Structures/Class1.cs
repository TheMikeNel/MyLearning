using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod7_Structures
{
    struct Boe
    {
        public float Strength;
        public string Name;
        public bool isBoe;

        public BoeConstruct(float strength, string name, bool isBoe)
        {
            Strength = strength;
            Name = name;
            this.isBoe = isBoe;
        }

    }
}
