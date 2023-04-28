namespace mis_221_pa_5_dmhunt5
{
    public class Report
    {
        Booking[] bookings;
        public Report(Booking[] bookings)
        {
            this.bookings = bookings;
        }
        public void Menu()
        {
            System.Console.WriteLine("What would you like to do?");
            System.Console.WriteLine("1. See customer's previous sessions\n2. See all previous sessions\n3. See revenue report\n4. Exit");
            string menuOption = Console.ReadLine();
            int option = TryCatch(menuOption);
            while(option != 4)
            {
                if(option == 1)
                {
                    CustomerReport();
                }
                else if(option == 2)
                {
                    AllCustomersReport();
                }
                else if(option == 3)
                {
                    RevenueReport();
                }
                System.Console.WriteLine("What would you like to do?");
                System.Console.WriteLine("1. See customer's previous sessions\n2. See all previous sessions\n3. See revenue report\n4. Exit");
                menuOption = Console.ReadLine();
                option = TryCatch(menuOption);
            }
        }
        public int TryCatch(string menuOption)
        {
            int option = 0;
            try
            {
                option = int.Parse(menuOption);
                if(option > 4 || option < 1)
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
        public void CustomerReport()
        {
            StreamReader inFile = new StreamReader("transactions.txt");

            Booking.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null)
            {
                string[] temp = line.Split('#');
                bookings[Booking.GetCount()] = new Booking(int.Parse(temp[0]), temp[1], temp[2], temp[3], int.Parse(temp[4]), temp[5], temp[6]);
                Booking.IncCount();
                line = inFile.ReadLine();
            }

            inFile.Close();

            System.Console.WriteLine("Please enter the email of the customer you are looking for: ");
            string customerEmail = Console.ReadLine();

            for(int i = 0; i < Booking.GetCount(); i++)
            {
                if(bookings[i].GetCustomerEmail() == customerEmail)
                {  
                    System.Console.WriteLine(bookings[i].ToString());
                }
            }

            System.Console.WriteLine("Would you like to save this to a file? Yes/No");
            string response = Console.ReadLine();
            if(response.ToUpper() == "YES")
            {
                System.Console.WriteLine("What would you like to name the file?");
                StreamWriter writeFile = new StreamWriter(Console.ReadLine());

                for(int i = 0; i < Booking.GetCount(); i++)
                {
                    if(bookings[i].GetCustomerEmail() == customerEmail)
                    {
                        writeFile.WriteLine(bookings[i].ToFile());
                    }
                }
                writeFile.Close();
            }
        }
        public void AllCustomersReport()
        {
            StreamReader inFile = new StreamReader("transactions.txt");

            Booking.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null)
            {
                string[] temp = line.Split('#');
                bookings[Booking.GetCount()] = new Booking(int.Parse(temp[0]), temp[1], temp[2], temp[3], int.Parse(temp[4]), temp[5], temp[6]);
                Booking.IncCount();
                line = inFile.ReadLine();
            }

            inFile.Close();
            for(int i = 0; i < Booking.GetCount(); i++)
            {
                System.Console.WriteLine(bookings[i].ToString());
            }

            System.Console.WriteLine("Would you like to save this to a file? Yes/No");
            string response = Console.ReadLine();
            if(response.ToUpper() == "YES")
            {
                System.Console.WriteLine("What would you like to name the file?");
                StreamWriter writeFile = new StreamWriter(Console.ReadLine());

                for(int i = 0; i < Booking.GetCount(); i++)
                {
                    writeFile.WriteLine(bookings[i].ToFile());
                }
                writeFile.Close();
            }
        }
        public void RevenueReport()
        {
            System.Console.WriteLine($"Your company has made ${Booking.GetCount()*50}!");
        }
    }
}