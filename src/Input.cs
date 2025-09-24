using Silk.NET.GLFW;

namespace Base.Engine;

public static class Input
{
    private static List<Keys> lastKeys = new List<Keys>();
    private static List<Keys> currentDownKeys = new List<Keys>();
    private static List<Keys> currentUpKeys = new List<Keys>();

    private static List<MouseButton> lastMouse = new List<MouseButton>();
    private static List<MouseButton> currentDownMouse = new List<MouseButton>();
    private static List<MouseButton> currentUpMouse = new List<MouseButton>();

    public static void Update()
    {
        currentUpKeys.Clear();
        foreach (Keys keyCode in Enum.GetValues(typeof(Keys)))
        {
            // 当前帧未按下且上一帧按下
            if (!GetKey(keyCode) && lastKeys.Contains(keyCode))
            {
                currentUpKeys.Add(keyCode);
            }
        }

        currentDownKeys.Clear();
        foreach (Keys keyCode in Enum.GetValues(typeof(Keys)))
        {
            // 当前帧按下且上一帧未按下
            if (GetKey(keyCode) && !lastKeys.Contains(keyCode))
            {
                currentDownKeys.Add(keyCode);
            }
        }

        lastKeys.Clear();
        foreach (Keys keyCode in Enum.GetValues(typeof(Keys)))
        {
            // 当前帧按下的帧
            if (GetKey(keyCode))
            {
                lastKeys.Add(keyCode);
            }
        }


        // 鼠标同理
        currentUpMouse.Clear();
        foreach (MouseButton mb in Enum.GetValues(typeof(MouseButton)))
        {
            // 当前帧未按下且上一帧按下
            if (!GetMouseButton(mb) && lastMouse.Contains(mb))
            {
                currentUpMouse.Add(mb);
            }
        }

        currentDownMouse.Clear();
        foreach (MouseButton mb in Enum.GetValues(typeof(MouseButton)))
        {
            // 当前帧按下且上一帧未按下
            if (GetMouseButton(mb) && !lastMouse.Contains(mb))
            {
                currentDownMouse.Add(mb);
            }
        }

        lastMouse.Clear();
        foreach (MouseButton mb in Enum.GetValues(typeof(MouseButton)))
        {
            if (GetMouseButton(mb))
            {
                lastMouse.Add(mb);
            }
        }

    }

    public static bool GetKey(Keys keyCode)
    {
        return Window.GetKey(keyCode);
    }
    public static bool GetKey(KeyCodes keyCode)
    {
        return Window.GetKey((Keys)keyCode);
    }

    // 当前帧按下且上一帧未按下
    public static bool GetKeyDown(KeyCodes keyCode)
    {
        return currentDownKeys.Contains((Keys)keyCode);
    }

    // 当前值未按下且上一帧按下
    public static bool GetKeyUp(KeyCodes keyCode)
    {
        return currentUpKeys.Contains((Keys)keyCode);
    }

    public static bool GetMouseButton(MouseButton mouseButton)
    {
        return Window.GetMouseButton((int)mouseButton);
    }

    public static bool GetMouseButtonDown(MouseButton mouseButton)
    {
        return currentDownMouse.Contains(mouseButton);
    }

    public static bool GetMouseButtonUp(MouseButton mouseButton)
    {
        return currentUpMouse.Contains(mouseButton);
    }

    public static Vector2 GetMousePosition()
    {
        return Window.GetMousePosition();
    }
}