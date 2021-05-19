public static class MapHolder
{
    public static WorldObjects[,] GetMap()
    {
        var A = WorldObjects.Character;
        var e = WorldObjects.EmptySpace;
        var c = WorldObjects.Crystall;
        var w = WorldObjects.Wall;
        var z = WorldObjects.Exit;

        const int worldSize = 25;
        return new WorldObjects[worldSize, worldSize] // переменная, в которой лежит мир
        {
            {   w ,w ,w ,w ,w ,w ,w ,w ,w ,w ,w ,w ,w ,w ,w ,w ,w ,w ,w ,w ,w ,w ,w ,w ,w   },
            {   w ,A ,e ,e ,e ,e ,e ,e ,e ,w ,e ,e ,e ,e ,e ,e ,e ,e ,e ,e ,e ,e ,e ,e ,w   },
            {   w ,e ,w ,w ,w ,w ,w ,w ,e ,w ,e ,w ,w ,w ,w ,e ,w ,w ,w ,w ,e ,w ,w ,w ,w   },
            {   w ,e ,e ,e ,e ,w ,e ,e ,e ,w ,e ,w ,e ,e ,w ,e ,w ,c ,c ,w ,e ,w ,c ,c ,w   },
            {   w ,e ,w ,e ,e ,w ,e ,w ,e ,w ,e ,w ,e ,e ,w ,e ,w ,c ,c ,w ,e ,w ,c ,c ,w   },
            {   w ,e ,w ,e ,e ,w ,e ,w ,e ,w ,e ,w ,e ,e ,w ,e ,w ,c ,c ,w ,e ,w ,c ,c ,w   },
            {   w ,e ,w ,e ,e ,w ,e ,w ,e ,w ,e ,w ,e ,e ,w ,e ,w ,e ,e ,e ,e ,w ,e ,e ,w   },
            {   w ,e ,w ,e ,e ,w ,e ,w ,e ,w ,e ,w ,e ,e ,w ,e ,w ,e ,e ,w ,e ,w ,e ,e ,w   },
            {   w ,e ,w ,e ,e ,w ,e ,w ,e ,w ,e ,w ,e ,e ,w ,e ,w ,e ,e ,w ,e ,w ,e ,e ,w   },
            {   w ,e ,w ,c ,c ,w ,e ,w ,e ,w ,e ,w ,e ,e ,w ,e ,w ,e ,e ,w ,e ,w ,e ,e ,w   },
            {   w ,e ,w ,c ,c ,w ,e ,w ,e ,w ,e ,w ,e ,e ,w ,e ,w ,e ,e ,w ,e ,w ,e ,w ,w   },
            {   w ,e ,w ,c ,c ,w ,e ,w ,e ,w ,e ,w ,e ,e ,w ,e ,w ,c ,c ,w ,e ,e ,e ,e ,w   },
            {   w ,e ,w ,w ,w ,w ,e ,w ,e ,w ,e ,w ,e ,e ,w ,e ,w ,c ,c ,w ,e ,w ,e ,e ,w   },
            {   w ,e ,w ,e ,e ,e ,e ,w ,e ,w ,e ,w ,e ,e ,w ,e ,w ,c ,c ,w ,e ,w ,e ,e ,w   },
            {   w ,e ,w ,w ,w ,w ,w ,w ,e ,w ,e ,w ,e ,e ,w ,e ,w ,w ,w ,w ,w ,w ,w ,e ,w   },
            {   w ,e ,w ,e ,e ,e ,e ,e ,e ,e ,e ,w ,e ,e ,w ,e ,e ,e ,e ,e ,e ,e ,w ,e ,w   },
            {   w ,e ,w ,w ,w ,w ,w ,w ,w ,w ,w ,w ,e ,e ,w ,w ,w ,w ,w ,w ,e ,w ,w ,e ,w   },
            {   w ,e ,w ,e ,e ,e ,e ,e ,e ,e ,e ,e ,e ,e ,w ,e ,e ,e ,e ,e ,e ,e ,w ,e ,w   },
            {   w ,e ,w ,e ,w ,w ,w ,w ,w ,w ,w ,w ,w ,w ,w ,e ,e ,e ,e ,e ,e ,e ,w ,e ,w   },
            {   w ,e ,e ,e ,e ,e ,e ,e ,e ,e ,e ,e ,e ,e ,w ,e ,w ,w ,w ,w ,w ,w ,w ,e ,w   },
            {   w ,w ,w ,w ,w ,w ,w ,w ,w ,w ,e ,e ,e ,e ,w ,e ,e ,e ,e ,e ,e ,e ,w ,e ,w   },
            {   w ,w ,w ,e ,e ,e ,e ,e ,e ,e ,e ,e ,e ,e ,w ,e ,e ,e ,e ,e ,e ,e ,w ,e ,w   },
            {   w ,w ,w ,e ,w ,w ,w ,w ,w ,w ,w ,w ,w ,w ,w ,w ,w ,w ,w ,w ,w ,e ,w ,e ,w   },
            {   w ,w ,w ,e ,e ,e ,e ,e ,e ,e ,e ,e ,e ,e ,e ,e ,e ,e ,e ,e ,e ,e ,w ,z ,w   },
            {   w ,w ,w ,w ,w ,w ,w ,w ,w ,w ,w ,w ,w ,w ,w ,w ,w ,w ,w ,w ,w ,w ,w ,w ,w   },
        };
    }
}
