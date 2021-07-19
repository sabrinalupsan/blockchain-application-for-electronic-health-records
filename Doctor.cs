using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainApp
{
    public class Doctor
    {
        private long DocID;
        public long docID { get { return DocID; } set { DocID = value; } }

        private byte[] HashedPassword;
        public byte[] hashedPassword { get { return HashedPassword; } }

        private string Specialisation;
        public string specialisation { get { return Specialisation; } set { Specialisation = value; } }

        private string LastName;
        public string lastName { get { return LastName; } set { LastName = value; } }

        private string FirstName;
        public string firstName { get { return FirstName; } set { FirstName = value; } }

        private List<Patient> Patients;
        public List<Patient> patients { get { return Patients; } set { Patients = value; } }

        private byte[] PINcode;
        public byte[] PINCode { get { return PINcode; } }

        private string EmailAddress;
        public string emailAddress { get { return EmailAddress; } set { EmailAddress = value; } }

        public Doctor() { }

        public Doctor(long docID, byte[] passHashed, string specialisation, string lastName, string firstName, byte[] PINhashed, DateTime lastLogin)
        {
            DocID = docID;
            HashedPassword = passHashed;
            Specialisation = specialisation;
            LastName = lastName;
            FirstName = firstName;
            PINcode = PINhashed;
        }

        public Doctor(long docID, byte[] passHashed, string specialisation, string lastName, string firstName, List<Patient> patients, byte[] PINhashed, DateTime lastLogin)
        {
            DocID = docID;
            HashedPassword = passHashed;
            Specialisation = specialisation;
            LastName = lastName;
            FirstName = firstName;
            Patients = patients;
            PINcode = PINhashed;
        }

        public Doctor(long docID, byte[] passHashed, string specialisation, string lastName, string firstName, List<Patient> patients, byte[] PINhashed, DateTime lastLogin, string emailAddress)
        {
            DocID = docID;
            HashedPassword = passHashed;
            Specialisation = specialisation;
            LastName = lastName;
            FirstName = firstName;
            Patients = patients;
            PINcode = PINhashed;
            EmailAddress = emailAddress;
        }
    }
}
