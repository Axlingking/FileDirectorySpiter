using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace FileDirectorySpiter
{
    class Spiter
    {
        public SpitOptions Options { get; private set; }

        private int number = 1;

        public void Spit(SpitOptions options)
        {
            this.Options = options;

            var files = Directory.GetFiles(options.Path, "*.*", SearchOption.TopDirectoryOnly);
            if (!files.Any())
            {
                return;
            }

            int total = files.Length;
            int size = options.Size;
            int step = 0;
            while (step < total)
            {
                var _files = files.Skip(step).Take(size);

                this.Move(_files, NextPackageName(options), options.Overwrite);

                step += _files.Count();
            }
        }

        void Move(IEnumerable<string> files, string package, bool overwrite)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Create Package {package}");
            Console.ResetColor();

            if (!Directory.Exists(package)) Directory.CreateDirectory(package);

            foreach (var file in files)
            {
                Console.WriteLine($"Move File {file}");

                // 重名文件处理
                int index = 1;
                string dest = Path.Combine(package, Path.GetFileName(file));
                while (File.Exists(dest) && !overwrite)
                {
                    dest = Path.Combine(package, $"{Path.GetFileNameWithoutExtension(file)}({index++}){Path.GetExtension(file)}");
                }

                if (overwrite && File.Exists(dest))
                {
                    File.Delete(dest);
                }

                File.Move(file, dest);
            }
        }

        string NextPackageName(SpitOptions options)
        {
            string package;

            do
            {
                package = Path.Combine(options.Path, $"{(string.IsNullOrWhiteSpace(options.Prefix) ? Path.GetFileName(options.Path) : options.Prefix)}{number++}");
            }
            while (this.IsFullPackage(package, options.Size));

            return package;
        }

        bool IsFullPackage(string package, int size)
        {
            if (!Directory.Exists(package)) return false;

            return Directory.GetFiles(package, "*.*", SearchOption.TopDirectoryOnly).Length >= size;
        }
    }
}
