namespace mis_221_pa_5_dmhunt5
{
    public class BookingUtility
    {
        private Booking[] bookings;
        private Listing[] listings;
        private Trainer[] trainers;
        public BookingUtility(Booking[] bookings)
        {
            this.bookings = bookings;
        }
        public int Menu()
        {
            Console.Clear();
            System.Console.WriteLine("Which session would you like to book?");
            System.Console.WriteLine("Enter -1 to exit.");
            PrintBookings();
            string response = Console.ReadLine();
            int searchVal = TryCatch(response);
            return searchVal;
        }
        public void PrintBookings()
        {
            for(int i = 0; i < Booking.GetCount(); i++)
            {
                System.Console.WriteLine(bookings[i].ToString());
            }
        }
        public int TryCatch(string menuOption)
        {
            int option = -1;
            try
            {
                option = int.Parse(menuOption);
                if(option > Booking.GetCount() || option < -1)
                {
                    throw new Exception("Please enter a valid menu option.");
                }
            }
            catch(Exception e)
            {
                System.Console.WriteLine(e.Message);
                System.Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            return option;
        }
        public void Get(Listing[] listings, Trainer[] trainers)
        {
            // string date = DateTime.Now.ToShortDateString();

            for(int i = 0; i < Listing.GetCount(); i++)
            {
                if(listings[i].GetBooked() == false)//&& listings[i].GetSessionDate().CompareTo(date) > 0
                {
                    //initializing a new booking
                    bookings[Booking.GetCount()] = new Booking();
                    bookings[Booking.GetCount()].SetSessionID(Booking.GetCount());
                    bookings[Booking.GetCount()].SetCustomerName("");
                    bookings[Booking.GetCount()].SetCutsomerEmail("");
                    bookings[Booking.GetCount()].SetTrainingDate(listings[i].GetSessionDate());
                    for(int j = 0; j < Trainer.GetCount(); j++)
                    {
                        //can't figure out why it still puts 0 as the trainer id for all bookings.
                        if(listings[i].GetTrainerName() == trainers[j].GetTrainerName())
                        {
                            bookings[Booking.GetCount()].SetTrainerID(trainers[j].GetTrainerID());
                        }
                    }
                    bookings[Booking.GetCount()].SetTrainerName(listings[i].GetTrainerName());
                    bookings[Booking.GetCount()].SetStatus("Available");
                    Booking.IncCount();
                }
            }
        }
        public void BookSession(int foundIndex)
        {
            System.Console.WriteLine("What is the customer's name?");
            bookings[foundIndex].SetCustomerName(Console.ReadLine());
            System.Console.WriteLine("What is the customer's email?");
            bookings[foundIndex].SetCutsomerEmail(Console.ReadLine());
            bookings[foundIndex].SetStatus("Booked");
        }
        public int Find(int searchVal)
        {
            for(int i = 0; i < Booking.GetCount(); i++)
            {
                if(bookings[i].GetSessionID() == searchVal)
                {
                    return i;
                }
            }
            
            return -1;
        }
        public void Sort()
        {
            for(int i = 0; i < Booking.GetCount() - 1; i++)
            {
                int min = i;
                for(int j = i + 1; j < Booking.GetCount(); j++)
                {
                    if(bookings[j].GetSessionID().CompareTo(bookings[min].GetSessionID()) < 0)
                    {
                        min = j;
                    }
                }
                if(min != i)
                {
                    Swap(min, i);
                }
            }
        }
        public void Swap(int x, int y)
        {
            Booking temp = bookings[x];
            bookings[x] = bookings[y];
            bookings[y] = temp;
        }
        public void Save()
        {
            Sort();
            StreamWriter writeFile = new StreamWriter("transactions.txt");

            for(int i = 0; i < Booking.GetCount(); i++)
            {
                if(bookings[i].GetStatus() == "Booked")
                {
                    writeFile.WriteLine(bookings[i].ToFile());
                }
            }

            writeFile.Close();
        }
    }
}