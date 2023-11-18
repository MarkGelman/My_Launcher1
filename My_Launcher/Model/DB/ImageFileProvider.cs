using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Launcher.Model.DB
{
    internal class ImageFileProvider
    {
        public IEnumerable<string> GetImageFilesPaths(string directotyToImageFiles)
        {
            try
            {
                if (Directory.Exists(directotyToImageFiles)) { }
                return Directory.GetFiles(directotyToImageFiles, "*.png");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Enumerable.Empty<string>();

        }
    }
}
