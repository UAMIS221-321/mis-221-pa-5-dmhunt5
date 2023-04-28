namespace mis_221_pa_5_dmhunt5
{
    public class ListingUtility
    {
        private Listing[] listings;
        public ListingUtility(Listing[] listings)
        {
            this.listings = listings;
        }
        public void Menu()
        {
            Get();
            Console.Clear();
            System.Console.WriteLine("What would you like to do?");
            System.Console.WriteLine("1. Add a listing\n2. Delete a listing\n3. Update a listing\n4. Exit");
            PrintListings();
            string menuOption = Console.ReadLine();
            int option = TryCatch(menuOption);
            while(option != 4)
            {
                if(option == 1)
                {
                    Add();
                }
                else if(option == 2)
                {
                    Delete();
                }
                else if(option == 3)
                {
                    Update();
                }
                Console.Clear();
                System.Console.WriteLine("What would you like to do?");
                System.Console.WriteLine("1. Add a listing\n2. Delete a listing\n3. Update a listing\n4. Exit");
                menuOption = Console.ReadLine();
                option = TryCatch(menuOption);
            }
        }
        public void PrintListings()
        {
            for(int i = 0; i < Listing.GetCount(); i++)
            {
                System.Console.WriteLine(listings[i].ToString());
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
        public void Get()
        {
            StreamReader inFile = new StreamReader("listings.txt");

            Listing.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null)
            {
                string[] temp = line.Split('#');
                listings[Listing.GetCount()] = new Listing(int.Parse(temp[0]), temp[1], double.Parse(temp[2]), temp[3], temp[4], bool.Parse(temp[5]));
                Listing.IncCount();
                line = inFile.ReadLine();
            }

            inFile.Close();
        }
        public Listing[] GetReturn()
        {
            StreamReader inFile = new StreamReader("listings.txt");

            Listing.SetCount(0);
            string line = inFile.ReadLine();
            int i = 0;
            while(line != null)
            {
                string[] temp = line.Split('#');
                listings[Listing.GetCount()] = new Listing(int.Parse(temp[0]), temp[1], double.Parse(temp[2]), temp[3], temp[4], bool.Parse(temp[5]));
                Listing.IncCount();
                line = inFile.ReadLine();
                i++;    
            }

            inFile.Close();
            return listings;
        }
        public void Add()
        {
            System.Console.WriteLine("Please enter the trainer's name: ");
            Listing newListing = new Listing();
            newListing.SetListingID(Listing.GetCount());
            newListing.SetTrainerName(Console.ReadLine());
            System.Console.WriteLine("Please enter the cost of the session in US dollars(XX.XX): ");
            newListing.SetSessionCost(double.Parse(Console.ReadLine()));
            System.Console.WriteLine("Please enter the date of the session seperated by forward slashes(XX/XX/XXXX): ");
            newListing.SetSessionDate(Console.ReadLine());
            System.Console.WriteLine("Please enter the time of the session seperated by a colon(XX:XX): ");
            newListing.SetSessionTime(Console.ReadLine());
            listings[Listing.GetCount()] = newListing;
            Listing.IncCount();

            Save();
        }
        public void Update()
        {
            System.Console.WriteLine("What is the ID of the listing you would like to update?");
            PrintListings();
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);

            if(foundIndex != -1)
            {
                System.Console.WriteLine("Please enter the trainer's name: ");
                listings[foundIndex].SetTrainerName(Console.ReadLine());
                System.Console.WriteLine("Please enter the cost of the session: ");
                listings[foundIndex].SetSessionCost(int.Parse(Console.ReadLine()));
                System.Console.WriteLine("Please enter the date of the session: ");
                listings[foundIndex].SetSessionDate(Console.ReadLine());
                System.Console.WriteLine("Please enter the time of the session: ");
                listings[foundIndex].SetSessionTime(Console.ReadLine());

                Save();
            }

            else
            {
                System.Console.WriteLine("This listing does not exist.");
                System.Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        public void Delete()
        {
            //EXTRA When deleting trainer use for loop to rewrite each trainer back one so that you don't have records filled with N/A
            System.Console.WriteLine("What is the ID of the listing you would like to delete?");
            PrintListings();
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);

            if(foundIndex != -1)
            {
                for(int i = foundIndex+1; i < Listing.GetCount(); i++)
                {
                    listings[i].SetListingID(listings[i].GetListingID()-1);
                    listings[i-1] = listings[i];
                }

                //I was trying to delete a specific line but couldn't figure out how,
                //So what I'm doing is writing over the specific line, moving every line back one and then deleting the last
                //line of the file because it leaves a duplicate of the last record

                Save();

                string[] lines = File.ReadAllLines("listings.txt");
                File.WriteAllLines("listings.txt", lines.Take(lines.Length - 1).ToArray());
                Listing.DecCount();
            }

            else
            {
                System.Console.WriteLine("This listing does not exist.");
                System.Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        public int Find(int searchVal)
        {
            for(int i = 0; i < Listing.GetCount(); i++)
            {
                if(listings[i].GetListingID() == searchVal)
                {
                    return i;
                }
            }
            
            return -1;
        }
        public void Sort()
        {
            for(int i = 0; i < Listing.GetCount() - 1; i++)
            {
                int min = i;
                for(int j = i + 1; j < Listing.GetCount(); j++)
                {
                    if(listings[j].GetListingID().CompareTo(listings[min].GetListingID()) < 0)
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
            Listing temp = listings[x];
            listings[x] = listings[y];
            listings[y] = temp;
        }
        public void Save()
        {
            Sort();
            StreamWriter writeFile = new StreamWriter("listings.txt");

            for(int i = 0; i < Listing.GetCount(); i++)
            {
                writeFile.WriteLine(listings[i].ToFile());
            }

            writeFile.Close();
        }
    }
}