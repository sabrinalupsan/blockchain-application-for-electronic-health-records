using System;

namespace BlockchainApp
{
    [Serializable]
    public class Block 
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

        private DateTime Timestamp;
        public DateTime timestamp { get { return Timestamp; } set { Timestamp = value; } }

        private int Nounce;
        public int nounce { get { return Nounce; } set { Nounce = value; } }

        private int Index;
        public int index { get { return Index; } set { Index = value; } }

        private string HashOfPrevBlock;
        public string hashOfPrevBlock { get { return HashOfPrevBlock; } set { HashOfPrevBlock = value; } }

        private string HashOfCurrBlock;
        public string hashOfCurrBlock { get { return HashOfCurrBlock; } set { HashOfCurrBlock = value; } }

        private Block()
        {

        }

        public Block(long patientID, long doctorID, string title, string description, DateTime date, DateTime timestamp, 
            int nounce, int index, string hashOfPrevBlock, string hashOfCurrBlock)
        {
            PatientID = patientID;
            DoctorID = doctorID;
            Title = title;
            Description = description;
            Date = date;
            Timestamp = timestamp;
            Nounce = nounce;
            Index = index;
            HashOfPrevBlock = hashOfPrevBlock;
            HashOfCurrBlock = hashOfCurrBlock;
        }

        public Block(long patientID, long doctorID, string title, string description, DateTime date, DateTime timestamp,
            int index, string hashOfPrevBlock, string hashOfCurrBlock)
        {
            PatientID = patientID;
            DoctorID = doctorID;
            Title = title;
            Description = description;
            Date = date;
            Timestamp = timestamp;
            Nounce = 0;
            Index = index;
            HashOfPrevBlock = hashOfPrevBlock;
            HashOfCurrBlock = hashOfCurrBlock;
        }

        public string toString()
        {
            return patientID + " " + doctorID + " " + title + " " + description + " " + date + " " + timestamp + " " + nounce + " " + index;
        }
    }
}
