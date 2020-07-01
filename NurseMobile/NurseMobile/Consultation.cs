using System;
using System.Collections.Generic;
using System.Text;

namespace NurseMobile
{
    public class Consultation
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string DoctorSpeciality { get; set; }
        public string Patient { get; set; }
        public string Status { get; set; }

        public override bool Equals(object obj)
        {
            Consultation consultation = obj as Consultation;
            return this.Id == consultation.Id;
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
