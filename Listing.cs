namespace mis_221_pa_5_dmhunt5
{
    public class Listing
    {
        private int listingID;
        private string trainerName;
        private double sessionCost;
        private string sessionDate;
        private string sessionTime;
        private bool booked;
        static private int count;

        public Listing()
        {

        }
        public Listing(int listingID, string trainerName, double sessionCost, string sessionDate, string sessionTime, bool booked)
        {
            this.listingID = listingID;
            this.trainerName = trainerName;
            this.sessionCost = sessionCost;
            this.sessionDate = sessionDate;
            this.sessionTime = sessionTime;
            this.booked = booked;
        }
        public int GetListingID()
        {
            return listingID;
        }
        public void SetListingID(int listingID)
        {
            this.listingID = listingID;
        }
        public string GetTrainerName()
        {
            return trainerName;
        }
        public void SetTrainerName(string trainerName)
        {
            this.trainerName = trainerName;
        }
        public double GetSessionCost()
        {
            return sessionCost;
        }
        public void SetSessionCost(double sessionCost)
        {
            this.sessionCost = sessionCost;
        }
        public string GetSessionDate()
        {
            return sessionDate;
        }
        public void SetSessionDate(string sessionDate)
        {
            this.sessionDate = sessionDate;
        }
        public string GetSessionTime()
        {
            return sessionTime;
        }
        public void SetSessionTime(string sessionTime)
        {
            this.sessionTime = sessionTime;
        }
        public bool GetBooked()
        {
            return booked;
        }
        public void SetBooked(bool booked)
        {
            this.booked = booked;
        }
        static public int GetCount()
        {
            return Listing.count;
        }
        static public void SetCount(int count)
        {
            Listing.count = count;
        }
        static public void IncCount()
        {
            Listing.count++;
        }
        static public void DecCount()
        {
            Listing.count--;
        }
        public override string ToString()
        {
            return $"{listingID}\tTrainer Name: {trainerName}\tCost: {sessionCost}\tDate: {sessionDate}\tTime: {sessionTime}\tBooked: {booked}";
        }
        public string ToFile()
        {
            return $"{listingID}#{trainerName}#{sessionCost}#{sessionDate}#{sessionTime}#{booked}";
        }
    }
}