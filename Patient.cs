using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainApp
{
    public class Patient
    {
        private long PatientID;
        public long patientID { get { return PatientID; } set { PatientID = value; } }

        private byte[] PassHashed;
        public byte[] passHashed { get { return PassHashed; } }

        private byte[] CardPIN;
        public byte[] cardPIN { get { return CardPIN; } }

        private List<Doctor> Doctors;
        public List<Doctor> doctors { get { return Doctors; } set { Doctors = value; } }

        private string LastName;
        public string lastName { get { return LastName; } set { LastName = value; } }

        private string FirstName;
        public string firstName { get { return FirstName; } set { FirstName = value; } }

        public DateTime Birthdate;
        public DateTime birthDate { get { return Birthdate; } set { Birthdate = value; } }


        public Patient() { }

        public Patient(long patientID, string lastName, string firstName, DateTime bday)
        {
            PatientID = patientID;
            LastName = lastName;
            FirstName = firstName;
            Birthdate = bday;
        }

        public Patient(long patientID, byte[] passHashed, byte[] cardPIN, List<Doctor> doctors, string lastName, string firstName, DateTime bday)
        {
            PatientID = patientID;
            PassHashed = passHashed;
            CardPIN = cardPIN;
            Doctors = doctors;
            LastName = lastName;
            FirstName = firstName;
            Birthdate = bday;
        }

        public Patient(long patientID, byte[] passHashed, byte[] cardPIN, string lastName, string firstName, DateTime bday)
        {
            PatientID = patientID;
            PassHashed = passHashed;
            CardPIN = cardPIN;
            LastName = lastName;
            FirstName = firstName;
            Birthdate = bday;
        }
    }
}
