using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FolderOrganizer.Core
{
    public class FolderArrangement
    {
        public FolderClassification FolderClassification { get; set; }
        public FileInfo[] FilesInFolder { get; set; }
        public DirectoryInfo TargetDirectory { get; set; }

        public DirectoryInfo RootDirectory { get; set; }
        public FolderArrangement(FolderClassification folderClassification)
        {
            FolderClassification = folderClassification;
        }

        public void LoadFiles(FileInfo[] filesInfo)
        {
            FilesInFolder = filesInfo.Where(x => FolderClassification.FileExtensions.Any(y => y == x.Extension)).ToArray();
        }

        public bool CreateTargetDirectory(DirectoryInfo rootDirectory)
        {
            string targetDirectory = Path.Combine(rootDirectory.FullName, FolderClassification.GetSubFolderName());
            if (!Directory.Exists(targetDirectory))
            {
                Directory.CreateDirectory(targetDirectory);                
            }

            TargetDirectory = new DirectoryInfo(targetDirectory);

            return true;
        }

        public bool HasAnyFilesToOrganize()
        {
            if (FilesInFolder != null && FilesInFolder.Length > 0) return true;

            return false;
        }

        public void MoveFilesToTargetDirectory()
        {
            if (TargetDirectory is null) return;
            if (FilesInFolder is null || FilesInFolder.Length == 0) return;

            foreach (var fileInFolder in FilesInFolder)
            {
                string sourceFileName = fileInFolder.FullName;
                string targetFileName = Path.Combine(TargetDirectory.FullName, fileInFolder.Name);
                File.Move(sourceFileName, targetFileName);
            }
        }
    }
}
