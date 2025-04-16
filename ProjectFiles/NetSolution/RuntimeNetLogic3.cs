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

public class RuntimeNetLogic3 : BaseNetLogic
{
    public override void Start()
    {
        // Insert code to be executed when the user-defined logic is started
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
    }

    [ExportMethod]
    public void DeleteRectangle(NodeId rectangleToDelete)
    {
        InformationModel.Get(rectangleToDelete).Delete();
    }
}
