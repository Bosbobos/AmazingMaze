using System;


#region Инициализация мира


int points = 0; // переменная, в которой лежат очки персонажа

WorldObjects[,] world = MapHolder.GetMap();

int worldSize = world.GetLength(0); // получаем размерность многомерного массива по первому измерению


#endregion Инициализация мира


#region Функция отрисовки мира


void renderView()
{
    ConsoleProperties.ApplyWorldRenderProperties(worldSize);
    string pointsView = $"Очки: {points}" + Environment.NewLine;
    Console.WriteLine(pointsView);

    renderWorld();
}


void renderWorld()
{
    string worldView = worldToString(world);
    //    Console.WriteLine(worldView);

    for (int i = 0; i < worldView.Length; i++)
    {
        switch (worldView[i])
        {
            default:
                var c = worldView[i];
                Console.ForegroundColor = ConsoleColor.White;  // сбрасываем цвет
                break;
            case '▓':
                Console.ForegroundColor = ConsoleColor.Blue;
                break;
        }
        Console.Write(worldView[i]);
    }
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
            return "++";
        default:
            throw new NotImplementedException("Add new case to the switch");
    }
}


#endregion Функция отрисовки мира


#region Функция логики игры


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
        case ConsoleKey.RightArrow: return new Coordinates() { x = basePos.x, y = basePos.y + speed };
        case ConsoleKey.LeftArrow: return new Coordinates() { x = basePos.x, y = basePos.y - speed };
        case ConsoleKey.UpArrow: return new Coordinates() { x = basePos.x - speed, y = basePos.y };
        case ConsoleKey.DownArrow: return new Coordinates() { x = basePos.x + speed, y = basePos.y };
        default: throw new ArgumentException("Можно нажимать только на стрелочки!");
    }
}


void move(WorldObjects mover, Coordinates basePos, Coordinates destinationPos)
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

while (true)
{
    var key = Console.ReadKey();
    gameLogic(key.Key);
    renderView();
}

#endregion Стартуем