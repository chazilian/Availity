// See https://aka.ms/new-console-template for more information
using Exercise4;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IServiceProvider BuildServices() => new ServiceCollection()
    .AddTransient<IParenthesesService, ParenthesesService>()
    .BuildServiceProvider();

var svcProvicer = BuildServices();

var service = ActivatorUtilities.CreateInstance<ParenthesesService>(svcProvicer);

Console.WriteLine("Input a string to validate parenthesis:");
string? input = Console.ReadLine();
while (input == null)
{
    Console.WriteLine("Input a string to validate parenthesis:");
    input = Console.ReadLine();
}

Console.WriteLine("Parenthesis are valid:" + service.checkParaentheses(input));

Console.ReadLine();
