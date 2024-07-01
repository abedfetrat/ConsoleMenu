using ConsoleMenu;

var title = @"
  __  __   _   ___ _  _   __  __ ___ _  _ _   _ 
 |  \/  | /_\ |_ _| \| | |  \/  | __| \| | | | |
 | |\/| |/ _ \ | || .` | | |\/| | _|| .` | |_| |
 |_|  |_/_/ \_\___|_|\_| |_|  |_|___|_|\_|\___/                                                                     
";

var menu = new Menu()
{
    Title = title,
    Items = [
        new(){Title = "Item 1", Action = () => {
            Console.Clear();
            Console.WriteLine("Hello World!\n\nPress ENTER to go back to the menu.");
            Console.ReadLine();
        }},
        new(){Title = "Item 2"},
        new(){Title = "Item 3"},
        new(){Title = "Item 4"},
        new(){Title = "Item 5"},
        new(){Title = "Item 6"},
    ],
    Config = new MenuConfig()
    {
        BackgroundColor = ConsoleColor.Black,
        TextColor = ConsoleColor.Gray,
        TitleTextColor = ConsoleColor.Cyan,
        SelectedItemTextColor = ConsoleColor.Yellow,
        SelectedItemBgColor = ConsoleColor.Black,
    },
};

menu.Show();