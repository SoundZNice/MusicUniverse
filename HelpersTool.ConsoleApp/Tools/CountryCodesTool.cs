using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HelpersTool.ConsoleApp.Tools
{
    class CountryCodesTool : ToolBase
    {
        private readonly string _inFileName;
        private readonly string _outFileName;

        public CountryCodesTool(string @in, string @out, Action<string> log) : base(log, nameof(CountryCodesTool))
        {
            _inFileName = @in;
            _outFileName = @out;
        }

        protected override void RunInternal()
        {
            string content;

            using (var sr = new StreamReader(_inFileName))
            {
                content = sr.ReadToEnd();
            }

            var countries = JsonConvert.DeserializeObject<CountryCode[]>(content);

            int i = 1;
            string outputContent = string.Empty;

            foreach (var country in countries)
            {
                outputContent += $"new Country() {{ Id = {i++},Code = \"{country.Code}\", Name = \"{country.Name}\"}},\n";
            }

            using (var sw = new StreamWriter(_outFileName))
            {
                sw.Write(outputContent);
            }
        }

        class CountryCode
        {
            public string Code { get; set; }
            public string Name { get; set; }
        }
    }
}
