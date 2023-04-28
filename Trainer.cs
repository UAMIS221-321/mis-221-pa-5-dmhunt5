namespace mis_221_pa_5_dmhunt5
{
    public class Trainer
    {
        private int trainerID;
        private string trainerName;
        private string mailingAddress;
        private string trainerEmail;
        static private int count;
        public Trainer()
        {

        }

        public Trainer(int trainerID, string trainerName, string mailingAddress, string trainerEmail)
        {
            this.trainerID = trainerID;
            this.trainerName = trainerName;
            this.mailingAddress = mailingAddress;
            this.trainerEmail = trainerEmail;
        }
        public int GetTrainerID()
        {
            return trainerID;
        }
        public void SetTrainerID(int trainerID)
        {
            this.trainerID = trainerID;
        }
        public string GetTrainerName()
        {
            return trainerName;
        }
        public void SetTrainerName(string trainerName)
        {
            this.trainerName = trainerName;
        }
        public string GetMailingAddress()
        {
            return mailingAddress;
        }
        public void SetMailingAddress(string mailingAddress)
        {
            this.mailingAddress = mailingAddress;
        }
        public string GetTrainerEmail()
        {
            return trainerEmail;
        }
        public void SetTrainerEmail(string trainerEmail)
        {
            this.trainerEmail = trainerEmail;
        }
        static public int GetCount()
        {
            return Trainer.count;
        }
        static public void SetCount(int count)
        {
            Trainer.count = count;
        }
        static public void IncCount()
        {
            Trainer.count++;
        }
        static public void DecCount()
        {
            Trainer.count--;
        }
        public override string ToString()
        {
            return $"{trainerID}\tName: {trainerName}\t\tAddress: {mailingAddress}\t\tEmail: {trainerEmail}";
        }
        public string ToFile()
        {
            return $"{trainerID}#{trainerName}#{mailingAddress}#{trainerEmail}";
        }
    }
}