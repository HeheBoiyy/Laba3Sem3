using BusinessLogic;
using System.Drawing;
using Spectre.Console;
using System.Collections.Generic;
using Ninject;
namespace ConsoleApp
{
    /// <summary>
    /// Главный класс приложения ConsoleApp.
    /// </summary>
    /// <remarks>
    /// Этот класс инициализирует контейнер зависимостей Ninject, 
    /// получает экземпляр бизнес-логики и запускает пользовательский интерфейс.
    /// </remarks>
    internal class Program
    {
        static void Main(string[] args)
        {
            IKernel ninjectKernel = new StandardKernel(new SimpleConfigModule());
            var logic = ninjectKernel.Get<IStudentLogic>();
            IUserInterface userInterface = new ConsoleUserInterface(logic);
            userInterface.Start();
        }
    }
}
