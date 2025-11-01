using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
namespace MidtermProject;

internal static class Program
{
    static void Main(string[] args)
    {
        var gws = GameWindowSettings.Default;
        var nws = new NativeWindowSettings
        {
            Title = "Space Pod: Solar System",
            ClientSize = new Vector2i(1280, 720),
            APIVersion = new System.Version(3, 3)
        };

        using var game = new SpacePodGame(gws, nws);
        game.Run();
    }
}
