//start main

using mis_221_pa_5_dmhunt5;

Trainer[] trainers = new Trainer[50];
TrainerUtility trainerUtility = new TrainerUtility(trainers);
Listing[] listings = new Listing[100];
ListingUtility listingUtility = new ListingUtility(listings);
Booking[] bookings = new Booking[100];
BookingUtility bookingUtility = new BookingUtility(bookings);
Report report = new Report(bookings);

Console.Clear();
System.Console.WriteLine("Please choose one of the following options:");
System.Console.WriteLine("1. Trainers\n2. Listings\n3. Booking\n4. Reports\n5. Exit Application");
int option = 0;
string menuOption = Console.ReadLine();
while(option != 5)
{
    
    bookingUtility.Get(listingUtility.GetReturn(), trainerUtility.GetReturn());
    try
    {
        option = int.Parse(menuOption);
        if(option > 5 || option < 1)
        {
            throw new Exception("Please enter a valid menu option.");
        }
    }
    catch(Exception e)
    {
        System.Console.WriteLine(e.Message);
        System.Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        option = 0;
    }
    finally
    {
        if(option == 1)
        {
            trainerUtility.Menu();
        }
        else if(option == 2)
        {
            listingUtility.Menu();
        }
        else if(option == 3)
        {
            int searchVal = bookingUtility.Menu();
            int foundIndex = bookingUtility.Find(searchVal);
            while(searchVal != -1)
            {
                bookingUtility.BookSession(foundIndex);
                for(int i = 0; i < Listing.GetCount(); i++)
                {
                    if(listings[i].GetListingID() == bookings[foundIndex].GetSessionID())
                    {
                        listings[i].SetBooked(true);
                    }
                }
                Console.Clear();
                System.Console.WriteLine("Update successfully processed.");
                System.Console.WriteLine("Which session would you like to book?");
                System.Console.WriteLine("Enter -1 to exit.");
                bookingUtility.PrintBookings();
                string response = Console.ReadLine();
                searchVal = bookingUtility.TryCatch(response);
                foundIndex = bookingUtility.Find(searchVal);
            }
            bookingUtility.Save();


        }
        else if(option == 4)
        {
            report.Menu();
        }
        else if(option == 5)
        {
            Environment.Exit(0);
        }
        Console.Clear();
        System.Console.WriteLine("Please choose one of the following options:");
        System.Console.WriteLine("1. Trainers\n2. Listings\n3. Booking\n4. Reports\n5. Exit Application");
        menuOption = Console.ReadLine();
    }
}

//end main