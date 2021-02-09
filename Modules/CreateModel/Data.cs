using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CreateModel
{
    public class HROIRectangle1Data
    {
        public double row1 { get; set; }
        public double col1 { get; set; }
        public double row2 { get; set; }
        public double col2 { get; set; }
    }
    public class HROIRectangle2Data
    {
        public double row { get; set; }
        public double column { get; set; }
        public double phi { get; set; }
        public double length { get; set; }
        public double length2 { get; set; }
    }
    public class HROIElipseData
    {
        public double row { get; set; }
        public double column { get; set; }
        public double phi { get; set; }
        public double radius { get; set; }
        public double radius2 { get; set; }
    }
    public class HROICircleData
    {
        public double row { get; set; }
        public double column { get; set; }
        public double radius { get; set; }
    }
    public class CreadeModelParameter
    {
        public string NumLevels { get; set; } = "auto";
        public double AngleStart { get; set; } = 0;
        public double AngleExtent { get; set; } = 0.75;
        public string AngleStep { get; set; } = "auto";
        public string Optimization { get; set; } = "none";
        public string Metric { get; set; } = "use_polarity";
        public double Contrast { get; set; } = 30;
        public double MinContrast { get; set; } = 10;
        public double MinScore { get; set; } = 0.7;
        public double NumMatches { get; set; } = 1;
        public double MaxOverlap { get; set; } = 0.5;
        public string SubPixel { get; set; } = "least_squares_high";
        public double Greediness { get; set; } = 0.7;

       // find_shape_model(Image : : ModelID, AngleStart, AngleExtent, MinScore, NumMatches, MaxOverlap, SubPixel, NumLevels, Greediness : Row, Column, Angle, Score)
    }

    public class Data
    {
        HROIRectangle1Data hROIRectangle1Data { get; set; }
        HROIRectangle2Data hROIRectangle2Data { get; set; }
        HROIElipseData hROIElipseData { get; set; }
        HROICircleData hROICircleData { get; set; }
        CreadeModelParameter creadeParameter { get; set; }
    }

}
