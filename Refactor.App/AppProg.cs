using CommandDotNet;
using CommandDotNet.Repl;
using CommandDotNet.Unity.Helper;
using Config.Wrapper;
using Serilog;

namespace Refactor.App;

public class AppProg 
    : AppProgUnity<AppProg>
{
	private static bool inSession;

    [Subcommand]
    public AppCommands? AppCommands { get; set; }

    public AppProg(
        ILogger log
        , IConfigReader config) 
            : base(log, config)
    {
    }

    [DefaultCommand()]
    public void StartSession(
        CommandContext context,
        ReplSession replSession)
    {
        if (inSession == false)
        {
            context.Console.WriteLine("start session");
            inSession = true;
            replSession.Start();
        }
        else
        {
            context.Console.WriteLine($"no session {inSession}");
            context.ShowHelpOnExit = true;
        }
    }
}