# How-to-fill-an-empty-area-with-dotted-lines-in-Xamarin.Forms-Charts
This article explains how to fill the empty area with dotted lines in Xamarin.Forms SfChart.

To demonstrate this, consider the two stacking area series. If its populated data have a NaN or null then, it will be plotted as per in below

![](https://github.com/SyncfusionExamples/How-to-fill-an-empty-area-with-dotted-lines-in-Xamarin.Forms-Charts/blob/main/with_empty_area.png) 

In order to fill this empty space with dotted lines, use FastLineSeries with calculated data from two stacking area series’s data collection as per in below,

[XAML]

*To plot the dashed fast line, use StrokeDashArray property in FastLineSeries.
```
…
<chart:SfChart.Series>
         <chart:StackingAreaSeries ItemsSource="{Binding Data}"
             XBindingPath="Date" 
             YBindingPath="Value" />
         <chart:StackingAreaSeries ItemsSource="{Binding Data1}" 
             XBindingPath="Date"
             YBindingPath="Value" />
         <chart:FastLineSeries ItemsSource="{Binding LineData}" 
             XBindingPath="Date" 
             YBindingPath="Value" 
             Color="Gray">
            <chart:FastLineSeries.StrokeDashArray>
               <x:Array Type="{x:Type x:Double}">
                   <x:Double>5</x:Double>
                   <x:Double>6</x:Double>
               </x:Array>
            </chart:FastLineSeries.StrokeDashArray>
        </chart:FastLineSeries>
      </chart:SfChart.Series>
…
```
[C#]  

*Data and Data1 are point collection of stacking area series. Based on that two collection, create a items source for fast line series 
```
public class ChartViewModel
    {
        public ObservableCollection<ChartModel> Data { get; set; }
        public ObservableCollection<ChartModel> Data1 { get; set; }
        public ObservableCollection<ChartModel> LineData { get; set; }
        bool IsEmpty { get; set; } = false;
        
        public ChartViewModel()
        {
            Random random = new Random();
            var date = new DateTime(2017, 5, 1);
            Data = new ObservableCollection<ChartModel>();
            for (int i = 0; i < 14; i++)
            {
                if (i == 3 || i == 10)
                {
                    Data.Add(new ChartModel(date, double.NaN));
                }
                else
                {
                    Data.Add(new ChartModel(date, random.Next(20, 100)));
                }
                date = date.AddDays(1);
            }


            date = new DateTime(2017, 5, 1);
            Data1 = new ObservableCollection<ChartModel>();
            for (int i = 0; i < 14; i++)
            {
                if (i == 3 || i == 10)
                    Data1.Add(new ChartModel(date, double.NaN));
                else
                    Data1.Add(new ChartModel(date, random.Next(20, 100)));

                date = date.AddDays(1);
            }


            LineData = new ObservableCollection<ChartModel>();
            for (int i = 0; i < Data.Count; i++)
            {
                if (double.IsNaN(Data[i].Value))
                {
                    IsEmpty = true;
                }
                else
                    IsEmpty = false;

                if (IsEmpty)
                {
                    if (!double.IsNaN(Data[i - 1].Value))
                    {
                        LineData.Add(new ChartModel(Data[i - 1].Date, 0));
                        LineData.Add(new ChartModel(Data[i - 1].Date, Data[i - 1].Value + Data1[i - 1].Value));
                    }

                    if (!double.IsNaN(Data1[i + 1].Value))
                    {
                        LineData.Add(new ChartModel(Data[i + 1].Date, Data[i + 1].Value + Data1[i + 1].Value));
                        LineData.Add(new ChartModel(Data[i + 1].Date, 0));
                        LineData.Add(new ChartModel(Data[i + 1].Date, double.NaN));
                    }

                }

            }
        }
    }
    
```    
## Output
 
![](https://github.com/SyncfusionExamples/How-to-fill-an-empty-area-with-dotted-lines-in-Xamarin.Forms-Charts/blob/main/filled_empty_area.jpg)

## See also

[How to draw dotted line using FastLineSeries in Chart](https://www.syncfusion.com/kb/5924/how-to-draw-dotted-line-using-fastlineseries-in-chart)

[How to visualize the Xamarin.Forms Pie Chart in linear form](https://www.syncfusion.com/kb/11285/how-to-visualize-the-xamarin-forms-pie-chart-in-linear-form)

[How to achieve the Tornado chart in Xamarin.Forms Chart](https://www.syncfusion.com/kb/10684/how-to-achieve-the-tornado-chart-in-xamarin-forms-chart)

[How to use the drill-down functionality in Xamarin.Forms Chart](https://www.syncfusion.com/kb/10662/how-to-use-the-drill-down-functionality-in-xamarin-forms-chart)

[How to set size of pie/doughnut](https://www.syncfusion.com/kb/5525/how-to-set-size-of-pie-doughnut)

