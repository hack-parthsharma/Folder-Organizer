using System;
using System.Collections.Generic;
using System.Text;

namespace FolderOrganizer.Core.Exceptions
{
    public class FolderNotFoundException : Exception
    {
        public FolderNotFoundException()
        {

        }
        public FolderNotFoundException(string folderName) : base($"{folderName} is not found.")
        {
        }
    }
}
