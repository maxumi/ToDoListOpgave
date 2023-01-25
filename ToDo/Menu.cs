using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo;

namespace ToDo
{
    internal class Menu
    {
        int id = 0;//This is a ID.
        List<ToDoItem> TodoList = new();//Creates a list for storing object data.
        public Menu()//This is a constructor. When used here, automaticly runs the code below.
        {
            FakeLists();//Uses a method for creating fake lists before the program the menu is created.
            while (true)//Loop for using the Menu.
            {
                MainMenu();//The MainMenu Loop.
                Console.ReadKey();
                Console.Clear();
            }
        }
         public void MainMenu()//Start
        {
            Console.WriteLine("Main Menu:\nShow List(1)\nCreate(2)\nUpdate(3)\nDelete(4)");

            switch (Console.ReadKey(true).Key)//Sees that key is pressed and case it uses.
            {
                case ConsoleKey.D1:
                    ShowTheList();
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    CreateToDoItem();
                    break;
                case ConsoleKey.D3:
                    UpdateItem();
                    break;
                case ConsoleKey.D4:
                    DeleteItem();
                    break;
                default:
                    break;
            }
        }
        private void FakeLists()//Makes 3 objects to add to the list.
        {
            ToDoItem FakeItem1 = new ToDoItem();
            FakeItem1.Id = id;
            FakeItem1.ToDo = "Draw a skech";
            FakeItem1.Created = DateTime.Now;
            string DeadlineString = "2023.2.2";
            FakeItem1.Deadline = DateTime.Parse(DeadlineString);
            FakeItem1.IsDone = false;
            FakeItem1.IsFavorite = false;
            TodoList.Add(FakeItem1);
            id++;//The id here is updated so each newly added object has a +1 to Current ID.
            ToDoItem FakeItem2 = new ToDoItem();
            FakeItem2.Id = id;
            FakeItem2.ToDo = "Go to Copenhagen";
            DeadlineString = "2024.2.2";
            FakeItem2.Deadline = DateTime.Parse(DeadlineString);
            FakeItem2.IsDone = false;
            FakeItem2.IsFavorite = false;
            TodoList.Add(FakeItem2);
            id++;

            ToDoItem FakeItem3 = new ToDoItem();
            FakeItem3.Id = id;
            FakeItem3.ToDo = "Paint the Mona lisa";
            DeadlineString = "2025.5.6";
            FakeItem3.Deadline = DateTime.Parse(DeadlineString);
            FakeItem3.IsDone = false;
            FakeItem3.IsFavorite = false;
            TodoList.Add(FakeItem3);
            id++;
        }
        private void CreateToDoItem()//Manually creates an object/List.
        {
            ToDoItem NewItem = new ToDoItem();
            NewItem.Id = id;
            NewItem.Created = DateTime.Now;
            Console.WriteLine("What is the \"ToDo\"?");
            NewItem.ToDo = Console.ReadLine();
            Console.WriteLine("What is the Deadline?");
            string DeadlineString = Console.ReadLine();
            NewItem.Deadline = DateTime.Parse(DeadlineString);
            NewItem.IsDone = false;
            Console.WriteLine("Is it Important? Press \"Y\" for Yes.");
            NewItem.IsFavorite=Console.ReadKey().Key == ConsoleKey.Y? true : false;//Like an if else statement by pressing "Y".
            TodoList.Add(NewItem);//Adds List to the "TodoList"
            id++;//Updates the ID
        }
        private void ShowTheList()
        {
            foreach (ToDoItem todoitem in TodoList)//Takes Every "ToDoItem" in Todolist and writes it out. 
            {
                ShowItem(todoitem);
                
            }
        }
        private void ShowItem(ToDoItem toDoItem)//Writes the text.
        {
            Console.WriteLine($"({toDoItem.Id})What: {toDoItem.ToDo} When: {toDoItem.Deadline} Is done: {toDoItem.IsDone}");
        }

        public void UpdateItem()
        {
            ShowTheList();//Shows the list for ease.
            Console.WriteLine("What Item do you want to update? Write the number");
            int Choice = Convert.ToInt32(Console.ReadLine());//Takes the number writen and converts to int.
            for (int i = 0; i < TodoList.Count; i++)
            {
                if (TodoList[i].Id == Choice)
                {//Redoes the whole Object by hand.
                    Console.WriteLine("Redo your Todo List.");
                    TodoList[i].Created = DateTime.Now;
                    Console.WriteLine("What is the \"ToDo\"?");
                    TodoList[i].ToDo = Console.ReadLine();
                    Console.WriteLine("What is the Deadline?");
                    string DeadlineString = Console.ReadLine();
                    TodoList[i].Deadline = DateTime.Parse(DeadlineString);
                    Console.WriteLine("Is it Done? Write \"Y\" for Yes and anything else for no.");
                    TodoList[i].IsDone = Console.ReadKey().Key == ConsoleKey.Y ? true : false;
                    Console.WriteLine("Is it Important? Press \"Y\" for Yes.");
                    TodoList[i].IsFavorite = Console.ReadKey().Key == ConsoleKey.Y ? true : false;
                }
            }

        }
        private void DeleteItem()
        {
            ShowTheList();//Shows the list for ease
            Console.WriteLine("What Item do you want to Delete? Write the number");
            int Choice = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < TodoList.Count; i++)//Looks through every object until it finds the right one
            {
                if (TodoList[i].Id == Choice)
                {
                    TodoList.RemoveAt(i);
                    Console.WriteLine($"You have deleted where it's ID is {i}");
                }
            }
        }
    }
}
