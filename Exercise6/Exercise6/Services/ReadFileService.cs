using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise6.Services
{
    public class ReadFileService : IReadFileService
    {
        private readonly ICsvFileService _fileService;

        public ReadFileService(ICsvFileService fileService)
        {
            _fileService = fileService;
        }

        //Will read the file and determine if it is a correct file type
        public void ReadFilePath(string path)
        {
            string ext = Path.GetExtension(path);
            switch (ext) 
            {
                case ".csv":
                    Console.WriteLine("CSV file format detected. Begin processing...");
                    _fileService.CsvParser(path);
                    break;
                case ".edi":
                    Console.WriteLine("EDI file format detected. No Processing necessary.");
                    break;
                default:
                    Console.WriteLine("Invalid file format");
                    break;
            }
        }
    }
}
