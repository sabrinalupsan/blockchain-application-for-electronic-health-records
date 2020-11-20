using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Policy;

namespace BlockchainApp
{
    public class MedicalRecord
    {
        private string Description;
        public string description { get { return Description; } set { Description = value; } }

        private string Title;
        public string title { get { return Title; } set { Title = value; } }

        private long DoctorID;
        public long doctorID { get { return DoctorID; } set { DoctorID = value; } }

        private long PatientID;
        public long patientID { get { return PatientID; } set { PatientID = value; } }

        private DateTime Date;
        public DateTime date { get { return Date; } set { Date = value; } }

        private MedicalRecord()
        {

        }

        public MedicalRecord(long patientID, long doctorID, string title, string description, DateTime date)
        {
            PatientID = patientID;
            DoctorID = doctorID;
            Title = title;
            Description = description;
            Date = date;
        }

        public override string ToString()
        {
            return title+" "+date.ToShortDateString();
        }
    }
}
