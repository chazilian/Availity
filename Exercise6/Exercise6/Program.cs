// See https://aka.ms/new-console-template for more information
using Exercise6.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IServiceProvider BuildServices() => new ServiceCollection()
    .AddTransient<ISeperateEnrolleeService, SeperateEnrolleeService>()
    .AddTransient<ICsvFileService, CsvFileService>()
    .AddTransient<IReadFileService, ReadFileService>()
    .BuildServiceProvider();

var svcProvicer = BuildServices();

var service = ActivatorUtilities.CreateInstance<ReadFileService>(svcProvicer);

Console.WriteLine("Input a file path to process:");
string? input = Console.ReadLine();
while (input == null || input.Length == 0)
{
    Console.WriteLine("Input a file path to process:");
    input = Console.ReadLine();
}
service.ReadFilePath(input);

Console.WriteLine("Finished Processing file");

Console.ReadLine();
//C:\Users\Foobar\Downloads\sample_availity.csv