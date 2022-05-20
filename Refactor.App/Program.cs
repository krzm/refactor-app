using DIHelper;
using Refactor.App;
using Unity;

IBootstraper booter = new Bootstraper(
    new UnityDependencySuite(
        new UnityContainer().AddExtension(new Diagnostic())));
booter.Boot(args);