using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FolderOrganizer.Core
{
    public class DefaultFolderClassification
    {
        public static List<FolderClassification> GetDefaults()
        {
            string json;
            try
            {
                json = File.ReadAllText("DefaultFolderClassification.json");
            }
            catch (Exception e)
            {
                throw new FileNotFoundException("DefaultFolderClassification.json not found");
            }           

            var classificationsParsed = JsonConvert.DeserializeObject<FolderClassificationJson>(json);

            var classifications = new List<FolderClassification>();           

            return classificationsParsed.FolderClassifications;
        }

        protected static FolderClassification CreateClassification(string classificationName, string[] extensions)
        {
            return new FolderClassification
            {
                ClassificationName = classificationName,
                FileExtensions = extensions
            };
        }
    }
}
