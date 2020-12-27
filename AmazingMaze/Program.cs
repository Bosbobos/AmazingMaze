﻿/*
 * спрайты: █ ▓ 00
 * 
 * задачи:
 *    красивый редактор уровней
 *    красивенькие спрайтики
*/


using System;


#region Инициализация мира

const int worldSize = 4;
WorldObjects[,] world = new WorldObjects[worldSize, worldSize]; // переменная, в которой лежит мир
world[1, 1] = WorldObjects.Character;
world[2, 1] = WorldObjects.EmptySpace;
world[2, 2] = WorldObjects.EmptySpace;

int points = 0; // переменная, в которой лежат очки персонажа

#endregion Инициализация мира


#region Функция отрисовки мира

void renderView()
{
    Console.Clear();

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
            result += worldObjectToString(worldObjects[i, j]);
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

#endregion Функция отрисовки мира


#region Функция логики игры

//      проверка столкновения с бонусом

Coordinates getPosOf(WorldObjects obj) // Возвращает позицию первого такого объекта на карте
{
    for (int j = 0; j < worldSize; j++)
    {
        for (int i = 0; i < worldSize; i++)
        {
            if (world[j, i] == obj)
            {
                return new Coordinates() { x = j, y = i };
            }
        }
    }

    throw new Exception($"Объекта {obj} на карте нет!");
}

WorldObjects getObjectByCoordinates(Coordinates coord)
{
    return world[coord.x, coord.y];
}

Coordinates getDestinationPos(ConsoleKey key, Coordinates basePos)
{
    int speed = 1;
    switch (key)
    {
        case ConsoleKey.RightArrow: return new Coordinates() { x = basePos.x + speed, y = basePos.y };
        case ConsoleKey.LeftArrow: return new Coordinates() { x = basePos.x - speed, y = basePos.y };
        case ConsoleKey.UpArrow: return new Coordinates() { x = basePos.x, y = basePos.y + speed };
        case ConsoleKey.DownArrow:  return new Coordinates() { x = basePos.x, y = basePos.y - speed };
        default: throw new ArgumentException("Можно нажимать только на стрелочки!");
    }
}

void move(WorldObjects mover ,Coordinates basePos, Coordinates destinationPos)
{
    world[destinationPos.x, destinationPos.y] = mover; // На месте назначения появляется персонаж
    world[basePos.x, basePos.y] = WorldObjects.EmptySpace; // На месте назначения появляется пустота
}

void gameLogic(ConsoleKey key)
{
    var characterPos = getPosOf(WorldObjects.Character);
    var destinationPos = getDestinationPos(key, characterPos);
    var bumpObject = getObjectByCoordinates(destinationPos);
    // Проверяем столкновение
    switch (bumpObject)
    {
        case WorldObjects.Wall: break; // Ничего не происходит
        case WorldObjects.EmptySpace:
            move(WorldObjects.Character, characterPos, destinationPos);
            break;
        case WorldObjects.Character: throw new Exception("Персонаж должен быть один!");
        case WorldObjects.Crystall:
            move(WorldObjects.Character, characterPos, destinationPos);
            points++;
            break;
        default:
            throw new NotImplementedException("Допишите switch!");
    }           
}

#endregion Функция логики игры


#region Стартуем

renderView();

while(true)
{
    var key = Console.ReadKey();
    gameLogic(key.Key);
    renderView();
}


#endregion Стартуем