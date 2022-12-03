using globothai.Adapters;
using globothai.Controllers;
using globothai.Repositorie;
using globothai.Utils;
using System.Text.Json;

bool runProgram = true;

string dbPath = Path.Combine(Directory.GetCurrentDirectory(), "db.json");
TimeUtils timeUtils = new TimeUtils();
GridRepositorie gridRepositorie = new GridRepositorie(dbPath);
LineAdapter lineAdapter = new LineAdapter();
GridController gridController = new GridController(gridRepositorie, lineAdapter, timeUtils);


Console.WriteLine("Funcionando");

while (runProgram)
{
    string? input = Console.ReadLine();
    char type = input[0];

    switch (type)
    {
        case 'S':
            gridController.InsertGridLine(input);
            break;
        case 'Q':
            gridController.Query(input);
            break;
        default:
            break;
    }

}