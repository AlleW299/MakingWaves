using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakingWavesCodeTest.Entitiy
{
    public class DataPage
    {
        public int Page { get; set; }
        public int Per_Page { get; set; }
        public int Total { get; set; }
        public int Total_Pages { get; set; }

        public List<Data> Data { get; set; }
    }

    public class Data
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public string Pantone_Value { get; set; }
    }
}
