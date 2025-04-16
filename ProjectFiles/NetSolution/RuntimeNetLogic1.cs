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

public class RuntimeNetLogic1 : BaseNetLogic
{
    public override void Start()
    {
        Log.Info("App started");
    }

    public override void Stop()
    {
        Log.Info("App stopped");
    }

    [ExportMethod]
    public void Method1()
    {
        Log.Info("Hello from Method1!");
    }


}
