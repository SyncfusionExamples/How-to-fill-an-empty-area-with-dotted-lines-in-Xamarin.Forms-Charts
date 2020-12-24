using System;
using System.Collections.Generic;
using System.Text;

namespace SfChart_xamarin
{
    public class Model
    {
        public DateTime Date { get; set; }

        public double Value { get; set; }

        public Model(DateTime date, double value)
        {
            Date = date;
            Value = value;
        }
    }
}
