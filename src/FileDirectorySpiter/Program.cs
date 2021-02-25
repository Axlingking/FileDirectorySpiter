using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace FileDirectorySpiter
{
    class Program
    {
        static int Main(string[] args)
        {
            //var rootCommand = new RootCommand("文件批量目录拆分工具 作者:曾子凌")
            //{
            //    new Argument<string>("path","指定拆分的目录路径"),
            //    new Option<int>(new string[]{ "--size", "-s"},()=>100, "每个包内的文件数量"),
            //    new Option<string>(new string[]{ "--prefix", "-p"},"拆分后的目录命名前缀"),
            //    new Option<int>(new string[]{ "--number", "-n"},()=>1,"命名起始编号"),
            //    new Option<bool>(new string[]{ "--overwrite", "-o"},()=>false,"指定重名文件是否覆盖")
            //};

            //rootCommand.Handler = CommandHandler.Create<SpitOptions>((options) =>
            //{
            //    new Spiter().Spit(options);
            //});

            //return rootCommand.Invoke(args);

            #region DEBUG

            new Spiter().Spit(new SpitOptions
            {
                Path = @"C:\Users\Administrator\Desktop\test",
                Number = 7,
                Overwrite = false
            });
            return 1;

            #endregion
        }
    }
}
