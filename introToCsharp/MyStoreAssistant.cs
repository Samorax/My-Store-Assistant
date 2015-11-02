using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStoreAssistant
{
    class MyStoreAssistant
    {
        static void Main(string[] args)
        {
            
            Help help = new Help(); //initialize object
            ConsoleDesign();
            help.HelpInit();
            
            
            //var HelpsKeys = HelpText.Substring(FirstIndex, HelpText.Length - FirstIndex).Trim();
            //Console.WriteLine(FirstIndex);
            //if (HELPS.ContainsKey(HelpsKeys)) 

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
        public Item ComponentAction { get; set; }
        
        
        public Help()
        {
            string Name;
            //string ComponentDescription;
            //ComponentAction;
        }

        //Constructors with parameters and default values.
        public Help(string name)
        {
            this.Name = name;
            this.ComponentAction = new Item();
            //this.ComponentDescription = "This contains the list of commands for the program";
        }
        
        
        public IDictionary<string,Help> HelpInformation()
        {
            IDictionary<string,Help> HelpInformations = new Dictionary<string,Help>();
            HelpInformations.Add("NEW ITEM",new Help { ComponentDescription = "NEW ITEM: This command allows you to add New Items into the collections" });
            HelpInformations.Add("COUNT ITEM", new Help { ComponentDescription = "COUNT ITEM: Use this command to know the number of items in your store" });
            
            return HelpInformations; //return the collection of helps with keys and values.
        }

       
        //public Array[] HelpAction()
        //{
        //    List<IDictionary> ActionLists = new List<IDictionary>();
        //    IDictionary<string,Help> HelpActions = new Dictionary<string, Help>();
        //    HelpActions.Add("NEW ITEM", new Help{ComponentAction = (Item)ItemStore(InputItem())});
        //    ActionLists.Add(HelpActions);

        //    return HelpActions; //return the collection of helps with keys and values.
        //}

        public void HelpInit()
        {
            Help help = new Help(); //initialize object
            Console.WriteLine("Enter: 'New Item' to insert new item into the store. Otherwise Enter 'help' for the various commands");
            string UserInput = Console.ReadLine();
            IDictionary<string, Help> HELPSINFORMATION = help.HelpInformation();
            //IDictionary<string, Help> HELPSACTION = help.HelpAction();
            var Capital = UserInput.ToUpper();
            if (Capital.Contains("HELP") && Capital.LastIndexOf("HELP") == 0)
            {
                string HelpsKeys = Capital.Substring("HELP".Length).Trim();
                if (HELPSINFORMATION.ContainsKey(HelpsKeys)) Console.WriteLine(HELPSINFORMATION[HelpsKeys].ComponentDescription);
                else
                {
                    foreach(var helpsinfo in HELPSINFORMATION.Keys) Console.WriteLine(HELPSINFORMATION[helpsinfo].ComponentDescription);
                }
            }
            //else foreach (var key in HELPSACTION.Keys)
            //{
            //    if (Capital.Contains(key) && Capital.LastIndexOf(key) == 0)
            //    {
            //        Console.WriteLine(HELPSACTION[key].ComponentAction);
            //    }
            //}
        }
    }
   

    public class Item
    {
        public string Name { get; set; }
        public double Amount { get; set; }
        public static int NumberOfItems { get; set; }
        public Item StoreItem { get;set; }
        
        

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
            //this.StoreItem = ItemStore();
        }

        public Item InputItem() //Form for inputing new item.
        {
            Console.Write("Enter Store Item:");
            string item = Console.ReadLine();
            Console.Write("Enter Item Amount:");
            double Amount = double.Parse(Console.ReadLine());
            Item StoreItem = new Item(item, Amount);
            Console.Clear();
            Console.WriteLine("You have entered: \n Item Name: {0} \n Item Amount: {1}", StoreItem.Name, StoreItem.Amount);
            Console.WriteLine("Enter Yes to Confirm or No to Cancel");
            string confirmation = Console.ReadLine();
            Item AnItem;
            if (confirmation.ToUpper() == "YES")
            {
                AnItem = StoreItem;
            }
            else
            {
                AnItem = InputItem();
            }
           
             return AnItem;
        }

        public IDictionary<string, double> ItemStore(Item StoreItem) //Store the new item in a dictionary, with name as key and anount as value.
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
