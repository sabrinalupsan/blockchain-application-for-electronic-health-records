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

        private List<Pacient> Pacients;
        public List<Pacient> pacients { get { return Pacients; } set { Pacients = value; } }

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

        public Doctor(long docID, byte[] passHashed, string specialisation, string lastName, string firstName, List<Pacient> pacients, byte[] tokenHashed, DateTime lastLogin)
        {
            DocID = docID;
            PassHashed = passHashed;
            Specialisation = specialisation;
            LastName = lastName;
            FirstName = firstName;
            Pacients = pacients;
            TokenHashed = tokenHashed;
            this.lastLogin = lastLogin;
        }
    }
}
