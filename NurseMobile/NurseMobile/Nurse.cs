using System;
using System.Collections.Generic;
using System.Text;

namespace NurseMobile
{
    public class Nurse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecontName { get; set; }

        public override bool Equals(object obj)
        {
            Nurse nurse = obj as Nurse;
            return this.Id == nurse.Id;
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

    }



}


