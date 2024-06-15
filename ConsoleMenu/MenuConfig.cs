namespace ConsoleMenu;

public class MenuConfig
{
    public ConsoleColor BackgroundColor { get; set; } = ConsoleColor.Black;
    public ConsoleColor TextColor { get; set; } = ConsoleColor.Gray;
    public ConsoleColor TitleTextColor { get; set; } = ConsoleColor.White;
    public ConsoleColor TitleBgColor { get; set; } = ConsoleColor.Black;
    public ConsoleColor SelectedItemTextColor { get; set; } = ConsoleColor.Black;
    public ConsoleColor SelectedItemBgColor { get; set; } = ConsoleColor.White;
    public string SelectedItemSymbol { get; set; } = ">";
    public int ItemLeftPadding { get; set; } = 1;
    public int ItemRightPadding { get; set; } = 1;
    public ConsoleKey UpNavigationKey { get; set; } = ConsoleKey.UpArrow;
    public ConsoleKey DownNavigationKey { get; set; } = ConsoleKey.DownArrow;
    public ConsoleKey SelectNavigationKey { get; set; } = ConsoleKey.Enter;
}
