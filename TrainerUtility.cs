namespace mis_221_pa_5_dmhunt5
{
    public class TrainerUtility
    {
        private Trainer[] trainers;
        public TrainerUtility(Trainer[] trainers)
        {
            this.trainers = trainers;
        }
        public void Menu()
        {
            Get();
            Console.Clear();
            System.Console.WriteLine("What would you like to do?");
            System.Console.WriteLine("1. Add a trainer\n2. Delete a trainer\n3. Update a trainer\n4. Exit");
            PrintTrainers();
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
                System.Console.WriteLine("1. Add a trainer\n2. Delete a trainer\n3. Update a trainer\n4. Exit");
                menuOption = Console.ReadLine();
                option = TryCatch(menuOption);
            }
        }
        public void PrintTrainers()
        {
            for(int i = 0; i < Trainer.GetCount(); i++)
            {
                System.Console.WriteLine(trainers[i].ToString());
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
            StreamReader inFile = new StreamReader("trainers.txt");

            Trainer.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null)
            {
                string[] temp = line.Split('#');
                trainers[Trainer.GetCount()] = new Trainer(int.Parse(temp[0]), temp[1], temp[2], temp[3]);
                Trainer.IncCount();
                line = inFile.ReadLine();
            }

            inFile.Close();
        }
        public Trainer[] GetReturn()
        {
            StreamReader inFile = new StreamReader("trainers.txt");

            Trainer.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null)
            {
                string[] temp = line.Split('#');
                trainers[Trainer.GetCount()] = new Trainer(int.Parse(temp[0]), temp[1], temp[2], temp[3]);
                Trainer.IncCount();
                line = inFile.ReadLine();
            }

            inFile.Close();
            return trainers;
        }
        public void Add()
        {
            System.Console.WriteLine("Please enter the trainer's name: ");
            Trainer newTrainer = new Trainer();
            newTrainer.SetTrainerID(Trainer.GetCount());
            newTrainer.SetTrainerName(Console.ReadLine());
            System.Console.WriteLine("Please enter the trainer's mailing address: ");
            newTrainer.SetMailingAddress(Console.ReadLine());
            System.Console.WriteLine("Please enter the trainer's email: ");
            newTrainer.SetTrainerEmail(Console.ReadLine());
            trainers[Trainer.GetCount()] = newTrainer;
            Trainer.IncCount();
            Trainer.IncCount();

            Save();
        }
        public void Update()
        {
            Console.Clear();
            System.Console.WriteLine("What is the name of the trainer you would like to update?");
            PrintTrainers();
            string searchVal = Console.ReadLine();
            int foundIndex = Find(searchVal);

            if(foundIndex != -1)
            {
                System.Console.WriteLine("Please enter the trainer's name: ");
                trainers[foundIndex].SetTrainerName(Console.ReadLine());
                System.Console.WriteLine("Please enter the trainer's mailing address: ");
                trainers[foundIndex].SetMailingAddress(Console.ReadLine());
                System.Console.WriteLine("Please enter the trainer's email: ");
                trainers[foundIndex].SetTrainerEmail(Console.ReadLine());

                Save();
            }

            else
            {
                System.Console.WriteLine("This trainer does not exist.");
                System.Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        public void Delete()
        {
            Console.Clear();
            //EXTRA When deleting trainer use for loop to rewrite each trainer back one so that you don't have records filled with N/A
            System.Console.WriteLine("What is the name of the trainer you would like to delete?");
            PrintTrainers();
            string searchVal = Console.ReadLine();
            int foundIndex = Find(searchVal);

            if(foundIndex != -1)
            {
                for(int i = foundIndex+1; i < Trainer.GetCount(); i++)
                {
                    trainers[i].SetTrainerID(trainers[i].GetTrainerID()-1);
                    trainers[i-1] = trainers[i];
                }

                //I was trying to delete a specific line but couldn't figure out how,
                //So what I'm doing is writing over the specific line, moving every line back one and then deleting the last
                //line of the file because it leaves a duplicate of the last record

                Save();
                //Had to have save before the deleting line code in order to actually have the changes save to the file.

                string[] lines = File.ReadAllLines("trainers.txt");
                File.WriteAllLines("trainers.txt", lines.Take(lines.Length - 1).ToArray());
                Trainer.DecCount();
                //creates a string array filled with all the lines in the file, then writes all the lines minus the last line. 
                //then finally decreases count. THIS MAKES HAVING TWO SEPERATE COUNT VARIABLES UNNECESSARY
            }

            else
            {
                System.Console.WriteLine("This trainer does not exist.");
                System.Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        public int Find(string searchVal)
        {
            for(int i = 0; i < Trainer.GetCount(); i++)
            {
                if(trainers[i].GetTrainerName().ToUpper() == searchVal.ToUpper())
                {
                    return i;
                }
            }
            
            return -1;
        }
        public void Sort()
        {
            for(int i = 0; i < Trainer.GetCount() - 1; i++)
            {
                int min = i;
                for(int j = i + 1; j < Trainer.GetCount(); j++)
                {
                    if(trainers[j].GetTrainerID().CompareTo(trainers[min].GetTrainerID()) < 0)
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
            Trainer temp = trainers[x];
            trainers[x] = trainers[y];
            trainers[y] = temp;
        }
        public void Save()
        {
            Sort();
            StreamWriter writeFile = new StreamWriter("trainers.txt");

            for(int i = 0; i < Trainer.GetCount(); i++)
            {
                writeFile.WriteLine(trainers[i].ToFile());
            }

            writeFile.Close();
        }
    }
}