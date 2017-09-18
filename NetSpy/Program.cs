﻿using System;
using CommandLine;
using ICSharpCode.Decompiler;

namespace NetSpy
{
    internal class Program
    {
        private static int Main(string[] args)
        {
            var output = new PlainTextOutput(Console.Out);
            int res;
            using (var parser = Parser.Default)
            {
                res = parser.ParseArguments<WringOptions>(args).MapResult(
                    opts => Wringer.Disassemble(output, opts),
                    errs => 1);
            }
            return res;
        }
    }
}