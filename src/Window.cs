using Silk.NET.GLFW;

using Silk.NET.OpenGL;

namespace Base.Engine;

public static class Window
{
    private static Glfw glfw;
    private static unsafe WindowHandle* window;
    private static string _title = "";


    static Window()
    {
        glfw = Glfw.GetApi();

        // 初始化 GLFW
        if (!glfw.Init())
        {
            throw new InvalidOperationException("Failed to initialize GLFW!");
        }
    }


    public static unsafe int Width
    {
        get
        {
            if (window is null)
                throw new InvalidOperationException("Winodw is not created yet");

            glfw.GetWindowSize(window, out int width, out _);
            return width;
        }
    }

    public static unsafe int Height
    {
        get
        {
            if (window is null)
                throw new InvalidOperationException("Winodw is not created yet");

            glfw.GetWindowSize(window, out int _, out int height);
            return height;
        }
    }

    public static unsafe string Title
    {
        get
        {
            if (window is null)
                throw new InvalidOperationException("Winodw is not created yet");

            return _title;
        }

        set
        {
            if (window is null)
                throw new InvalidOperationException("Winodw is not created yet");

            glfw.SetWindowTitle(window, value);
        }
    }

    public static unsafe void Create(int width, int height, string title)
    {
        _title = title;

        // 配置 GLFW
        glfw.WindowHint(WindowHintInt.ContextVersionMajor, 3);
        glfw.WindowHint(WindowHintInt.ContextVersionMinor, 3);
        glfw.WindowHint(WindowHintOpenGlProfile.OpenGlProfile, OpenGlProfile.Core);

        window = glfw.CreateWindow(width, height, title, null, null);

        if (window is null)
        {
            glfw.Terminate();
            throw new InvalidOperationException("Failed to create a GLFW window!");
        }

        glfw.SwapInterval(1);
    }

    public static unsafe void Update()
    {
        glfw.PollEvents();
    }

    public static unsafe void Render()
    {
        glfw.SwapBuffers(window);
    }

    public static unsafe bool ShouldClose()
    {
        return glfw.WindowShouldClose(window);
    }

    public static void Terminate()
    {
        glfw.Terminate();
    }

    public static unsafe bool GetKey(Keys keyCode)
    {
        return glfw.GetKey(window, keyCode) == (int)InputAction.Press;
    }

    public static unsafe bool GetMouseButton(int mouseButton)
    {
        return glfw.GetMouseButton(window, mouseButton) == (int)InputAction.Press;
    }

    public static unsafe Vector2 GetMousePosition()
    {
        glfw.GetCursorPos(window, out double x, out double y);
        return new Vector2((float)x, (float)y);
    }


}