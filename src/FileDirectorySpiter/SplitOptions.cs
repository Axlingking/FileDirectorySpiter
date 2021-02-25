using System;
using System.Collections.Generic;
using System.Text;

namespace FileDirectorySpliter
{
    class SplitOptions
    {
        /// <summary>
        /// 每个包内的文件数量
        /// </summary>
        public int Size { get; set; } = 100;

        /// <summary>
        /// 需要拆分的目录路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 拆分后的目录命名前缀
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// 命名起始编号
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// 指定重名文件是否覆盖
        /// </summary>
        public bool Overwrite { get; set; }
    }
}
