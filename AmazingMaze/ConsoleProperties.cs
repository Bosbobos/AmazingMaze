using System;
using System.Runtime.InteropServices;

public static class ConsoleProperties
 {
    private const int FixedWidthTrueType = 54;
    private const int StandardOutputHandle = -11;

    [DllImport("kernel32.dll", SetLastError = true)]
    internal static extern IntPtr GetStdHandle(int nStdHandle);

    [return: MarshalAs(UnmanagedType.Bool)]
    [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    internal static extern bool SetCurrentConsoleFontEx(IntPtr hConsoleOutput, bool MaximumWindow, ref FontInfo ConsoleCurrentFontEx);

    [return: MarshalAs(UnmanagedType.Bool)]
    [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    internal static extern bool GetCurrentConsoleFontEx(IntPtr hConsoleOutput, bool MaximumWindow, ref FontInfo ConsoleCurrentFontEx);


    private static readonly IntPtr ConsoleOutputHandle = GetStdHandle(StandardOutputHandle);

    public static void ApplyWindowSizeProperties(int worldSize)
    {
        var neededWidth = worldSize * 2 + 2;
        var neededHeight = worldSize + 5;

        for (short fontSize = 50; fontSize >= 0; fontSize--)
        {
            SetCurrentFont(fontSize);
            if (Console.LargestWindowWidth >= neededWidth && Console.LargestWindowHeight >= neededHeight) // меняем размер экрана, получаем новый максимальный размер экрана и сравниваем его с необходимым
            {
                break;
            }
        }

        Console.SetWindowSize(neededWidth, // магическое число 2 - ширина одного спрайта в символах
                              neededHeight); // магическое число 5 - дополнительные строчки помимо игрового поля т.к. надо также вместить очки на экран
    }

    public static void ApplyWorldRenderProperties()
    {
        Console.CursorVisible = false; // убираем курсор
        Console.SetCursorPosition(0, 0); // устанавливаем позицию, чтобы переписывать с самого начала
    }


    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FontInfo
    {
        internal int cbSize;
        internal int FontIndex;
        internal short FontWidth;
        public short FontSize;
        public int FontFamily;
        public int FontWeight;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string FontName;
    }


    private static FontInfo[] SetCurrentFont(short fontSize = 0)
    {
        FontInfo before = new FontInfo
        {
            cbSize = Marshal.SizeOf<FontInfo>()
        };

        if (GetCurrentConsoleFontEx(ConsoleOutputHandle, false, ref before))
        {
            FontInfo set = new FontInfo
            {
                cbSize = Marshal.SizeOf<FontInfo>(),
                FontFamily = FixedWidthTrueType,
                FontSize = fontSize > 0 ? fontSize : before.FontSize
            };

            // Get some settings from current font.
            if (!SetCurrentConsoleFontEx(ConsoleOutputHandle, false, ref set))
            {
                var ex = Marshal.GetLastWin32Error();
                Console.WriteLine("Set error " + ex);
                throw new System.ComponentModel.Win32Exception(ex);
            }

            FontInfo after = new FontInfo
            {
                cbSize = Marshal.SizeOf<FontInfo>()
            };
            GetCurrentConsoleFontEx(ConsoleOutputHandle, false, ref after);

            return new[] { before, set, after };
        }
        else
        {
            var er = Marshal.GetLastWin32Error();
            Console.WriteLine("Get error " + er);
            throw new System.ComponentModel.Win32Exception(er);
        }
    }
 }
