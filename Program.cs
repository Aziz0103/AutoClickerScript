using System.Runtime.InteropServices;


[DllImport("user32.dll")]
static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, IntPtr dwExtraInfo);

[DllImport("user32.dll")]

static extern short GetAsyncKeyState(int vKey);

// class variables
const uint LEFTDOWN = 0x02;
const uint LEFTUP = 0x04;
const int HOTKEY = 0x26; // Arrow upKey

bool enableCLicker = false;
int clickInterval = 24;

while (true)
{
    if (GetAsyncKeyState(HOTKEY) < 0)
    {
        enableCLicker = !enableCLicker;
        Thread.Sleep(300);
    }
    if (enableCLicker)
    {
        MouseClick();
    }
    Thread.Sleep(clickInterval);//click interval 
}


void MouseClick()
{
    mouse_event(LEFTDOWN, 0, 0, 0, IntPtr.Zero);
    mouse_event(LEFTUP, 0, 0, 0, IntPtr.Zero);
}