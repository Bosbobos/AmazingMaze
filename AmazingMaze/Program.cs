using System;
const int worldSize = 5;
int[,] mas = new int[worldSize, worldSize]  // Инициализируем двумерный массив 2 на 3
{ 
        { 0, 1, 2, 3, 4 },
        { 0, 1, 2, 3, 4 },   
        { 0, 1, 2, 3, 4 },    
        { 0, 1, 2, 3, 4 },    
        { 0, 1, 2, 3, 4 }
};

string world = @$"
████████████████████
███████        █████
███████  ████  █████
███████  ████  █████
███████  ████  █████
█        ████  █████
█11██████████  █████
█  ██████████  █████
█              █████
████████████████████
";
Console.WriteLine(world);
int rows = mas.GetUpperBound(0) + 1;//
int columns = mas.Length / rows;

WorldObjects[,] ConvertToWorld(string template)
{
    string[] words = template.Split(Environment.NewLine);

}

for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < columns; j++)
    {
        Console.Write($"{mas[i, j]} \t");
    }
    Console.WriteLine();
}