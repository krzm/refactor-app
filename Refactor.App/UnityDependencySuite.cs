using CommandDotNet.Unity.Helper;
using Config.Wrapper.Unity;
using Serilog.Wrapper.Unity;
using Unity;

namespace Refactor.App;

public class UnityDependencySuite 
    : DIHelper.Unity.UnityDependencySuite
{
    public UnityDependencySuite(
        IUnityContainer container) 
        : base(container) 
    {
    }

    protected override void RegisterAppData()
    {
        RegisterSet<AppLoggerSet>();
        RegisterSet<AppConfigSet>();
    }
    
    protected override void RegisterCommands() => 
        RegisterSet<AppCommandSet>();

    protected override void RegisterProgram() => 
        RegisterSet<AppProgSet<AppProg>>();
}