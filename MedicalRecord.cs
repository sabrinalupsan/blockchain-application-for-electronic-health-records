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

        private long PacientID;
        public long pacientID { get { return PacientID; } set { PacientID = value; } }

        private DateTime Date;
        public DateTime date { get { return Date; } set { Date = value; } }

        private MedicalRecord()
        {

        }

        public MedicalRecord(long pacientID, long doctorID, string title, string description, DateTime date)
        {
            PacientID = pacientID;
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
