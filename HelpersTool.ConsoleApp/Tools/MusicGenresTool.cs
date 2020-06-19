using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HelpersTool.ConsoleApp.Tools
{
    class MusicGenresTool : ToolBase
    {
        private readonly string _in;
        private readonly string _out;

        public MusicGenresTool(string @in, string @out, Action<string> log) : base(log, nameof(MusicGenresTool))
        {
            _in = @in;
            _out = @out;
        }
        protected override void RunInternal()
        {
            string content;

            using (var sr = new StreamReader(_in))
            {
                content = sr.ReadToEnd();
            }

            content.Replace("\n", "");            
            var genres = content.Split(',');

            int i = 1;
            string outputContent = string.Empty;

            foreach (var genre in genres)
            {
                outputContent += $"new MusicGenre() {{ Id = { i++ }, Name = \"{genre}\" }},\n";
            }

            using (var sw = new StreamWriter(_out))
            {
                sw.Write(outputContent);
            }
        }
    }
}
