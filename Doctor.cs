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

        private byte[] PassHashed;
        public byte[] passHashed { get { return PassHashed; } }

        private string Specialisation;
        public string specialisation { get { return Specialisation; } set { Specialisation = value; } }

        private string LastName;
        public string lastName { get { return LastName; } set { LastName = value; } }

        private string FirstName;
        public string firstName { get { return FirstName; } set { FirstName = value; } }

        private List<Patient> Patients;
        public List<Patient> patients { get { return Patients; } set { Patients = value; } }

        private byte[] TokenHashed;
        public byte[] tokenHashed { get { return TokenHashed; } }

        public DateTime lastLogin;

        public Doctor() { }

        public Doctor(long docID, byte[] passHashed, string specialisation, string lastName, string firstName, byte[] tokenHashed, DateTime lastLogin)
        {
            DocID = docID;
            PassHashed = passHashed;
            Specialisation = specialisation;
            LastName = lastName;
            FirstName = firstName;
            TokenHashed = tokenHashed;
            this.lastLogin = lastLogin;
        }

        public Doctor(long docID, byte[] passHashed, string specialisation, string lastName, string firstName, List<Patient> patients, byte[] tokenHashed, DateTime lastLogin)
        {
            DocID = docID;
            PassHashed = passHashed;
            Specialisation = specialisation;
            LastName = lastName;
            FirstName = firstName;
            Patients = patients;
            TokenHashed = tokenHashed;
            this.lastLogin = lastLogin;
        }
    }
}
