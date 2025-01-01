using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.Command.Command
{
    public interface ITableActionCommand
    {
        IActionResult Execute();
    }
}
