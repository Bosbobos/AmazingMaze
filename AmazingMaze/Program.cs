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

int rows = mas.GetUpperBound(0) + 1;// Количество строк
int columns = mas.Length / rows;

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
WorldObjects[,] ConvertToWorld(string template)// Метод, принимабщий строку и выводящий массив enum'ов WorldObjexts
{
    string[] words = template.Split(Environment.NewLine);// Разбивает нашу строку, каждая строчка - новый массив, В итоге получается двумерный массив

}

for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < columns; j++)
    {
        Console.Write($"{mas[i, j]} \t");
    }
    Console.WriteLine();
}