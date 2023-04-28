namespace mis_221_pa_5_dmhunt5
{
    public class Booking
    {
        private int sessionID;
        private string customerName;
        private string customerEmail;
        private string trainingDate;
        private int trainerID;
        private string trainerName;
        private string status;
        static private int count;
        public Booking()
        {

        }
        public Booking(int sessionID, string customerName, string customerEmail, string trainingDate, int trainerID, string trainerName, string status)
        {
            this.sessionID = sessionID;
            this.customerName = customerName;
            this.customerEmail = customerEmail;
            this.trainingDate = trainingDate;
            this.trainerID = trainerID;
            this.trainerName = trainerName;
            this.status = status;
        }
        public int GetSessionID()
        {
            return sessionID;
        }
        public void SetSessionID(int sessionID)
        {
            this.sessionID = sessionID;
        }
        public string GetCustomerName()
        {
            return customerName;
        }
        public void SetCustomerName(string customerName)
        {
            this.customerName = customerName;
        }
        public string GetCustomerEmail()
        {
            return customerEmail;
        }
        public void SetCutsomerEmail(string customerEmail)
        {
            this.customerEmail = customerEmail;
        }
        public string GetTrainingDate()
        {
            return trainingDate;
        }
        public void SetTrainingDate(string trainingDate)
        {
            this.trainingDate = trainingDate;
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
        public string GetStatus()
        {
            return status;
        }
        public void SetStatus(string status)
        {
            this.status = status;
        }
        static public int GetCount()
        {
            return Booking.count;
        }
        static public void SetCount(int count)
        {
            Booking.count = count;
        }
        static public void IncCount()
        {
            Booking.count++;
        }
        public override string ToString()
        {
            return $"{sessionID}\tCustomer Name: {customerName}\tCustomer Email: {customerEmail}\t{trainingDate}\t{trainerID}\t{trainerName}\t{status}";
        }
        public string ToFile()
        {
            return $"{sessionID}#{customerName}#{customerEmail}#{trainingDate}#{trainerID}#{trainerName}#{status}";
        }
    }
}