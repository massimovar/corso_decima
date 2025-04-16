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

public class MachineImporter : BaseNetLogic
{
    public override void Start()
    {
        // InstantiateMachines();
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
    }

    [ExportMethod]
    public void InstantiateMachines()
    {
        var csvSeparator = ";";
        var machinesToInstatiate = (int)LogicObject.GetVariable("MachinesToInstatiate").Value;
        var importedMachinesFolder = Project.Current.Get<Folder>("Model/ImportedMachines");

        var csvPath = LogicObject.GetVariable("CsvPath").Value;
        var csvUri = new ResourceUri(csvPath).Uri;

        using (var reader = new System.IO.StreamReader(csvUri))
        {
            // Read header line
            var headerLine = reader.ReadLine();

            int instantiatedCount = 0;
            while (!reader.EndOfStream && instantiatedCount < machinesToInstatiate)
            {
                var line = reader.ReadLine();
                var values = line.Split(csvSeparator);

                // Assuming the CSV structure is always consistent and complete
                var machineName = values[0];
                var machineNumber = ushort.Parse(values[1]);
                var cognome = values[2];
                var quota = ushort.Parse(values[3]);

                // Create a new Machine object
                var machine = InformationModel.Make<Machine>(machineName);

                // Populate Machine properties
                machine.MachineNumber = machineNumber;
                machine.Cognome = cognome;
                machine.Quota = quota;

                importedMachinesFolder.Add(machine);

                instantiatedCount++;
            }
        }
    }
}
