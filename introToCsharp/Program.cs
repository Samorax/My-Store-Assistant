using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace introToCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Item item = new Item(); //initialize object
            Help help = new Help(); //initialize object
            ConsoleDesign();
            //Console.WriteLine("Enter: 'New Item' to insert new item into the store. Otherwise Enter 'help' for the various commands");
            //string UserInput = Console.ReadLine();
            IDictionary<string,List<object>> HELPS = help.HelpCommands();
            Console.WriteLine(HELPS.ContainsKey("NEW ITEM"));
            Console.ReadLine();
        }

        public static void ConsoleDesign()
        {
            Console.Title = "Learning C#";
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
        }
    }

    //The helps should have a Name and Description. The call of the name of a specific help
    //should perfrom an action, for instance, like creating a new input phase.
    //The call of the Description should return the description of the Help specified or a lsit of allhelps and description.
    public class Help:Item
    {
        public string Name { get; set; }
        public string ComponentDescription { get; set; }
        private object ComponentAction { get; set; }
        
        public Help()
        {
            string Name;
            string ComponentDescription;
            object ComponentAction;
        }

        //Constructors with parameters and default values.
        public Help(string name)
        {
            this.Name = name;
            this.ComponentDescription = "This contains the list of commands for the program";
            this.ComponentAction = Describe();

        }
        
        //Help Dictionary: The elements in the dictionary contains a key; the first part  and a list the contains two parts.
        public IDictionary<string,List<object>> HelpCommands()
        {
            IDictionary<string,List<object>> HelpCommands = new Dictionary<string,List<object>>();
            HelpCommands["NEW ITEM"] = new List<object> 
            { 
                new Help { ComponentDescription = "This command allows you to add New Items into the collections"},
                //new Help().ItemStore(InputItem())
            };
            HelpCommands["COUNT ITEM"] = new List<object> 
            {
                new Help { ComponentDescription = "Use this command to know the number of items in your store"},
            };
            return HelpCommands; //return the collection of helps with keys and values.
        }

        //The method searches the keys of the dictionary and find a match for the argument.
        //If a match of the argument is found, the method should retrun the action of the help specified.
        public void HelpAction()
        {
            if (HelpCommands().ContainsKey(Name)) Console.Write(HelpCommands()[Name][1]);
            Console.Write("The command is not recognised");
        }

        //The method searches the keys of the dictionary and finds a match for the argument.
        //If a macth of the argument is found, the method returns the description of the specificed help.
        public object Describe()
        {
            if (HelpCommands().ContainsKey(Name)) return HelpCommands()[Name][0];
            return ("The command is not recognised");
        }
        
        

    }
   
    public class Item
    {
        public string Name { get; set; }
        public double Amount { get; set; }

        // default constructor
        public Item()
        {
            string Name;
            double Amount;
        }

        // constructor with parameters
        public Item(string name, double amount)
        {
            this.Amount = amount;
            this.Name = name;
        }

        public Item InputItem()
        {
            Console.Write("Enter Store Item:");
            string item = Console.ReadLine();
            Console.Write("Enter Item Amount:");
            double Amount = double.Parse(Console.ReadLine());
            Item StoreItem = new Item(item, Amount);
            return StoreItem;
        } 

        public IDictionary<string, double> ItemStore(Item StoreItem)
        {
            IDictionary<string, double> Splitted = new Dictionary<string, double>();
            Splitted.Add(StoreItem.Name,StoreItem.Amount);
            Console.WriteLine("The Item has been added to collection");
            Console.WriteLine("Will you like to add a new item, Yes or No?");
            string ItemInputAnswer = Console.ReadLine();
            if (ItemInputAnswer.ToUpper() == "YES")
            {
                Console.Clear();
                ItemStore(InputItem());
            }
            return Splitted;
        }

        public void ItemCount(IDictionary<string, double> Splitted)
        {
            Console.Write("The number of items in this store is {0}", Splitted.Count);
        }

        public void ItemDescription(IDictionary<string, double> store, string item)
        {
            if (store.ContainsKey(item))
            {
                Console.WriteLine("Item: {0}", store.Keys);
                Console.WriteLine("Amount: {0:0.00}", store.Values);
            }
            Console.WriteLine("{0} cannot be found", store.Keys);
        }
       

    }
}
