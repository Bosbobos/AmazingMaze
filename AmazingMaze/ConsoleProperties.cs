using System;
using System.Runtime.InteropServices;

public static class ConsoleProperties
 {
    const int STD_OUT_HANDLE = -11;


    [DllImport("kernel32.dll", SetLastError = true)]
    static extern int SetConsoleFont( // Функция не документирована
            IntPtr hOut,    // handle полученный от GetStdHandle
            uint dwFontNum  // Значение должно быть от 0 до 9
            );


    [DllImport("kernel32.dll", SetLastError = true)]
    static extern IntPtr GetStdHandle(int dwType);


    public static void Apply()
    {
        Console.SetWindowSize(200, 50);
        SetConsoleFont(GetStdHandle(STD_OUT_HANDLE), 1); // меняем размер шрифта
        Console.CursorVisible = false; // убираем курсор
        Console.SetCursorPosition(0, 0); // устанавливаем позицию, чтобы переписывать с самого начала
    }
 }
