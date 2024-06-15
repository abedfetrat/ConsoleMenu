namespace ConsoleMenu;

public class MenuItem
{
    public string Title { get; set; } = "";
    public Action Action { get; set; } = () => { };
}
