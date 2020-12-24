using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SfChart_xamarin
{
    public class ViewModel
    {
        public ObservableCollection<Model> Data { get; set; }
        public ObservableCollection<Model> Data1 { get; set; }
        public ObservableCollection<Model> LineData { get; set; }
        bool isEmpty { get; set; } = false;

        public ViewModel()
        {
            Random random = new Random();
            var date = new DateTime(2017, 5, 1);
            Data = new ObservableCollection<Model>();
            for (int i = 0; i < 14; i++)
            {
                if (i == 3 || i == 10)
                {
                    Data.Add(new Model(date, double.NaN));
                }
                else
                {
                    Data.Add(new Model(date, random.Next(20, 100)));
                }
                date = date.AddDays(1);
            }

            date = new DateTime(2017, 5, 1);
            Data1 = new ObservableCollection<Model>();
            for (int i = 0; i < 14; i++)
            {
                if (i == 3 || i == 10)
                    Data1.Add(new Model(date, double.NaN));
                else
                    Data1.Add(new Model(date, random.Next(20, 100)));

                date = date.AddDays(1);
            }

            LineData = new ObservableCollection<Model>();
            for (int i = 0; i < Data.Count; i++)
            {
                if (double.IsNaN(Data[i].Value))
                {
                    isEmpty = true;
                }
                else
                    isEmpty = false;

                if (isEmpty)
                {
                    if (!double.IsNaN(Data[i - 1].Value))
                    {
                        LineData.Add(new Model(Data[i - 1].Date, 0));
                        LineData.Add(new Model(Data[i - 1].Date, Data[i - 1].Value + Data1[i - 1].Value));
                    }

                    if (!double.IsNaN(Data1[i + 1].Value))
                    {
                        LineData.Add(new Model(Data[i + 1].Date, Data[i + 1].Value + Data1[i + 1].Value));
                        LineData.Add(new Model(Data[i + 1].Date, 0));
                        LineData.Add(new Model(Data[i + 1].Date, double.NaN));
                    }
                }
            }
        }
    }
}
