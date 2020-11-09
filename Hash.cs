using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainApp
{
    public class Hash
    {
        private int Nounce;
        public int nounce { get { return Nounce; } set { Nounce = value; } }

        private string TheString;
        public string theString { get { return theString; } set { theString = value; } }

        private string TheHash;
        public string theHash { get { return TheHash; } set { TheHash = value; } }

        public Hash(int nounce, string theString)
        {
            Nounce = nounce;
            TheString = theString;
            TheHash = computeHash();
        }

        public string computeHash()
        {
            var hasher = SHA256.Create();
            string toHash = TheString + Nounce;
            byte[] byteHash = System.Text.Encoding.UTF8.GetBytes(toHash);
            byte[] finalHash = hasher.ComputeHash(byteHash);
            //TheHash = Encoding.Default.GetString(finalHash);
            return Encoding.Default.GetString(finalHash);
        }
    }
}