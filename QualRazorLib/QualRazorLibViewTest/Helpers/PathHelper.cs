using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorLibViewTest.Helpers
{
    public static class PathHelper
    {
        public static string? CreateExcecutePathToFile(string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly().Location;
            var dir=System.IO.Path.GetDirectoryName(assembly);
            if(dir is (null or ""))
            {
                return null;
            }
            var path=System.IO.Path.Combine(dir, fileName);
            return System.IO.File.Exists(path) ? path : null;
        }
    }
}
