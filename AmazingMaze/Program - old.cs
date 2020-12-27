//using System;
//const int worldSize = 5;
//int[,] mas = new int[worldSize, worldSize]  // Инициализируем двумерный массив 2 на 3
//{ 
//        { 0, 1, 2, 3, 4 },
//        { 0, 1, 2, 3, 4 },   
//        { 0, 1, 2, 3, 4 },    
//        { 0, 1, 2, 3, 4 },    
//        { 0, 1, 2, 3, 4 }
//};

//int rows = mas.GetUpperBound(0) + 1;// Количество строк
//int columns = mas.Length / rows;

//string world = @$"
//████████████████████
//███████        █████
//███████  ████  █████
//███████  ████  █████
//███████  ████  █████
//█        ████  █████
//█11██████████  █████
//█  ██████████  █████
//█              █████
//████████████████████
//";
//Console.WriteLine(world);
//WorldObjects[,] ConvertToWorld(string template)// Метод, принимабщий строку и выводящий массив enum'ов WorldObjexts
//{
//    string[] words = template.Split(Environment.NewLine);// Разбивает нашу строку, каждая строчка - новый массив, В итоге получается двумерный массив

//}

//for (int i = 0; i < rows; i++)
//{
//    for (int j = 0; j < columns; j++)
//    {
//        Console.Write($"{mas[i, j]} \t");
//    }
//    Console.WriteLine();
//}

//string worldTemplate = @$"00██████
//██▓▓  ██
//████00██
//████████";

//world = StringToWorldObjects(worldTemplate, worldSize);

//WorldObjects[,] StringToWorldObjects(string data, int size)
//{
//    var result = new WorldObjects[size, size];

//    string[] worldLines = data.Split(Environment.NewLine); // разделяет строки на подстроки, разделитель - знак новой строки

//    var y = 0;
//    for (int x = 0; x < worldLines.Length; x++)
//    {
//        var line = worldLines[x];
//        for (int i = 0; i < line.Length; i += 2) // проходимся по каждому второму символу в одной строке мира
//        {
//            result[x, y] = StringToWorldObject(line[i].ToString());
//            y++;
//        }
//        y = 0;
//    }
//    return result;
//}

//WorldObjects StringToWorldObject(string baseString)
//{
//    switch (baseString)
//    {
//        case "█":
//            return WorldObjects.Wall;
//        case " ":
//            return WorldObjects.EmptySpace;
//        case "▓":
//            return WorldObjects.Character;
//        case "0":
//            return WorldObjects.Crystall;
//        default:
//            throw new NotImplementedException("Add new case to the switch");
//    }
//}