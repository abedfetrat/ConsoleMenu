namespace ConsoleMenu;

public class Menu
{
    private int selectedIndex = 0;

    public string Title { get; set; } = "Menu";
    public string Description { get; set; } = "";
    public string Instructions { get; set; } = "Navigate the menu with UP and DOWN arrow keys. Press ENTER to make a selection.";
    // Wether or not to show menu again after invoking an action.
    public bool Reappearing { get; set; } = true;
    public List<MenuItem> Items { get; set; } = [];
    public MenuConfig Config { get; set; } = new MenuConfig();

    public void Show()
    {
        Console.ForegroundColor = Config.TextColor;
        Console.BackgroundColor = Config.BackgroundColor;
        Console.Clear();

        PrintHeader();
        PrintItems();
        HandleUserInput();
    }

    private void HandleUserInput()
    {
        ConsoleKey up = Config.UpNavigationKey;
        var key = Console.ReadKey().Key;
        switch (key)
        {
            case var _ when key == Config.UpNavigationKey:
                if (selectedIndex == 0)
                {
                    selectedIndex = Items.Count - 1;
                }
                else
                {
                    selectedIndex--;
                }
                Show();
                break;
            case var _ when key == Config.DownNavigationKey:
                if (selectedIndex == Items.Count - 1)
                {
                    selectedIndex = 0;
                }
                else
                {
                    selectedIndex++;
                }
                Show();
                break;
            case var _ when key == Config.SelectNavigationKey:
                var selectedItem = Items[selectedIndex];
                selectedItem.Action.Invoke();
                if (Reappearing)
                {
                    Show();
                }
                break;
            default:
                Show();
                break;
        }
    }

    private void PrintHeader()
    {
        if (!string.IsNullOrEmpty(Title))
        {
            Console.ForegroundColor = Config.TitleTextColor;
            Console.BackgroundColor = Config.TitleBgColor;
            Console.WriteLine(Title + "\n");
            Console.ResetColor();
        }

        Console.ForegroundColor = Config.TextColor;
        if (!string.IsNullOrEmpty(Description))
        {
            Console.WriteLine(Description + "\n");
        }
        if (!string.IsNullOrEmpty(Instructions))
        {
            Console.WriteLine(Instructions + "\n");
        }
        Console.ResetColor();
    }

    private void PrintItems()
    {
        for (int i = 0; i < Items.Count; i++)
        {
            string title = Items[i].Title;
            string rightPadding = GetItemRightPadding(title);
            if (selectedIndex == i)
            {
                Console.ForegroundColor = Config.SelectedItemTextColor;
                Console.BackgroundColor = Config.SelectedItemBgColor;
                Console.WriteLine($"{GetItemLeftPadding(true)}{Config.SelectedItemSymbol} {title}{rightPadding}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = Config.TextColor;
                Console.WriteLine($"{GetItemLeftPadding()}{title}{rightPadding}");
                Console.ResetColor();
            }
        }
    }

    private string GetItemLeftPadding(bool selected = false)
    {
        int a = selected ? 0 : Config.SelectedItemSymbol.Length + 1;
        int padd = a + Config.ItemLeftPadding;
        return new string(' ', padd);
    }

    private string GetItemRightPadding(string title)
    {
        int max = Items.Max(item => item.Title.Length);
        var padd = max - title.Length;
        return new string(' ', padd + Config.ItemRightPadding);
    }
}
