﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PhotoStructurizationUtility.Kernel.Extentions
{
    public static class Extentions
    {
        public static IEnumerable<FileInfo> GetFilesByExtensions(this DirectoryInfo dir, params string[] extensions)
        {
            if (extensions == null)
                throw new ArgumentNullException("extensions");
            IEnumerable<FileInfo> files = dir.EnumerateFiles();
            return files.Where(f => extensions.Contains(f.Extension));
        }
    }
}
