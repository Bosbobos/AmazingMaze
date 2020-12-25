/*
 * спрайты: █ ▓ 00
 * 
 * задачи:
 *    красивый редактор уровней
 *    красивенькие спрайтики
*/

using System;

// переменная, в которой лежит мир
const int worldSize = 3;
WorldObjects[,] world = new WorldObjects[worldSize, worldSize];

// переменная, в которой лежат очки персонажа
int points = 0; 

// функция отрисовки мира
void renderView()
{
    string pointsView = $"Очки: {points}" + Environment.NewLine;
    Console.WriteLine(pointsView);
    
    string worldView = worldToString(world);
    Console.WriteLine(worldView);

}

string worldToString(WorldObjects[,] worldObjects)
{
    string result = "";

    for (int j = 0; j < worldSize; j++)
    {
        for (int i = 0; i < worldSize; i++)
        {
            result += worldObjectToString(worldObjects[j, i]);
        }
        result += Environment.NewLine;
    }

    return result;
}

string worldObjectToString(WorldObjects worldObjects)
{
    switch (worldObjects)
    {
        case WorldObjects.Wall:
            return "██";
        case WorldObjects.EmptySpace:
            return "  ";
        case WorldObjects.Character:
            return "▓▓";
        case WorldObjects.Crystall:
            return "00";
        default:
            throw new NotImplementedException("Add new case to the switch");
    }
}

// функция логики игры
void gameLogic(ConsoleKey key)
{
    switch (key)
    {
        case ConsoleKey.RightArrow:
            break;
        case ConsoleKey.LeftArrow:
            break;
        case ConsoleKey.UpArrow:
            break;
        case ConsoleKey.DownArrow:
            break;
        default:
            break;
    }
}

//      определение нажатой клавиши(switch)
//      проверка столкновения с бонусом

renderView();

// функция перехвата нажатия клавиш
var key = Console.ReadKey();

gameLogic(key.Key);