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

public class MyFirstDesignTimeNetlogic : BaseNetLogic
{
    [ExportMethod]
    public void Method1()
    {
        Log.Info("Hello from Method1!");
    }

    [ExportMethod]
    public void GenerateVariables(){
        var modelFolder = Project.Current.Get<Folder>("Model");

        if (modelFolder.Get<Folder>("MyFolder") != null)
        {
            Log.Info("MyFolder already exists, skipping creation.");
            return;
        }

        var myFolder = InformationModel.Make<Folder>("MyFolder");
        for (int i = 0; i < 100; i++)
        {
            var myVar = InformationModel.MakeVariable("myVar" + i, OpcUa.DataTypes.Int32);
            myFolder.Add(myVar);
        }

        modelFolder.Add(myFolder);
    }

}
