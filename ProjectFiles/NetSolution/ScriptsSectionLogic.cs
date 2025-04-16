#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.UI;
using FTOptix.HMIProject;
using FTOptix.SQLiteStore;
using FTOptix.WebUI;
using FTOptix.CoreBase;
using FTOptix.DataLogger;
using FTOptix.Store;
using FTOptix.Retentivity;
using FTOptix.NetLogic;
using FTOptix.Core;
using FTOptix.System;
#endregion

public class ScriptsSectionLogic : BaseNetLogic
{
    private PeriodicTask pTask;

    public override void Start()
    {
        Log.Info("ScriptsSectionLogic started");
    }

    public override void Stop()
    {
        pTask?.Dispose();
        Log.Info("ScriptsSectionLogic stopped");
    }

    [ExportMethod]
    public void TestPeriodicTask(){
        pTask = new PeriodicTask(LogSomething, 1000, LogicObject);
        pTask.Start();
    }

    [ExportMethod]
    public void StopPeriodicTask(){
        Log.Info("Stopping periodic task...");
        pTask?.Dispose();
    }

    private void LogSomething()
    {
        Log.Info("Hello from periodic task!");
    }
}
