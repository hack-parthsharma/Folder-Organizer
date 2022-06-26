using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FolderOrganizer.Core
{
    public class FolderClassificationJson
    {
        public List<FolderClassification> FolderClassifications { get; set; }
    }
    public class FolderClassification
    {
        public string ClassificationName { get; set; }
        public string[] FileExtensions { get; set; }

        public string TargetPath { get; set; }

        public string GetSubFolderName()
        {
            if (String.IsNullOrEmpty(TargetPath))
            {
                return ClassificationName;
            }

            return TargetPath;
        }
    }
}
