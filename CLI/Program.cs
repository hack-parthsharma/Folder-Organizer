using CliFx;
using CliFx.Attributes;
using FolderOrganizer.Core;
using FolderOrganizer.Core.Exceptions;
using System;
using System.Threading.Tasks;

namespace FolderOrganizer.Cli
{
    class Program
    {
        public static async Task<int> Main() => await new CliApplicationBuilder()
                                                    .AddCommandsFromThisAssembly()
                                                    .Build()
                                                    .RunAsync();
    }

    [Command]
    public class OrganizeCommand : ICommand
    {
        [CommandOption("folder", shortName:'f', 
            Description = "Files in this folder will be organized", IsRequired = true)]
        public string FolderToOrganize { get; set; }

        [CommandOption("classification", shortName: 'c',
            Description = "Specify the path to custom classification profile JSON file to organize the folder. If not specified, uses the defualt classification profile",
            IsRequired = false)]
        public string ClassificationFilePath { get; set; }
        public ValueTask ExecuteAsync(IConsole console)
        {
            var classifications = DefaultFolderClassification.GetDefaults();
            try
            {
                var organizer = new Core.FolderOrganizer(FolderToOrganize, classifications);
                organizer.LogOutput += (object sender, LogEventArgs e) =>
                {
                    console.Output.Write($"{e.Message} \n");
                };

                organizer.Organize();
            }
            catch (Exception e)
            {
                if (e is FolderNotFoundException)
                {
                    console.Error.Write("Given folder is not found. Please specify the valid folder.");
                }
            }

            return default;
        }
    }
}
