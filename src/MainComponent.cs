
namespace Base.Engine;

public class MainComponent
{
    private bool IsRunning;
    private IGame game;

    public static readonly double RenderFrameLimit = 5000.0;
    private static readonly double renderFrameTime = 1.0 / RenderFrameLimit;

    public MainComponent(IGame _game)
    {
        IsRunning = false;
        game = _game;
    }

    public void Start()
    {
        if (IsRunning)
            return;

        Run();
    }

    public void Stop()
    {
        if (!IsRunning)
            return;

        IsRunning = false;
    }

    // Game Engine Main Loop
    private void Run()
    {
        IsRunning = true;

        int fps = 0;
        int fpsCounter = 0;

        bool shouldRender;

        double lastTime = Time.GetTime();
        double startTime;
        double passedTime;
        double accumulatedTime = 0;

        Ready();

        while (IsRunning)
        {
            shouldRender = false;

            startTime = Time.GetTime();
            passedTime = startTime - lastTime;
            lastTime = startTime;

            // in second
            accumulatedTime += passedTime / Time.Second;
            fpsCounter += (int)passedTime;

            while (accumulatedTime > renderFrameTime)
            {
                shouldRender = true;
                accumulatedTime -= renderFrameTime;

                if (Window.ShouldClose())
                    Stop();

                Time.Delta = renderFrameTime;

                //TODO: Engine and Game's Update
                Update();

                if (fpsCounter >= Time.Second)
                {
                    Console.WriteLine(fps);
                    // Window.Title += " FPS:" + fps.ToString();
                    fps = 0;
                    fpsCounter = 0;
                }
            }

            if (shouldRender)
            {
                Render();
                fps++;
            }
            else
            {
                Thread.Sleep(1);
            }
        }

        CleanUp();
    }

    private void Ready()
    {
        game.Ready();
    }

    private void Update()
    {
        // Engine
        Window.Update();
        Input.Update();

        // Game
        game.ProcessInput();
        game.Update();
    }

    private void Render()
    {
        game.Render();
        Window.Render();
    }

    private void CleanUp()
    {
        Window.Terminate();
    }

    public static void Main(string[] args)
    {
        Window.Create(800, 600, "3D Game Engine");

        MainComponent game = new MainComponent(new Game());

        game.Start();
    }
}