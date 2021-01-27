using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;

using System.Threading;
using System.Reflection;
using System.Windows;
using System.Drawing;
using System.Diagnostics;

namespace HalconPackage 
{
    public partial class HalconPackage
    {
        /// <summary>
        /// 轮廓颜色 green
        /// </summary>
        static public HTuple ContourColor = "green";
        /// <summary>
        /// 轮廓颜色 red
        /// </summary>
        static public HTuple MessageColor = "red";
        /// <summary>
        /// 轮廓颜色 blue
        /// </summary>
        static public HTuple CenterColor = "blue";
        /// <summary>
        /// 轮廓颜色 blue
        /// </summary>
        static public HTuple RegionColor = "blue";
        static public HTuple NGColor = "red";
        static public HTuple okColor = "green";

        static Object thisLock = new Object();
        /// <summary>
        ///Image转换HObject 
        /// </summary>
        
        public static bool Image2HObject(int width, int height, IntPtr pImage, ref HObject hImage, HTuple hvWinHandle = null)
        {
            try
            {
                //HObject hoImage = null;
                //HOperatorSet.GenEmptyObj(out hoImage);
                //HOperatorSet.GenImage1Extern(out hoImage, "byte", new HTuple(width),
                //                             new HTuple(height), new HTuple(pImage), new HTuple(0));
                //if (hImage == null)
                //    HOperatorSet.GenEmptyObj(out hImage);
                //HOperatorSet.CopyImage(hoImage, out hImage);

                if (hImage == null)
                    HOperatorSet.GenEmptyObj(out hImage);

                lock (hImage)
                {
                    hImage.Dispose();
                    //HOperatorSet.GenImage1(out hImage, "byte", new HTuple(width),
                    //             new HTuple(height), new HTuple(pImage));
                    HOperatorSet.GenImage1Extern(out hImage, "byte", new HTuple(width),
                                 new HTuple(height), new HTuple(pImage), new HTuple(0));

                    if (hvWinHandle != null)
                    {
                        //lock (thisLock)
                        //{
                            HOperatorSet.DispImage(hImage, hvWinHandle);
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        /// <summary>
        /// 文本显示
        /// </summary>
        /// <param name="hv_WindowHandle"></param>
        /// <param name="hv_String">要打印的字符串</param>
        /// <param name="hv_Row1">打印的位置Row</param>
        /// <param name="hv_Column1">打印的位置Col</param>
        /// <param name="hv_Color1">打印的颜色</param>
        /// <param name="hv_CoordSystem1">字体</param>
        /// <param name="hv_Box1">是否将文字显示在box中</param>
        public static void disp_message(HTuple hv_WindowHandle, HTuple hv_String, int hv_Row1 = 12,
             int hv_Column1 = 12, string hv_Color1 = "red", string hv_CoordSystem1 = "window", string hv_Box1 = "false")
        {
            HTuple hv_Row = new HTuple();
            hv_Row = hv_Row1;
            HTuple hv_Column = new HTuple();
            hv_Column = hv_Column1;
            HTuple hv_CoordSystem = new HTuple();
            hv_CoordSystem = hv_CoordSystem1;
            HTuple hv_Color = new HTuple();
            hv_Color = hv_Color1;
            HTuple hv_Box = new HTuple();
            hv_Box = hv_Box1;

            //HTuple hv_Row = new HTuple();
            //hv_Row.I = hv_Row1;
            //HTuple hv_Column = new HTuple();
            //hv_Column.I = hv_Column1;
            //HTuple hv_CoordSystem = new HTuple();
            //hv_CoordSystem.S = hv_CoordSystem1;
            //HTuple hv_Color = new HTuple();
            //hv_Color.S = hv_Color1;
            //HTuple hv_Box = new HTuple();
            //hv_Box.S = hv_Box1;

            HTuple hv_Red, hv_Green, hv_Blue, hv_Row1Part;
            HTuple hv_Column1Part, hv_Row2Part, hv_Column2Part, hv_RowWin;
            HTuple hv_ColumnWin, hv_WidthWin, hv_HeightWin, hv_MaxAscent;
            HTuple hv_MaxDescent, hv_MaxWidth, hv_MaxHeight, hv_R1 = new HTuple();
            HTuple hv_C1 = new HTuple(), hv_FactorRow = new HTuple(), hv_FactorColumn = new HTuple();
            HTuple hv_Width = new HTuple(), hv_Index = new HTuple(), hv_Ascent = new HTuple();
            HTuple hv_Descent = new HTuple(), hv_W = new HTuple(), hv_H = new HTuple();
            HTuple hv_FrameHeight = new HTuple(), hv_FrameWidth = new HTuple();
            HTuple hv_R2 = new HTuple(), hv_C2 = new HTuple(), hv_DrawMode = new HTuple();
            HTuple hv_Exception = new HTuple(), hv_CurrentColor = new HTuple();

            HTuple hv_Color_COPY_INP_TMP = hv_Color.Clone();
            HTuple hv_Column_COPY_INP_TMP = hv_Column.Clone();
            HTuple hv_Row_COPY_INP_TMP = hv_Row.Clone();
            HTuple hv_String_COPY_INP_TMP = hv_String.Clone();

            HOperatorSet.GetRgb(hv_WindowHandle, out hv_Red, out hv_Green, out hv_Blue);
            HOperatorSet.GetPart(hv_WindowHandle, out hv_Row1Part, out hv_Column1Part, out hv_Row2Part,
                out hv_Column2Part);
            HOperatorSet.GetWindowExtents(hv_WindowHandle, out hv_RowWin, out hv_ColumnWin,
                out hv_WidthWin, out hv_HeightWin);
            HOperatorSet.SetPart(hv_WindowHandle, 0, 0, hv_HeightWin - 1, hv_WidthWin - 1);
            //
            //default settings
            if ((int)(new HTuple(hv_Row_COPY_INP_TMP.TupleEqual(-1))) != 0)
            {
                hv_Row_COPY_INP_TMP = 12;
            }
            if ((int)(new HTuple(hv_Column_COPY_INP_TMP.TupleEqual(-1))) != 0)
            {
                hv_Column_COPY_INP_TMP = 12;
            }
            if ((int)(new HTuple(hv_Color_COPY_INP_TMP.TupleEqual(new HTuple()))) != 0)
            {
                hv_Color_COPY_INP_TMP = "";
            }
            //
            hv_String_COPY_INP_TMP = ((("" + hv_String_COPY_INP_TMP) + "")).TupleSplit("\n");
            //
            //Estimate extentions of text depending on font size.
            HOperatorSet.GetFontExtents(hv_WindowHandle, out hv_MaxAscent, out hv_MaxDescent,
                out hv_MaxWidth, out hv_MaxHeight);
            if ((int)(new HTuple(hv_CoordSystem.TupleEqual("window"))) != 0)
            {
                hv_R1 = hv_Row_COPY_INP_TMP.Clone();
                hv_C1 = hv_Column_COPY_INP_TMP.Clone();
            }
            else
            {
                //transform image to window coordinates
                hv_FactorRow = (1.0 * hv_HeightWin) / ((hv_Row2Part - hv_Row1Part) + 1);
                hv_FactorColumn = (1.0 * hv_WidthWin) / ((hv_Column2Part - hv_Column1Part) + 1);
                hv_R1 = ((hv_Row_COPY_INP_TMP - hv_Row1Part) + 0.5) * hv_FactorRow;
                hv_C1 = ((hv_Column_COPY_INP_TMP - hv_Column1Part) + 0.5) * hv_FactorColumn;
            }
            //
            //display text box depending on text size
            if ((int)(new HTuple(hv_Box.TupleEqual("true"))) != 0)
            {
                //calculate box extents
                hv_String_COPY_INP_TMP = (" " + hv_String_COPY_INP_TMP) + " ";
                hv_Width = new HTuple();
                for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_String_COPY_INP_TMP.TupleLength()
                    )) - 1); hv_Index = (int)hv_Index + 1)
                {
                    HOperatorSet.GetStringExtents(hv_WindowHandle, hv_String_COPY_INP_TMP.TupleSelect(
                        hv_Index), out hv_Ascent, out hv_Descent, out hv_W, out hv_H);
                    hv_Width = hv_Width.TupleConcat(hv_W);
                }
                hv_FrameHeight = hv_MaxHeight * (new HTuple(hv_String_COPY_INP_TMP.TupleLength()
                    ));
                hv_FrameWidth = (((new HTuple(0)).TupleConcat(hv_Width))).TupleMax();
                hv_R2 = hv_R1 + hv_FrameHeight;
                hv_C2 = hv_C1 + hv_FrameWidth;
                //display rectangles
                HOperatorSet.GetDraw(hv_WindowHandle, out hv_DrawMode);
                HOperatorSet.SetDraw(hv_WindowHandle, "fill");
                HOperatorSet.SetColor(hv_WindowHandle, "light gray");
                HOperatorSet.DispRectangle1(hv_WindowHandle, hv_R1 + 3, hv_C1 + 3, hv_R2 + 3, hv_C2 + 3);
                HOperatorSet.SetColor(hv_WindowHandle, "white");
                HOperatorSet.DispRectangle1(hv_WindowHandle, hv_R1, hv_C1, hv_R2, hv_C2);
                HOperatorSet.SetDraw(hv_WindowHandle, hv_DrawMode);
            }
            else if ((int)(new HTuple(hv_Box.TupleNotEqual("false"))) != 0)
            {
                hv_Exception = "Wrong value of control parameter Box";
                throw new HalconException(hv_Exception);
            }
            //Write text.
            for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_String_COPY_INP_TMP.TupleLength()
                )) - 1); hv_Index = (int)hv_Index + 1)
            {
                hv_CurrentColor = hv_Color_COPY_INP_TMP.TupleSelect(hv_Index % (new HTuple(hv_Color_COPY_INP_TMP.TupleLength()
                    )));
                if ((int)((new HTuple(hv_CurrentColor.TupleNotEqual(""))).TupleAnd(new HTuple(hv_CurrentColor.TupleNotEqual(
                    "auto")))) != 0)
                {
                    HOperatorSet.SetColor(hv_WindowHandle, hv_CurrentColor);
                }
                else
                {
                    HOperatorSet.SetRgb(hv_WindowHandle, hv_Red, hv_Green, hv_Blue);
                }
                hv_Row_COPY_INP_TMP = hv_R1 + (hv_MaxHeight * hv_Index);
                HOperatorSet.SetTposition(hv_WindowHandle, hv_Row_COPY_INP_TMP, hv_C1);
                HOperatorSet.WriteString(hv_WindowHandle, hv_String_COPY_INP_TMP.TupleSelect(
                    hv_Index));
            }
            //reset changed window settings
            HOperatorSet.SetRgb(hv_WindowHandle, hv_Red, hv_Green, hv_Blue);
            HOperatorSet.SetPart(hv_WindowHandle, hv_Row1Part, hv_Column1Part, hv_Row2Part,
                hv_Column2Part);

            return;
        }

        public static void set_display_font(HTuple hv_WindowHandle, HTuple hv_Size, HTuple hv_Font,
      HTuple hv_Bold, HTuple hv_Slant)
        {


            // Local control variables 

            HTuple hv_OS, hv_Exception = new HTuple();
            HTuple hv_AllowedFontSizes = new HTuple(), hv_Distances = new HTuple();
            HTuple hv_Indices = new HTuple();

            HTuple hv_Bold_COPY_INP_TMP = hv_Bold.Clone();
            HTuple hv_Font_COPY_INP_TMP = hv_Font.Clone();
            HTuple hv_Size_COPY_INP_TMP = hv_Size.Clone();
            HTuple hv_Slant_COPY_INP_TMP = hv_Slant.Clone();

            // Initialize local and output iconic variables 

            //This procedure sets the text font of the current window with
            //the specified attributes.
            //It is assumed that following fonts are installed on the system:
            //Windows: Courier New, Arial Times New Roman
            //Linux: courier, helvetica, times
            //Because fonts are displayed smaller on Linux than on Windows,
            //a scaling factor of 1.25 is used the get comparable results.
            //For Linux, only a limited number of font sizes is supported,
            //to get comparable results, it is recommended to use one of the
            //following sizes: 9, 11, 14, 16, 20, 27
            //(which will be mapped internally on Linux systems to 11, 14, 17, 20, 25, 34)
            //
            //input parameters:
            //WindowHandle: The graphics window for which the font will be set
            //Size: The font size. If Size=-1, the default of 16 is used.
            //Bold: If set to 'true', a bold font is used
            //Slant: If set to 'true', a slanted font is used
            //
            HOperatorSet.GetSystem("operating_system", out hv_OS);
            if ((int)((new HTuple(hv_Size_COPY_INP_TMP.TupleEqual(new HTuple()))).TupleOr(
                new HTuple(hv_Size_COPY_INP_TMP.TupleEqual(-1)))) != 0)
            {
                hv_Size_COPY_INP_TMP = 16;
            }
            if ((int)(new HTuple((((hv_OS.TupleStrFirstN(2)).TupleStrLastN(0))).TupleEqual(
                "Win"))) != 0)
            {
                //set font on Windows systems
                if ((int)((new HTuple((new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("mono"))).TupleOr(
                    new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("Courier"))))).TupleOr(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual(
                    "courier")))) != 0)
                {
                    hv_Font_COPY_INP_TMP = "Courier New";
                }
                else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("sans"))) != 0)
                {
                    hv_Font_COPY_INP_TMP = "Arial";
                }
                else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("serif"))) != 0)
                {
                    hv_Font_COPY_INP_TMP = "Times New Roman";
                }
                if ((int)(new HTuple(hv_Bold_COPY_INP_TMP.TupleEqual("true"))) != 0)
                {
                    hv_Bold_COPY_INP_TMP = 1;
                }
                else if ((int)(new HTuple(hv_Bold_COPY_INP_TMP.TupleEqual("false"))) != 0)
                {
                    hv_Bold_COPY_INP_TMP = 0;
                }
                else
                {
                    hv_Exception = "Wrong value of control parameter Bold";
                    throw new HalconException(hv_Exception);
                }
                if ((int)(new HTuple(hv_Slant_COPY_INP_TMP.TupleEqual("true"))) != 0)
                {
                    hv_Slant_COPY_INP_TMP = 1;
                }
                else if ((int)(new HTuple(hv_Slant_COPY_INP_TMP.TupleEqual("false"))) != 0)
                {
                    hv_Slant_COPY_INP_TMP = 0;
                }
                else
                {
                    hv_Exception = "Wrong value of control parameter Slant";
                    throw new HalconException(hv_Exception);
                }
                try
                {
                    HOperatorSet.SetFont(hv_WindowHandle, ((((((("-" + hv_Font_COPY_INP_TMP) + "-") + hv_Size_COPY_INP_TMP) + "-*-") + hv_Slant_COPY_INP_TMP) + "-*-*-") + hv_Bold_COPY_INP_TMP) + "-");
                }
                // catch (Exception) 
                catch (HalconException HDevExpDefaultException1)
                {
                    HDevExpDefaultException1.ToHTuple(out hv_Exception);
                    throw new HalconException(hv_Exception);
                }
            }
            else
            {
                //set font for UNIX systems
                hv_Size_COPY_INP_TMP = hv_Size_COPY_INP_TMP * 1.25;
                hv_AllowedFontSizes = new HTuple();
                hv_AllowedFontSizes[0] = 11;
                hv_AllowedFontSizes[1] = 14;
                hv_AllowedFontSizes[2] = 17;
                hv_AllowedFontSizes[3] = 20;
                hv_AllowedFontSizes[4] = 25;
                hv_AllowedFontSizes[5] = 34;
                if ((int)(new HTuple(((hv_AllowedFontSizes.TupleFind(hv_Size_COPY_INP_TMP))).TupleEqual(
                    -1))) != 0)
                {
                    hv_Distances = ((hv_AllowedFontSizes - hv_Size_COPY_INP_TMP)).TupleAbs();
                    HOperatorSet.TupleSortIndex(hv_Distances, out hv_Indices);
                    hv_Size_COPY_INP_TMP = hv_AllowedFontSizes.TupleSelect(hv_Indices.TupleSelect(
                        0));
                }
                if ((int)((new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("mono"))).TupleOr(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual(
                    "Courier")))) != 0)
                {
                    hv_Font_COPY_INP_TMP = "courier";
                }
                else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("sans"))) != 0)
                {
                    hv_Font_COPY_INP_TMP = "helvetica";
                }
                else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("serif"))) != 0)
                {
                    hv_Font_COPY_INP_TMP = "times";
                }
                if ((int)(new HTuple(hv_Bold_COPY_INP_TMP.TupleEqual("true"))) != 0)
                {
                    hv_Bold_COPY_INP_TMP = "bold";
                }
                else if ((int)(new HTuple(hv_Bold_COPY_INP_TMP.TupleEqual("false"))) != 0)
                {
                    hv_Bold_COPY_INP_TMP = "medium";
                }
                else
                {
                    hv_Exception = "Wrong value of control parameter Bold";
                    throw new HalconException(hv_Exception);
                }
                if ((int)(new HTuple(hv_Slant_COPY_INP_TMP.TupleEqual("true"))) != 0)
                {
                    if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("times"))) != 0)
                    {
                        hv_Slant_COPY_INP_TMP = "i";
                    }
                    else
                    {
                        hv_Slant_COPY_INP_TMP = "o";
                    }
                }
                else if ((int)(new HTuple(hv_Slant_COPY_INP_TMP.TupleEqual("false"))) != 0)
                {
                    hv_Slant_COPY_INP_TMP = "r";
                }
                else
                {
                    hv_Exception = "Wrong value of control parameter Slant";
                    throw new HalconException(hv_Exception);
                }
                try
                {
                    HOperatorSet.SetFont(hv_WindowHandle, ((((((("-adobe-" + hv_Font_COPY_INP_TMP) + "-") + hv_Bold_COPY_INP_TMP) + "-") + hv_Slant_COPY_INP_TMP) + "-normal-*-") + hv_Size_COPY_INP_TMP) + "-*-*-*-*-*-*-*");
                }
                // catch (Exception) 
                catch (HalconException HDevExpDefaultException1)
                {
                    HDevExpDefaultException1.ToHTuple(out hv_Exception);
                    throw new HalconException(hv_Exception);
                }
            }

            return;
        }
        /// <summary>
        /// 绘制箭头
        /// </summary>
        /// <param name="ho_Arrow"></param>
        /// <param name="hv_Row1"></param>
        /// <param name="hv_Column1"></param>
        /// <param name="hv_Row2"></param>
        /// <param name="hv_Column2"></param>
        /// <param name="hv_HeadLength"></param>
        /// <param name="hv_HeadWidth"></param>
        public void gen_arrow_contour_xld(out HObject ho_Arrow, HTuple hv_Row1, HTuple hv_Column1,
            HTuple hv_Row2, HTuple hv_Column2, HTuple hv_HeadLength, HTuple hv_HeadWidth)
        {


            // Stack for temporary objects 
            HObject[] OTemp = new HObject[20];
            long SP_O = 0;

            // Local iconic variables 

            HObject ho_TempArrow = null;


            // Local control variables 

            HTuple hv_Length, hv_ZeroLengthIndices, hv_DR;
            HTuple hv_DC, hv_HalfHeadWidth, hv_RowP1, hv_ColP1, hv_RowP2;
            HTuple hv_ColP2, hv_Index;

            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Arrow);
            HOperatorSet.GenEmptyObj(out ho_TempArrow);

            try
            {
                //This procedure generates arrow shaped XLD contours,
                //pointing from (Row1, Column1) to (Row2, Column2).
                //If starting and end point are identical, a contour consisting
                //of a single point is returned.
                //
                //input parameteres:
                //Row1, Column1: Coordinates of the arrows' starting points
                //Row2, Column2: Coordinates of the arrows' end points
                //HeadLength, HeadWidth: Size of the arrow heads in pixels
                //
                //output parameter:
                //Arrow: The resulting XLD contour
                //
                //The input tuples Row1, Column1, Row2, and Column2 have to be of
                //the same length.
                //HeadLength and HeadWidth either have to be of the same length as
                //Row1, Column1, Row2, and Column2 or have to be a single element.
                //If one of the above restrictions is violated, an error will occur.
                //
                //
                //Init
                ho_Arrow.Dispose();
                HOperatorSet.GenEmptyObj(out ho_Arrow);
                //
                //Calculate the arrow length
                HOperatorSet.DistancePp(hv_Row1, hv_Column1, hv_Row2, hv_Column2, out hv_Length);
                //
                //Mark arrows with identical start and end point
                //(set Length to -1 to avoid division-by-zero exception)
                hv_ZeroLengthIndices = hv_Length.TupleFind(0);
                if ((int)(new HTuple(hv_ZeroLengthIndices.TupleNotEqual(-1))) != 0)
                {
                    hv_Length[hv_ZeroLengthIndices] = -1;
                }
                //
                //Calculate auxiliary variables.
                hv_DR = (1.0 * (hv_Row2 - hv_Row1)) / hv_Length;
                hv_DC = (1.0 * (hv_Column2 - hv_Column1)) / hv_Length;
                hv_HalfHeadWidth = hv_HeadWidth / 2.0;
                //
                //Calculate end points of the arrow head.
                hv_RowP1 = (hv_Row1 + ((hv_Length - hv_HeadLength) * hv_DR)) + (hv_HalfHeadWidth * hv_DC);
                hv_ColP1 = (hv_Column1 + ((hv_Length - hv_HeadLength) * hv_DC)) - (hv_HalfHeadWidth * hv_DR);
                hv_RowP2 = (hv_Row1 + ((hv_Length - hv_HeadLength) * hv_DR)) - (hv_HalfHeadWidth * hv_DC);
                hv_ColP2 = (hv_Column1 + ((hv_Length - hv_HeadLength) * hv_DC)) + (hv_HalfHeadWidth * hv_DR);
                //
                //Finally create output XLD contour for each input point pair
                for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_Length.TupleLength())) - 1); hv_Index = (int)hv_Index + 1)
                {
                    if ((int)(new HTuple(((hv_Length.TupleSelect(hv_Index))).TupleEqual(-1))) != 0)
                    {
                        //Create_ single points for arrows with identical start and end point
                        ho_TempArrow.Dispose();
                        HOperatorSet.GenContourPolygonXld(out ho_TempArrow, hv_Row1.TupleSelect(
                            hv_Index), hv_Column1.TupleSelect(hv_Index));
                    }
                    else
                    {
                        //Create arrow contour
                        ho_TempArrow.Dispose();
                        HOperatorSet.GenContourPolygonXld(out ho_TempArrow, ((((((((((hv_Row1.TupleSelect(
                            hv_Index))).TupleConcat(hv_Row2.TupleSelect(hv_Index)))).TupleConcat(
                            hv_RowP1.TupleSelect(hv_Index)))).TupleConcat(hv_Row2.TupleSelect(hv_Index)))).TupleConcat(
                            hv_RowP2.TupleSelect(hv_Index)))).TupleConcat(hv_Row2.TupleSelect(hv_Index)),
                            ((((((((((hv_Column1.TupleSelect(hv_Index))).TupleConcat(hv_Column2.TupleSelect(
                            hv_Index)))).TupleConcat(hv_ColP1.TupleSelect(hv_Index)))).TupleConcat(
                            hv_Column2.TupleSelect(hv_Index)))).TupleConcat(hv_ColP2.TupleSelect(
                            hv_Index)))).TupleConcat(hv_Column2.TupleSelect(hv_Index)));
                    }
                    OTemp[SP_O] = ho_Arrow.CopyObj(1, -1);
                    SP_O++;
                    ho_Arrow.Dispose();
                    HOperatorSet.ConcatObj(OTemp[SP_O - 1], ho_TempArrow, out ho_Arrow);
                    OTemp[SP_O - 1].Dispose();
                    SP_O = 0;
                }
                ho_TempArrow.Dispose();

                return;
            }
            catch (HalconException HDevExpDefaultException)
            {
                ho_TempArrow.Dispose();

                throw HDevExpDefaultException;
            }
        }

        /// <summary>
        /// 绘制rake直线
        /// </summary>
        /// <param name="ho_Regions">输出显示取悦</param>
        /// <param name="hv_WindowHandle">显示窗口句柄</param>
        /// <param name="hv_Elements">测量矩形数量</param>
        /// <param name="hv_DetectHeight">测量矩形高度</param>
        /// <param name="hv_DetectWidth">测量矩形宽度</param>
        /// <param name="hv_Row1">直线数据</param>
        /// <param name="hv_Column1">直线数据</param>
        /// <param name="hv_Row2">直线数据</param>
        /// <param name="hv_Column2">直线数据</param>
        public void draw_rake(out HObject ho_Regions, HTuple hv_WindowHandle, HTuple hv_Elements,
            HTuple hv_DetectHeight, HTuple hv_DetectWidth, out HTuple hv_Row1, out HTuple hv_Column1,
            out HTuple hv_Row2, out HTuple hv_Column2)
        {


            // Stack for temporary objects 
            HObject[] OTemp = new HObject[20];
            long SP_O = 0;

            // Local iconic variables 

            HObject ho_RegionLines, ho_Rectangle = null;
            HObject ho_Arrow1 = null;

            // Local control variables 

            HTuple hv_ATan, hv_i, hv_RowC = new HTuple();
            HTuple hv_ColC = new HTuple(), hv_Distance = new HTuple();
            HTuple hv_RowL2 = new HTuple(), hv_RowL1 = new HTuple(), hv_ColL2 = new HTuple();
            HTuple hv_ColL1 = new HTuple();

            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Regions);
            HOperatorSet.GenEmptyObj(out ho_RegionLines);
            HOperatorSet.GenEmptyObj(out ho_Rectangle);
            HOperatorSet.GenEmptyObj(out ho_Arrow1);

            try
            {
                //提示
                disp_message(hv_WindowHandle, "点击鼠标左键画一条直线,点击右键确认", hv_Color1:"red");
                //产生一个空显示对象，用于显示
                ho_Regions.Dispose();
                HOperatorSet.GenEmptyObj(out ho_Regions);
                //画矢量检测直线
                HOperatorSet.DrawLine(hv_WindowHandle, out hv_Row1, out hv_Column1, out hv_Row2,
                    out hv_Column2);
                //产生直线xld
                ho_RegionLines.Dispose();
                HOperatorSet.GenContourPolygonXld(out ho_RegionLines, hv_Row1.TupleConcat(hv_Row2),
                    hv_Column1.TupleConcat(hv_Column2));
                //存储到显示对象
                OTemp[SP_O] = ho_Regions.CopyObj(1, -1);
                SP_O++;
                ho_Regions.Dispose();
                HOperatorSet.ConcatObj(OTemp[SP_O - 1], ho_RegionLines, out ho_Regions);
                OTemp[SP_O - 1].Dispose();
                SP_O = 0;
                //计算直线与x轴的夹角，逆时针方向为正向。
                HOperatorSet.AngleLx(hv_Row1, hv_Column1, hv_Row2, hv_Column2, out hv_ATan);

                //边缘检测方向垂直于检测直线：直线方向正向旋转90°为边缘检测方向
                hv_ATan = hv_ATan + ((new HTuple(90)).TupleRad());

                //根据检测直线按顺序产生测量区域矩形，并存储到显示对象
                for (hv_i = 1; hv_i.Continue(hv_Elements, 1); hv_i = hv_i.TupleAdd(1))
                {
                    //如果只有一个测量矩形，作为卡尺工具，宽度为检测直线的长度
                    if ((int)(new HTuple(hv_Elements.TupleEqual(1))) != 0)
                    {
                        hv_RowC = (hv_Row1 + hv_Row2) * 0.5;
                        hv_ColC = (hv_Column1 + hv_Column2) * 0.5;
                        HOperatorSet.DistancePp(hv_Row1, hv_Column1, hv_Row2, hv_Column2, out hv_Distance);
                        ho_Rectangle.Dispose();
                        HOperatorSet.GenRectangle2ContourXld(out ho_Rectangle, hv_RowC, hv_ColC,
                            hv_ATan, hv_DetectHeight / 2, hv_Distance / 2);
                    }
                    else
                    {
                        //如果有多个测量矩形，产生该测量矩形xld
                        hv_RowC = hv_Row1 + (((hv_Row2 - hv_Row1) * (hv_i - 1)) / (hv_Elements - 1));
                        hv_ColC = hv_Column1 + (((hv_Column2 - hv_Column1) * (hv_i - 1)) / (hv_Elements - 1));
                        ho_Rectangle.Dispose();
                        HOperatorSet.GenRectangle2ContourXld(out ho_Rectangle, hv_RowC, hv_ColC,
                            hv_ATan, hv_DetectHeight / 2, hv_DetectWidth / 2);
                    }
                    //把测量矩形xld存储到显示对象
                    OTemp[SP_O] = ho_Regions.CopyObj(1, -1);
                    SP_O++;
                    ho_Regions.Dispose();
                    HOperatorSet.ConcatObj(OTemp[SP_O - 1], ho_Rectangle, out ho_Regions);
                    OTemp[SP_O - 1].Dispose();
                    SP_O = 0;
                    if ((int)(new HTuple(hv_i.TupleEqual(1))) != 0)
                    {
                        //在第一个测量矩形绘制一个箭头xld，用于只是边缘检测方向
                        hv_RowL2 = hv_RowC + ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleSin()));
                        hv_RowL1 = hv_RowC - ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleSin()));
                        hv_ColL2 = hv_ColC + ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleCos()));
                        hv_ColL1 = hv_ColC - ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleCos()));
                        ho_Arrow1.Dispose();
                        gen_arrow_contour_xld(out ho_Arrow1, hv_RowL1, hv_ColL1, hv_RowL2, hv_ColL2,
                            25, 25);
                        //把xld存储到显示对象
                        OTemp[SP_O] = ho_Regions.CopyObj(1, -1);
                        SP_O++;
                        ho_Regions.Dispose();
                        HOperatorSet.ConcatObj(OTemp[SP_O - 1], ho_Arrow1, out ho_Regions);
                        OTemp[SP_O - 1].Dispose();
                        SP_O = 0;
                    }
                }

                ho_RegionLines.Dispose();
                ho_Rectangle.Dispose();
                ho_Arrow1.Dispose();

                return;
            }
            catch (HalconException HDevExpDefaultException)
            {
                ho_RegionLines.Dispose();
                ho_Rectangle.Dispose();
                ho_Arrow1.Dispose();

                throw HDevExpDefaultException;
            }
        }

        /// <summary>
        /// 直线拟合工具
        /// </summary>
        /// <param name="ho_Image">拟合的图像</param>
        /// <param name="ho_Regions">显示Regions</param>
        /// <param name="hv_Elements">拟合数量</param>
        /// <param name="hv_DetectHeight">矩形高度</param>
        /// <param name="hv_DetectWidth">矩形宽带</param>
        /// <param name="hv_Sigma">图像模糊度</param>
        /// <param name="hv_Threshold">微分阀值</param>
        /// <param name="hv_Transition">极性</param>
        /// <param name="hv_Select">选择</param>
        /// <param name="hv_Row1"></param>
        /// <param name="hv_Column1"></param>
        /// <param name="hv_Row2"></param>
        /// <param name="hv_Column2"></param>
        /// <param name="hv_ResultRow">结果</param>
        /// <param name="hv_ResultColumn">结果</param>
        public void rake(HObject ho_Image, out HObject ho_Regions, HTuple hv_Elements,
            HTuple hv_DetectHeight, HTuple hv_DetectWidth, HTuple hv_Sigma, HTuple hv_Threshold,
            HTuple hv_Transition, HTuple hv_Select,HTuple hv_Row1,HTuple  hv_Column1,HTuple  hv_Row2,
             HTuple   hv_Column2, out HTuple hv_ResultRow, out HTuple hv_ResultColumn)
        {
            //临时对象堆栈 Stack for temporary objects 
            HObject[] OTemp = new HObject[20];
            long SP_O = 0;

            // Local iconic variables 

            HObject ho_RegionLines, ho_Rectangle = null;
            HObject ho_Arrow1 = null;


            // Local control variables 

            HTuple hv_Width, hv_Height, hv_ATan, hv_i;
            HTuple hv_RowC = new HTuple(), hv_ColC = new HTuple(), hv_Distance = new HTuple();
            HTuple hv_RowL2 = new HTuple(), hv_RowL1 = new HTuple(), hv_ColL2 = new HTuple();
            HTuple hv_ColL1 = new HTuple(), hv_MsrHandle_Measure = new HTuple();
            HTuple hv_RowEdge = new HTuple(), hv_ColEdge = new HTuple();
            HTuple hv_Amplitude = new HTuple(), hv_tRow = new HTuple();
            HTuple hv_tCol = new HTuple(), hv_t = new HTuple(), hv_Number = new HTuple();
            HTuple hv_j = new HTuple();

            HTuple hv_DetectWidth_COPY_INP_TMP = hv_DetectWidth.Clone();
            HTuple hv_Select_COPY_INP_TMP = hv_Select.Clone();
            HTuple hv_Transition_COPY_INP_TMP = hv_Transition.Clone();

            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Regions);
            HOperatorSet.GenEmptyObj(out ho_RegionLines);
            HOperatorSet.GenEmptyObj(out ho_Rectangle);
            HOperatorSet.GenEmptyObj(out ho_Arrow1);

            try
            {
                //获取图像尺寸
                HOperatorSet.GetImageSize(ho_Image, out hv_Width, out hv_Height);
                //产生一个空显示对象，用于显示
                ho_Regions.Dispose();
                HOperatorSet.GenEmptyObj(out ho_Regions);
                //初始化边缘坐标数组
                hv_ResultRow = new HTuple();
                hv_ResultColumn = new HTuple();
                //产生直线xld
                ho_RegionLines.Dispose();
                HOperatorSet.GenContourPolygonXld(out ho_RegionLines, hv_Row1.TupleConcat(hv_Row2),
                    hv_Column1.TupleConcat(hv_Column2));
                //存储到显示对象
                OTemp[SP_O] = ho_Regions.CopyObj(1, -1);
                SP_O++;
                ho_Regions.Dispose();
                HOperatorSet.ConcatObj(OTemp[SP_O - 1], ho_RegionLines, out ho_Regions);
                OTemp[SP_O - 1].Dispose();
                SP_O = 0;
                //计算直线与x轴的夹角，逆时针方向为正向。
                HOperatorSet.AngleLx(hv_Row1, hv_Column1, hv_Row2, hv_Column2, out hv_ATan);

                //边缘检测方向垂直于检测直线：直线方向正向旋转90°为边缘检测方向
                hv_ATan = hv_ATan + ((new HTuple(90)).TupleRad());

                //根据检测直线按顺序产生测量区域矩形，并存储到显示对象
                for (hv_i = 1; hv_i.Continue(hv_Elements, 1); hv_i = hv_i.TupleAdd(1))
                {
                    //RowC := Row1+(((Row2-Row1)*i)/(Elements+1))
                    //ColC := Column1+(Column2-Column1)*i/(Elements+1)
                    //if (RowC>Height-1 or RowC<0 or ColC>Width-1 or ColC<0)
                    //continue
                    //endif
                    //如果只有一个测量矩形，作为卡尺工具，宽度为检测直线的长度
                    if ((int)(new HTuple(hv_Elements.TupleEqual(1))) != 0)
                    {
                        hv_RowC = (hv_Row1 + hv_Row2) * 0.5;
                        hv_ColC = (hv_Column1 + hv_Column2) * 0.5;
                        //判断是否超出图像,超出不检测边缘
                        if ((int)((new HTuple((new HTuple((new HTuple(hv_RowC.TupleGreater(hv_Height - 1))).TupleOr(
                            new HTuple(hv_RowC.TupleLess(0))))).TupleOr(new HTuple(hv_ColC.TupleGreater(
                            hv_Width - 1))))).TupleOr(new HTuple(hv_ColC.TupleLess(0)))) != 0)
                        {
                            continue;
                        }
                        HOperatorSet.DistancePp(hv_Row1, hv_Column1, hv_Row2, hv_Column2, out hv_Distance);
                        hv_DetectWidth_COPY_INP_TMP = hv_Distance.Clone();
                        ho_Rectangle.Dispose();
                        HOperatorSet.GenRectangle2ContourXld(out ho_Rectangle, hv_RowC, hv_ColC,
                            hv_ATan, hv_DetectHeight / 2, hv_Distance / 2);
                    }
                    else
                    {
                        //如果有多个测量矩形，产生该测量矩形xld
                        hv_RowC = hv_Row1 + (((hv_Row2 - hv_Row1) * (hv_i - 1)) / (hv_Elements - 1));
                        hv_ColC = hv_Column1 + (((hv_Column2 - hv_Column1) * (hv_i - 1)) / (hv_Elements - 1));
                        //判断是否超出图像,超出不检测边缘
                        if ((int)((new HTuple((new HTuple((new HTuple(hv_RowC.TupleGreater(hv_Height - 1))).TupleOr(
                            new HTuple(hv_RowC.TupleLess(0))))).TupleOr(new HTuple(hv_ColC.TupleGreater(
                            hv_Width - 1))))).TupleOr(new HTuple(hv_ColC.TupleLess(0)))) != 0)
                        {
                            continue;
                        }
                        ho_Rectangle.Dispose();
                        HOperatorSet.GenRectangle2ContourXld(out ho_Rectangle, hv_RowC, hv_ColC,
                            hv_ATan, hv_DetectHeight / 2, hv_DetectWidth_COPY_INP_TMP / 2);
                    }

                    //把测量矩形xld存储到显示对象
                    //OTemp[SP_O] = ho_Regions.CopyObj(1,-1);
                    //SP_O++;
                    //ho_Regions.Dispose();
                    //HOperatorSet.ConcatObj(OTemp[SP_O-1], ho_Rectangle, out ho_Regions);
                    //OTemp[SP_O-1].Dispose();
                    //SP_O = 0;
                    if ((int)(new HTuple(hv_i.TupleEqual(1))) != 0)
                    {
                        //在第一个测量矩形绘制一个箭头xld，用于只是边缘检测方向
                        hv_RowL2 = hv_RowC + ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleSin()));
                        hv_RowL1 = hv_RowC - ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleSin()));
                        hv_ColL2 = hv_ColC + ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleCos()));
                        hv_ColL1 = hv_ColC - ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleCos()));
                        ho_Arrow1.Dispose();
                        gen_arrow_contour_xld(out ho_Arrow1, hv_RowL1, hv_ColL1, hv_RowL2, hv_ColL2,
                            25, 25);
                        //把xld存储到显示对象
                        OTemp[SP_O] = ho_Regions.CopyObj(1, -1);
                        SP_O++;
                        ho_Regions.Dispose();
                        HOperatorSet.ConcatObj(OTemp[SP_O - 1], ho_Arrow1, out ho_Regions);
                        OTemp[SP_O - 1].Dispose();
                        SP_O = 0;
                    }
                    //产生测量对象句柄
                    HOperatorSet.GenMeasureRectangle2(hv_RowC, hv_ColC, hv_ATan, hv_DetectHeight / 2,
                        hv_DetectWidth_COPY_INP_TMP / 2, hv_Width, hv_Height, "nearest_neighbor",
                        out hv_MsrHandle_Measure);

                    //设置极性
                    if ((int)(new HTuple(hv_Transition_COPY_INP_TMP.TupleEqual("negative"))) != 0)
                    {
                        hv_Transition_COPY_INP_TMP = "negative";
                    }
                    else
                    {
                        if ((int)(new HTuple(hv_Transition_COPY_INP_TMP.TupleEqual("positive"))) != 0)
                        {

                            hv_Transition_COPY_INP_TMP = "positive";
                        }
                        else
                        {
                            hv_Transition_COPY_INP_TMP = "all";
                        }
                    }
                    //设置边缘位置。最强点是从所有边缘中选择幅度绝对值最大点，需要设置为'all'
                    if ((int)(new HTuple(hv_Select_COPY_INP_TMP.TupleEqual("first"))) != 0)
                    {
                        hv_Select_COPY_INP_TMP = "first";
                    }
                    else
                    {
                        if ((int)(new HTuple(hv_Select_COPY_INP_TMP.TupleEqual("last"))) != 0)
                        {

                            hv_Select_COPY_INP_TMP = "last";
                        }
                        else
                        {
                            hv_Select_COPY_INP_TMP = "all";
                        }
                    }
                    //检测边缘
                    HOperatorSet.MeasurePos(ho_Image, hv_MsrHandle_Measure, hv_Sigma, hv_Threshold,
                        hv_Transition_COPY_INP_TMP, hv_Select_COPY_INP_TMP, out hv_RowEdge, out hv_ColEdge,
                        out hv_Amplitude, out hv_Distance);
                    //清除测量对象句柄
                    HOperatorSet.CloseMeasure(hv_MsrHandle_Measure);

                    //临时变量初始化
                    //tRow，tCol保存找到指定边缘的坐标
                    hv_tRow = 0;
                    hv_tCol = 0;
                    //t保存边缘的幅度绝对值
                    hv_t = 0;
                    //找到的边缘必须至少为1个
                    HOperatorSet.TupleLength(hv_RowEdge, out hv_Number);
                    if ((int)(new HTuple(hv_Number.TupleLess(1))) != 0)
                    {
                        continue;
                    }
                    //有多个边缘时，选择幅度绝对值最大的边缘
                    for (hv_j = 0; hv_j.Continue(hv_Number - 1, 1); hv_j = hv_j.TupleAdd(1))
                    {
                        if ((int)(new HTuple(((((hv_Amplitude.TupleSelect(hv_j))).TupleAbs())).TupleGreater(
                            hv_t))) != 0)
                        {

                            hv_tRow = hv_RowEdge.TupleSelect(hv_j);
                            hv_tCol = hv_ColEdge.TupleSelect(hv_j);
                            hv_t = ((hv_Amplitude.TupleSelect(hv_j))).TupleAbs();
                        }
                    }
                    //把找到的边缘保存在输出数组
                    if ((int)(new HTuple(hv_t.TupleGreater(0))) != 0)
                    {
                        hv_ResultRow = hv_ResultRow.TupleConcat(hv_tRow);
                        hv_ResultColumn = hv_ResultColumn.TupleConcat(hv_tCol);
                    }
                }

                ho_RegionLines.Dispose();
                ho_Rectangle.Dispose();
                ho_Arrow1.Dispose();

                return;
            }
            catch (HalconException HDevExpDefaultException)
            {
                ho_RegionLines.Dispose();
                ho_Rectangle.Dispose();
                ho_Arrow1.Dispose();

                throw HDevExpDefaultException;
            }
        }
        public void scale_image_range(HObject ho_Image, out HObject ho_ImageScaled, HTuple hv_Min,
      HTuple hv_Max)
        {



            // Stack for temporary objects 
            HObject[] OTemp = new HObject[20];
            long SP_O = 0;

            // Local iconic variables 

            HObject ho_SelectedChannel = null, ho_LowerRegion = null;
            HObject ho_UpperRegion = null;

            HObject ho_Image_COPY_INP_TMP;
            ho_Image_COPY_INP_TMP = ho_Image.CopyObj(1, -1);


            // Local control variables 

            HTuple hv_LowerLimit = new HTuple(), hv_UpperLimit = new HTuple();
            HTuple hv_Mult, hv_Add, hv_Channels, hv_Index, hv_MinGray = new HTuple();
            HTuple hv_MaxGray = new HTuple(), hv_Range = new HTuple();

            HTuple hv_Max_COPY_INP_TMP = hv_Max.Clone();
            HTuple hv_Min_COPY_INP_TMP = hv_Min.Clone();

            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_ImageScaled);
            HOperatorSet.GenEmptyObj(out ho_SelectedChannel);
            HOperatorSet.GenEmptyObj(out ho_LowerRegion);
            HOperatorSet.GenEmptyObj(out ho_UpperRegion);

            //Convenience procedure to scale the gray values of the
            //input image Image from the interval [Min,Max]
            //to the interval [0,255] (default).
            //Gray values < 0 or > 255 (after scaling) are clipped.
            //
            //If the image shall be scaled to an interval different from [0,255],
            //this can be achieved by passing tuples with 2 values [From, To]
            //as Min and Max.
            //Example:
            //scale_image_range(Image:ImageScaled:[100,50],[200,250])
            //maps the gray values of Image from the interval [100,200] to [50,250].
            //All other gray values will be clipped.
            //
            //input parameters:
            //Image: the input image
            //Min: the minimum gray value which will be mapped to 0
            //     If a tuple with two values is given, the first value will
            //     be mapped to the second value.
            //Max: The maximum gray value which will be mapped to 255
            //     If a tuple with two values is given, the first value will
            //     be mapped to the second value.
            //
            //output parameter:
            //ImageScale: the resulting scaled image
            //
            if ((int)(new HTuple((new HTuple(hv_Min_COPY_INP_TMP.TupleLength())).TupleEqual(
                2))) != 0)
            {
                hv_LowerLimit = hv_Min_COPY_INP_TMP[1];
                hv_Min_COPY_INP_TMP = hv_Min_COPY_INP_TMP[0];
            }
            else
            {
                hv_LowerLimit = 0.0;
            }
            if ((int)(new HTuple((new HTuple(hv_Max_COPY_INP_TMP.TupleLength())).TupleEqual(
                2))) != 0)
            {
                hv_UpperLimit = hv_Max_COPY_INP_TMP[1];
                hv_Max_COPY_INP_TMP = hv_Max_COPY_INP_TMP[0];
            }
            else
            {
                hv_UpperLimit = 255.0;
            }
            //
            //Calculate scaling parameters
            hv_Mult = (((hv_UpperLimit - hv_LowerLimit)).TupleReal()) / (hv_Max_COPY_INP_TMP - hv_Min_COPY_INP_TMP);
            hv_Add = ((-hv_Mult) * hv_Min_COPY_INP_TMP) + hv_LowerLimit;
            //
            //Scale image
            OTemp[SP_O] = ho_Image_COPY_INP_TMP.CopyObj(1, -1);
            SP_O++;
            ho_Image_COPY_INP_TMP.Dispose();
            HOperatorSet.ScaleImage(OTemp[SP_O - 1], out ho_Image_COPY_INP_TMP, hv_Mult, hv_Add);
            OTemp[SP_O - 1].Dispose();
            SP_O = 0;
            //
            //Clip gray values if necessary
            //This must be done for each channel separately
            HOperatorSet.CountChannels(ho_Image_COPY_INP_TMP, out hv_Channels);
            for (hv_Index = 1; hv_Index.Continue(hv_Channels, 1); hv_Index = hv_Index.TupleAdd(1))
            {
                ho_SelectedChannel.Dispose();
                HOperatorSet.AccessChannel(ho_Image_COPY_INP_TMP, out ho_SelectedChannel, hv_Index);
                HOperatorSet.MinMaxGray(ho_SelectedChannel, ho_SelectedChannel, 0, out hv_MinGray,
                    out hv_MaxGray, out hv_Range);
                ho_LowerRegion.Dispose();
                HOperatorSet.Threshold(ho_SelectedChannel, out ho_LowerRegion, ((hv_MinGray.TupleConcat(
                    hv_LowerLimit))).TupleMin(), hv_LowerLimit);
                ho_UpperRegion.Dispose();
                HOperatorSet.Threshold(ho_SelectedChannel, out ho_UpperRegion, hv_UpperLimit,
                    ((hv_UpperLimit.TupleConcat(hv_MaxGray))).TupleMax());
                OTemp[SP_O] = ho_SelectedChannel.CopyObj(1, -1);
                SP_O++;
                ho_SelectedChannel.Dispose();
                HOperatorSet.PaintRegion(ho_LowerRegion, OTemp[SP_O - 1], out ho_SelectedChannel,
                    hv_LowerLimit, "fill");
                OTemp[SP_O - 1].Dispose();
                SP_O = 0;
                OTemp[SP_O] = ho_SelectedChannel.CopyObj(1, -1);
                SP_O++;
                ho_SelectedChannel.Dispose();
                HOperatorSet.PaintRegion(ho_UpperRegion, OTemp[SP_O - 1], out ho_SelectedChannel,
                    hv_UpperLimit, "fill");
                OTemp[SP_O - 1].Dispose();
                SP_O = 0;
                if ((int)(new HTuple(hv_Index.TupleEqual(1))) != 0)
                {
                    ho_ImageScaled.Dispose();
                    HOperatorSet.CopyObj(ho_SelectedChannel, out ho_ImageScaled, 1, 1);
                }
                else
                {
                    OTemp[SP_O] = ho_ImageScaled.CopyObj(1, -1);
                    SP_O++;
                    ho_ImageScaled.Dispose();
                    HOperatorSet.AppendChannel(OTemp[SP_O - 1], ho_SelectedChannel, out ho_ImageScaled
                        );
                    OTemp[SP_O - 1].Dispose();
                    SP_O = 0;
                }
            }
            ho_Image_COPY_INP_TMP.Dispose();
            ho_SelectedChannel.Dispose();
            ho_LowerRegion.Dispose();
            ho_UpperRegion.Dispose();

            return;
        }
      /// <summary>
      /// 显示匹配模板
      /// </summary>
      /// <param name="hv_WindowHandle">WindowHandle</param>
      /// <param name="ho_ContoursAffinTrans">输出轮廓</param>
      /// <param name="hv_ModelID">模板ID</param>
      /// <param name="hv_Color">显示颜色</param>
      /// <param name="hv_Row">行</param>
      /// <param name="hv_Column">列</param>
      /// <param name="hv_Angle">角度</param>
      /// <param name="hv_ScaleR"></param>
      /// <param name="hv_ScaleC"></param>
      /// <param name="hv_Model"></param>
        public  void dev_display_shape_matching_results(HTuple hv_WindowHandle, out HObject ho_ContoursAffinTrans, HTuple hv_ModelID, HTuple hv_Color,
            HTuple hv_Row, HTuple hv_Column, HTuple hv_Angle, HTuple hv_ScaleR, HTuple hv_ScaleC,HTuple hv_Model)
        {
            dev_display_shape_matching_results_static(hv_WindowHandle, out ho_ContoursAffinTrans, hv_ModelID, hv_Color,
              hv_Row, hv_Column,  hv_Angle, hv_ScaleR, hv_ScaleC, hv_Model);
        }
        /// <summary>
        /// 显示匹配结果
        /// </summary>
        /// <param name="hv_WindowHandle">WindowHandle</param>
        /// <param name="ho_ContoursAffinTrans">输出轮廓</param>
        /// <param name="hv_ModelID">模板ID</param>
        /// <param name="hv_Color">轮廓颜色</param>
        /// <param name="hv_Row">匹配结果Row</param>
        /// <param name="hv_Column">匹配结果Col</param>
        /// <param name="hv_Angle">匹配结果的角度</param>
        /// <param name="hv_ScaleR"></param>
        /// <param name="hv_ScaleC"></param>
        /// <param name="hv_Model"></param>
        public static void dev_display_shape_matching_results_static(HTuple hv_WindowHandle, out HObject ho_ContoursAffinTrans, HTuple hv_ModelID, HTuple hv_Color,
    HTuple hv_Row, HTuple hv_Column, HTuple hv_Angle, HTuple hv_ScaleR, HTuple hv_ScaleC, HTuple hv_Model)
        {

            // Local iconic variables 

            HObject ho_ModelContours = null;


            // Local control variables 

            HTuple hv_NumMatches, hv_Index = new HTuple();
            HTuple hv_Match = new HTuple(), hv_HomMat2DIdentity = new HTuple();
            HTuple hv_HomMat2DScale = new HTuple(), hv_HomMat2DRotate = new HTuple();
            HTuple hv_HomMat2DTranslate = new HTuple();

            HTuple hv_Model_COPY_INP_TMP = hv_Model.Clone();
            HTuple hv_ScaleC_COPY_INP_TMP = hv_ScaleC.Clone();
            HTuple hv_ScaleR_COPY_INP_TMP = hv_ScaleR.Clone();

            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_ModelContours);
            HOperatorSet.GenEmptyObj(out ho_ContoursAffinTrans);

            //This procedure displays the results of Shape-Based Matching.
            //
            hv_NumMatches = new HTuple(hv_Row.TupleLength());
            if ((int)(new HTuple(hv_NumMatches.TupleGreater(0))) != 0)
            {
                if ((int)(new HTuple((new HTuple(hv_ScaleR_COPY_INP_TMP.TupleLength())).TupleEqual(
                    1))) != 0)
                {
                    HOperatorSet.TupleGenConst(hv_NumMatches, hv_ScaleR_COPY_INP_TMP, out hv_ScaleR_COPY_INP_TMP);
                }
                if ((int)(new HTuple((new HTuple(hv_ScaleC_COPY_INP_TMP.TupleLength())).TupleEqual(
                    1))) != 0)
                {
                    HOperatorSet.TupleGenConst(hv_NumMatches, hv_ScaleC_COPY_INP_TMP, out hv_ScaleC_COPY_INP_TMP);
                }
                if ((int)(new HTuple((new HTuple(hv_Model_COPY_INP_TMP.TupleLength())).TupleEqual(
                    0))) != 0)
                {
                    HOperatorSet.TupleGenConst(hv_NumMatches, 0, out hv_Model_COPY_INP_TMP);
                }
                else if ((int)(new HTuple((new HTuple(hv_Model_COPY_INP_TMP.TupleLength()
                    )).TupleEqual(1))) != 0)
                {
                    HOperatorSet.TupleGenConst(hv_NumMatches, hv_Model_COPY_INP_TMP, out hv_Model_COPY_INP_TMP);
                }
                for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_ModelID.TupleLength())) - 1); hv_Index = (int)hv_Index + 1)
                {
                    ho_ModelContours.Dispose();
                    HOperatorSet.GetShapeModelContours(out ho_ModelContours, hv_ModelID.TupleSelect(
                        hv_Index), 1);
                    HOperatorSet.SetColor(hv_WindowHandle, hv_Color.TupleSelect(
                        hv_Index % (new HTuple(hv_Color.TupleLength()))));
                    for (hv_Match = 0; hv_Match.Continue(hv_NumMatches - 1, 1); hv_Match = hv_Match.TupleAdd(1))
                    {
                        if ((int)(new HTuple(hv_Index.TupleEqual(hv_Model_COPY_INP_TMP.TupleSelect(
                            hv_Match)))) != 0)
                        {
                            HOperatorSet.HomMat2dIdentity(out hv_HomMat2DIdentity);
                            HOperatorSet.HomMat2dScale(hv_HomMat2DIdentity, hv_ScaleR_COPY_INP_TMP.TupleSelect(
                                hv_Match), hv_ScaleC_COPY_INP_TMP.TupleSelect(hv_Match), 0, 0, out hv_HomMat2DScale);
                            HOperatorSet.HomMat2dRotate(hv_HomMat2DScale, hv_Angle.TupleSelect(hv_Match),
                                0, 0, out hv_HomMat2DRotate);
                            HOperatorSet.HomMat2dTranslate(hv_HomMat2DRotate, hv_Row.TupleSelect(
                                hv_Match), hv_Column.TupleSelect(hv_Match), out hv_HomMat2DTranslate);
                            ho_ContoursAffinTrans.Dispose();
                            HOperatorSet.AffineTransContourXld(ho_ModelContours, out ho_ContoursAffinTrans,
                                hv_HomMat2DTranslate);
                           // HOperatorSet.DispObj(ho_ContoursAffinTrans, hv_WindowHandle);
                        }
                    }
                }
            }
            ho_ModelContours.Dispose();
            //ho_ContoursAffinTrans.Dispose();

            return;
        }

        /// <summary>
        /// 拟合直线
        /// </summary>
        /// <param name="ho_Line">输出直线region</param>
        /// <param name="hv_Rows">输入行</param>
        /// <param name="hv_Cols">输入列</param>
        /// <param name="hv_ActiveNum">最小拟合数量</param>
        /// <param name="hv_Row1">直线数据</param>
        /// <param name="hv_Column1">直线数据</param>
        /// <param name="hv_Row2">直线数据</param>
        /// <param name="hv_Column2">直线数据</param>
        public void pts_to_best_line(out HObject ho_Line, HTuple hv_Rows, HTuple hv_Cols,
            HTuple hv_ActiveNum, out HTuple hv_Row1, out HTuple hv_Column1, out HTuple hv_Row2,
            out HTuple hv_Column2)
        {
            HObject ho_Contour = null;


            // Local control variables 

            HTuple hv_Length, hv_Nr = new HTuple(), hv_Nc = new HTuple();
            HTuple hv_Dist = new HTuple(), hv_Length1 = new HTuple();

            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Line);
            HOperatorSet.GenEmptyObj(out ho_Contour);

            //初始化
            hv_Row1 = 0;
            hv_Column1 = 0;
            hv_Row2 = 0;
            hv_Column2 = 0;
            //产生一个空的直线对象，用于保存拟合后的直线
            ho_Line.Dispose();
            HOperatorSet.GenEmptyObj(out ho_Line);
            //计算边缘数量
            HOperatorSet.TupleLength(hv_Cols, out hv_Length);
            //当边缘数量不小于有效点数时进行拟合
            if ((int)((new HTuple(hv_Length.TupleGreaterEqual(hv_ActiveNum))).TupleAnd(new HTuple(hv_ActiveNum.TupleGreater(
                1)))) != 0)
            {
                //halcon的拟合是基于xld的，需要把边缘连接成xld
                ho_Contour.Dispose();
                HOperatorSet.GenContourPolygonXld(out ho_Contour, hv_Rows, hv_Cols);
                //拟合直线。使用的算法是'tukey'，其他算法请参考fit_line_contour_xld的描述部分。
                HOperatorSet.FitLineContourXld(ho_Contour, "tukey", -1, 0, 5, 2, out hv_Row1,
                    out hv_Column1, out hv_Row2, out hv_Column2, out hv_Nr, out hv_Nc, out hv_Dist);
                //判断拟合结果是否有效：如果拟合成功，数组中元素的数量大于0
                HOperatorSet.TupleLength(hv_Dist, out hv_Length1);
                if ((int)(new HTuple(hv_Length1.TupleLess(1))) != 0)
                {
                    ho_Contour.Dispose();

                    return;
                }
                //根据拟合结果，产生直线xld
                ho_Line.Dispose();
                HOperatorSet.GenContourPolygonXld(out ho_Line, hv_Row1.TupleConcat(hv_Row2),
                    hv_Column1.TupleConcat(hv_Column2));
            }

            ho_Contour.Dispose();

            return;
        }

        private delegate bool ShowImageDelegat(HObject showImage, HTuple showWindow, bool assistLine = false, HObject showRegion = null, HObject showContour = null, HObject fitRegion = null, HTuple fitRow = null, HTuple fitCol = null);
        ShowImageDelegat show = null;
        /// <summary>
        /// 显示图片
        /// </summary>
        /// <param name="showImage">显示图像</param>
        /// <param name="showWindow">显示窗口</param>
        /// <param name="showRegion">显示区域</param>
        /// <param name="showContour">显示轮廓</param>
        /// <param name="assistLine">是否显示辅助线</param>
        /// <returns></returns>
     
        private bool ShowImageFunction(HObject showImage, HTuple showWindow, bool assistLine = false, HObject showRegion = null, HObject showContour = null, HObject fitRegion = null, HTuple fitRow = null, HTuple fitCol = null)
        {
            bool result = false;
            try
            {
                //if (hoImage == null || hoImage.CountObj() <= 0)
                //    return false;
                //HObject showImage = null;
                //HOperatorSet.GenEmptyObj(out showImage);
                //HOperatorSet.CopyImage(hoImage, out showImage);
                //MessageBox.Show("当前线程ID为：" + Thread.CurrentThread.ManagedThreadId + "是否为后台线程？" + Thread.CurrentThread.IsBackground);//显示当前的线程的ID
                HOperatorSet.DispImage(showImage, showWindow);
                //`HOperatorSet.DispObj(showImage, showWindow);
                HOperatorSet.SetDraw(showWindow, "margin");
                //showImage.Dispose();
                try
                {
                    if (assistLine)
                    {
                        HOperatorSet.SetColor(showWindow, "yellow");
                        HTuple row1, col1, row2, col2;
                        HOperatorSet.GetPart(showWindow, out row1, out col1, out row2, out col2);
                        HOperatorSet.DispCross(showWindow, (row1 + row2) / 2, (col1 + col2) / 2, 8000, 0);
                    }
                }
                catch (Exception e2)
                {
                    System.Diagnostics.Trace.WriteLine(e2.Message);
                }
                try
                {
                    if (showRegion != null)
                    {
                        HOperatorSet.SetColor(showWindow, "green");
                        HOperatorSet.DispObj(showRegion, showWindow);
                    }
                    result = true;
                }
                catch (Exception e1)
                {
                    System.Diagnostics.Trace.WriteLine(e1.Message);
                }
                try
                {
                    if (showContour != null)
                    {
                        HOperatorSet.SetColor(showWindow, HalconPackage.ContourColor);
                        HOperatorSet.DispObj(showContour, showWindow);
                    }
                }
                catch (Exception e2)
                {
                    System.Diagnostics.Trace.WriteLine(e2.Message);
                }
                try
                {
                    if (fitRegion != null)
                    {
                        HOperatorSet.SetColor(showWindow, "blue");
                        HOperatorSet.DispObj(fitRegion, showWindow);
                    }
                }
                catch (Exception e2)
                {
                    System.Diagnostics.Trace.WriteLine(e2.Message);
                }
                try
                {
                    if (fitRow != null && fitCol != null)
                    {
                        HOperatorSet.SetColor(showWindow, "orange");
                        HOperatorSet.DispCross(showWindow, fitRow, fitCol, 35, 0);
                    }
                }
                catch (Exception e2)
                {
                    System.Diagnostics.Trace.WriteLine(e2.Message);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// 数据结构
        /// </summary>
        public struct Class_ProcessResult
        {
            public bool status;
            public bool multModel;
///////////模板匹配后后结果   ///////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>
            /// 匹配结果行
            /// </summary>
            public double Row;
            /// <summary>
            /// 匹配结果列
            /// </summary>
            public double Col;
            /// <summary>
            /// 匹配结果角度
            /// </summary>
            public double Angle;
            public double Angle_弧度;
            public double Area;
            /// <summary>
            /// 匹配得分
            /// </summary>
            public double Score;
            /// <summary>
            /// 匹配拟合中心点行
            /// </summary>
            public double FitRow;
            /// <summary>
            /// 匹配拟合中心点
            /// </summary>
            public double FitCol;


            /// <summary>
            /// 标定校正后新模板位置
            /// </summary>
            public double X;         //计算后新模板位置
            /// <summary>
            /// 标定校正后新模板位置
            /// </summary>
            public double Y;         //计算后新模板位置
            /// <summary>
            /// 模板基准位置
            /// </summary>                  
            public double ModelX;    //模板基准位置
            /// <summary>
            /// 模板基准位置
            /// </summary>
            public double ModelY;    //模板基准位置

            /// <summary>
            /// 标定校正后新拟合位置
            /// </summary>
            public double FitX;
            /// <summary>
            /// 标定校正后新拟合位置
            /// </summary>
            public double FitY;      
            /// <summary>
            /// 模板基准位置行
            /// </summary>
            public double ModelRow;
            /// <summary>
            /// 模板基准位置列
            /// </summary>
            public double ModelCol;

            /// <summary>
            /// 拟合基准位置
            /// </summary>
            public double ModelFitX; //拟合基准位置
            /// <summary>
            /// 拟合基准位置
            /// </summary>
            public double ModelFitY; //拟合基准位置

            public int Index;
            public int Count;
            /// <summary>
            /// 多个匹配结果保存值
            /// </summary>
            public double[] m_X;
            public double[] m_Y;
            public double[] m_Row;
            public double[] m_Col;
            public double[] m_Angle;
            public double[] m_Score;
            //public double WorldAngle;
            //public double WorldArea;
            public void New(int count)
            {
                if (multModel)
                {
                    Index = 0;
                    Count = count;
                    m_X = m_Y = m_Row = m_Col = m_Angle = m_Score = new double[Count];
                    for (int i = 0; i < Count; i++)
                    {
                        m_X[i] = m_Y[i] = m_Row[i] = m_Col[i] = m_Angle[i] = m_Score[i] = 0;
                    }
                }
            }
            public void Plus()
            {
                if (multModel)
                {
                    X = m_X[Index];
                    Y = m_Y[Index];
                    Row = m_Row[Index];
                    Col = m_Col[Index];
                    Angle = m_Angle[Index];
                    Score = m_Score[Index];
                    Index++;
                    if (Index >= Count)
                    {
                        Index = 0;
                    }
                }
            }
            public void Dispose()
            {
                status = false;
                Row = Col = Angle = Area = X = Y = Score = FitRow = FitCol = ModelRow = ModelCol = ModelX = ModelY = FitX = FitY = 0;
                m_X = m_Y = m_Row = m_Col = m_Angle = m_Score = null;
                Index = Count = 0;
                //WorldAngle = WorldArea = Mark_X = Mark_Y = 0;
            }
        }
        public static bool VD_Get_Hom_Mat_2D_9Point(
                                          HTuple hv_image_x1, HTuple hv_image_y1,
                                          HTuple hv_image_x2, HTuple hv_image_y2,
                                          HTuple hv_image_x3, HTuple hv_image_y3,
                                          HTuple hv_image_x4, HTuple hv_image_y4,
                                          HTuple hv_image_x5, HTuple hv_image_y5,
                                          HTuple hv_image_x6, HTuple hv_image_y6,
                                          HTuple hv_image_x7, HTuple hv_image_y7,
                                          HTuple hv_image_x8, HTuple hv_image_y8,
                                          HTuple hv_image_x9, HTuple hv_image_y9,
                                          HTuple hv_machine_x1, HTuple hv_machine_y1,
                                          HTuple hv_machine_x2, HTuple hv_machine_y2,
                                          HTuple hv_machine_x3, HTuple hv_machine_y3,
                                          HTuple hv_machine_x4, HTuple hv_machine_y4,
                                          HTuple hv_machine_x5, HTuple hv_machine_y5,
                                          HTuple hv_machine_x6, HTuple hv_machine_y6,
                                          HTuple hv_machine_x7, HTuple hv_machine_y7,
                                          HTuple hv_machine_x8, HTuple hv_machine_y8,
                                          HTuple hv_machine_x9, HTuple hv_machine_y9,
                                          out HTuple hv_HomMat2D)
        {

            HTuple hv_px = null;
            HTuple hv_py = null;
            HTuple hv_qx = null;
            HTuple hv_qy = null;
            hv_px = ((((((((((((((hv_image_x1.TupleConcat(hv_image_x2))).TupleConcat(hv_image_x3))).TupleConcat(
                     hv_image_x4))).TupleConcat(hv_image_x5))).TupleConcat(hv_image_x6))).TupleConcat(
                     hv_image_x7))).TupleConcat(hv_image_x8))).TupleConcat(hv_image_x9);
            hv_py = ((((((((((((((hv_image_y1.TupleConcat(hv_image_y2))).TupleConcat(hv_image_y3))).TupleConcat(
                hv_image_y4))).TupleConcat(hv_image_y5))).TupleConcat(hv_image_y6))).TupleConcat(
                hv_image_y7))).TupleConcat(hv_image_y8))).TupleConcat(hv_image_y9);
            hv_qx = ((((((((((((((hv_machine_x1.TupleConcat(hv_machine_x2))).TupleConcat(hv_machine_x3))).TupleConcat(
                hv_machine_x4))).TupleConcat(hv_machine_x5))).TupleConcat(hv_machine_x6))).TupleConcat(
                hv_machine_x7))).TupleConcat(hv_machine_x8))).TupleConcat(hv_machine_x9);
            hv_qy = ((((((((((((((hv_machine_y1.TupleConcat(hv_machine_y2))).TupleConcat(hv_machine_y3))).TupleConcat(
                hv_machine_y4))).TupleConcat(hv_machine_y5))).TupleConcat(hv_machine_y6))).TupleConcat(
                hv_machine_y7))).TupleConcat(hv_machine_y8))).TupleConcat(hv_machine_y9);

            HOperatorSet.VectorToHomMat2d(hv_px, hv_py, hv_qx, hv_qy, out hv_HomMat2D);
            return true;
        }
        /// <summary>
        ///保存Hom_Mat_2D参数：9点标定
        /// </summary>
        /// <param name="hv_saveFileName">保存的文件名</param>
        /// <param name="hv_image_x1"></param>
        /// <param name="hv_image_y1"></param>
        /// <param name="hv_image_x2"></param>
        /// <param name="hv_image_y2"></param>
        /// <param name="hv_image_x3"></param>
        /// <param name="hv_image_y3"></param>
        /// <param name="hv_image_x4"></param>
        /// <param name="hv_image_y4"></param>
        /// <param name="hv_image_x5"></param>
        /// <param name="hv_image_y5"></param>
        /// <param name="hv_image_x6"></param>
        /// <param name="hv_image_y6"></param>
        /// <param name="hv_image_x7"></param>
        /// <param name="hv_image_y7"></param>
        /// <param name="hv_image_x8"></param>
        /// <param name="hv_image_y8"></param>
        /// <param name="hv_image_x9"></param>
        /// <param name="hv_image_y9"></param>
        /// <param name="hv_machine_x1"></param>
        /// <param name="hv_machine_y1"></param>
        /// <param name="hv_machine_x2"></param>
        /// <param name="hv_machine_y2"></param>
        /// <param name="hv_machine_x3"></param>
        /// <param name="hv_machine_y3"></param>
        /// <param name="hv_machine_x4"></param>
        /// <param name="hv_machine_y4"></param>
        /// <param name="hv_machine_x5"></param>
        /// <param name="hv_machine_y5"></param>
        /// <param name="hv_machine_x6"></param>
        /// <param name="hv_machine_y6"></param>
        /// <param name="hv_machine_x7"></param>
        /// <param name="hv_machine_y7"></param>
        /// <param name="hv_machine_x8"></param>
        /// <param name="hv_machine_y8"></param>
        /// <param name="hv_machine_x9"></param>
        /// <param name="hv_machine_y9"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool VD_Save_Hom_Mat_2D_9Point(HTuple hv_saveFileName,
                                                  HTuple hv_image_x1, HTuple hv_image_y1,
                                                  HTuple hv_image_x2, HTuple hv_image_y2,
                                                  HTuple hv_image_x3, HTuple hv_image_y3,
                                                  HTuple hv_image_x4, HTuple hv_image_y4,
                                                  HTuple hv_image_x5, HTuple hv_image_y5,
                                                  HTuple hv_image_x6, HTuple hv_image_y6,
                                                  HTuple hv_image_x7, HTuple hv_image_y7,
                                                  HTuple hv_image_x8, HTuple hv_image_y8,
                                                  HTuple hv_image_x9, HTuple hv_image_y9,
                                                  HTuple hv_machine_x1, HTuple hv_machine_y1,
                                                  HTuple hv_machine_x2, HTuple hv_machine_y2,
                                                  HTuple hv_machine_x3, HTuple hv_machine_y3,
                                                  HTuple hv_machine_x4, HTuple hv_machine_y4,
                                                  HTuple hv_machine_x5, HTuple hv_machine_y5,
                                                  HTuple hv_machine_x6, HTuple hv_machine_y6,
                                                  HTuple hv_machine_x7, HTuple hv_machine_y7,
                                                  HTuple hv_machine_x8, HTuple hv_machine_y8,
                                                  HTuple hv_machine_x9, HTuple hv_machine_y9
                                                 )
        {

            HTuple hv_px = null;
            HTuple hv_py = null;
            HTuple hv_qx = null;
            HTuple hv_qy = null;
            HTuple hv_HomMat2D = null;

            hv_px = ((((((((((((((hv_image_x1.TupleConcat(hv_image_x2))).TupleConcat(hv_image_x3))).TupleConcat(
                     hv_image_x4))).TupleConcat(hv_image_x5))).TupleConcat(hv_image_x6))).TupleConcat(
                     hv_image_x7))).TupleConcat(hv_image_x8))).TupleConcat(hv_image_x9);
            hv_py = ((((((((((((((hv_image_y1.TupleConcat(hv_image_y2))).TupleConcat(hv_image_y3))).TupleConcat(
                hv_image_y4))).TupleConcat(hv_image_y5))).TupleConcat(hv_image_y6))).TupleConcat(
                hv_image_y7))).TupleConcat(hv_image_y8))).TupleConcat(hv_image_y9);
            hv_qx = ((((((((((((((hv_machine_x1.TupleConcat(hv_machine_x2))).TupleConcat(hv_machine_x3))).TupleConcat(
                hv_machine_x4))).TupleConcat(hv_machine_x5))).TupleConcat(hv_machine_x6))).TupleConcat(
                hv_machine_x7))).TupleConcat(hv_machine_x8))).TupleConcat(hv_machine_x9);
            hv_qy = ((((((((((((((hv_machine_y1.TupleConcat(hv_machine_y2))).TupleConcat(hv_machine_y3))).TupleConcat(
                hv_machine_y4))).TupleConcat(hv_machine_y5))).TupleConcat(hv_machine_y6))).TupleConcat(
                hv_machine_y7))).TupleConcat(hv_machine_y8))).TupleConcat(hv_machine_y9);

            HOperatorSet.VectorToHomMat2d(hv_px, hv_py, hv_qx, hv_qy, out hv_HomMat2D);
            HOperatorSet.WriteTuple(hv_HomMat2D, hv_saveFileName);
            return true;
        }


        /// <summary>
        ///保存Hom_Mat_2D参数：3点标定
        ///</summary>
        ///<param name="hv_saveFileName"></param>
        ///<param name="hv_image_x1"></param>
        ///<param name="hv_image_y1"></param>
        ///<param name="hv_image_x2"></param>
        ///<param name="hv_image_y2"></param>
        ///<param name="hv_image_x3"></param>
        ///<param name="hv_image_y3"></param>
        ///<param name="hv_machine_x1"></param>
        ///<param name="hv_machine_y1"></param>
        ///<param name="hv_machine_x2"></param>
        ///<param name="hv_machine_y2"></param>
        ///<param name="hv_machine_x3"></param>
        ///<param name="hv_machine_y3"></param>
        ///<returns></returns>
        ///<remarks></remarks>
        public static bool VD_Save_Hom_Mat_2D_3Point(HTuple hv_saveFileName,
                                                     HTuple hv_image_x1, HTuple hv_image_y1,
                                                     HTuple hv_image_x2, HTuple hv_image_y2,
                                                     HTuple hv_image_x3, HTuple hv_image_y3,
                                                     HTuple hv_machine_x1, HTuple hv_machine_y1,
                                                     HTuple hv_machine_x2, HTuple hv_machine_y2,
                                                     HTuple hv_machine_x3, HTuple hv_machine_y3
                                                    )
        {

            HTuple hv_px = null;
            HTuple hv_py = null;
            HTuple hv_qx = null;
            HTuple hv_qy = null;
            HTuple hv_HomMat2D = null;

            hv_px = ((hv_image_x1.TupleConcat(hv_image_x2))).TupleConcat(hv_image_x3);
            hv_py = ((hv_image_y1.TupleConcat(hv_image_y2))).TupleConcat(hv_image_y3);
            hv_qx = ((hv_machine_x1.TupleConcat(hv_machine_x2))).TupleConcat(hv_machine_x3);
            hv_qy = ((hv_machine_y1.TupleConcat(hv_machine_y2))).TupleConcat(hv_machine_y3);

            HOperatorSet.VectorToHomMat2d(hv_px, hv_py, hv_qx, hv_qy, out hv_HomMat2D);
            HOperatorSet.WriteTuple(hv_HomMat2D, hv_saveFileName);
            return true;
        }

        public static bool VD_Save_Hom_Mat_2D_3Point(out HTuple hv_HomMat2D,
                                     HTuple hv_image_x1, HTuple hv_image_y1,
                                     HTuple hv_image_x2, HTuple hv_image_y2,
                                     HTuple hv_image_x3, HTuple hv_image_y3,
                                     HTuple hv_machine_x1, HTuple hv_machine_y1,
                                     HTuple hv_machine_x2, HTuple hv_machine_y2,
                                     HTuple hv_machine_x3, HTuple hv_machine_y3
                                    )
        {

            HTuple hv_px = null;
            HTuple hv_py = null;
            HTuple hv_qx = null;
            HTuple hv_qy = null;

            hv_px = ((hv_image_x1.TupleConcat(hv_image_x2))).TupleConcat(hv_image_x3);
            hv_py = ((hv_image_y1.TupleConcat(hv_image_y2))).TupleConcat(hv_image_y3);
            hv_qx = ((hv_machine_x1.TupleConcat(hv_machine_x2))).TupleConcat(hv_machine_x3);
            hv_qy = ((hv_machine_y1.TupleConcat(hv_machine_y2))).TupleConcat(hv_machine_y3);

            HOperatorSet.VectorToHomMat2d(hv_px, hv_py, hv_qx, hv_qy, out hv_HomMat2D);
            return true;
        }

        /// <summary>
        ///保存Hom_Mat_2D参数：2对角点标定
        ///</summary>
        ///<param name="hv_saveFileName"></param>
        ///<param name="hv_image_x1"></param>
        ///<param name="hv_image_y1"></param>
        ///<param name="hv_image_x2"></param>
        ///<param name="hv_image_y2"></param>
        ///<param name="hv_machine_x1"></param>
        ///<param name="hv_machine_y1"></param>
        ///<param name="hv_machine_x2"></param>
        ///<param name="hv_machine_y2"></param>
        ///<returns></returns>
        ///<remarks></remarks>
        public static bool VD_Save_Hom_Mat_2D_2Point(HTuple hv_saveFileName,
                                                     HTuple hv_image_x1, HTuple hv_image_y1,
                                                     HTuple hv_image_x2, HTuple hv_image_y2,
                                                     HTuple hv_machine_x1, HTuple hv_machine_y1,
                                                     HTuple hv_machine_x2, HTuple hv_machine_y2
                                                    )
        {

            HTuple hv_px = null;
            HTuple hv_py = null;
            HTuple hv_qx = null;
            HTuple hv_qy = null;
            HTuple hv_HomMat2D = null;

            hv_px = ((hv_image_x1.TupleConcat(hv_image_x2)));
            hv_py = ((hv_image_y1.TupleConcat(hv_image_y2)));
            hv_qx = ((hv_machine_x1.TupleConcat(hv_machine_x2)));
            hv_qy = ((hv_machine_y1.TupleConcat(hv_machine_y2)));

            HOperatorSet.VectorToHomMat2d(hv_px, hv_py, hv_qx, hv_qy, out hv_HomMat2D);
            HOperatorSet.WriteTuple(hv_HomMat2D, hv_saveFileName);
            return true;
        }

        public static bool VD_Save_Hom_Mat_2D_2Point(out HTuple hv_HomMat2D,
                                             HTuple hv_image_x1, HTuple hv_image_y1,
                                             HTuple hv_image_x2, HTuple hv_image_y2,
                                             HTuple hv_machine_x1, HTuple hv_machine_y1,
                                             HTuple hv_machine_x2, HTuple hv_machine_y2
                                            )
        {

            HTuple hv_px = null;
            HTuple hv_py = null;
            HTuple hv_qx = null;
            HTuple hv_qy = null;

            hv_px = ((hv_image_x1.TupleConcat(hv_image_x2)));
            hv_py = ((hv_image_y1.TupleConcat(hv_image_y2)));
            hv_qx = ((hv_machine_x1.TupleConcat(hv_machine_x2)));
            hv_qy = ((hv_machine_y1.TupleConcat(hv_machine_y2)));
            HOperatorSet.VectorToRigid(hv_px, hv_py, hv_qx, hv_qy, out hv_HomMat2D);
          //HOperatorSet.VectorToHomMat2d(hv_px, hv_py, hv_qx, hv_qy, out hv_HomMat2D);
            return true;
        }

        /// <summary>
        ///保存Hom_Mat_2D参数：N点标定
        ///</summary>
        ///<param name="hv_saveFileName"></param>
        ///<param name="hv_image_x1"></param>
        ///<param name="hv_image_y1"></param>
        ///<param name="hv_image_x2"></param>
        ///<param name="hv_image_y2"></param>
        ///<param name="hv_machine_x1"></param>
        ///<param name="hv_machine_y1"></param>
        ///<param name="hv_machine_x2"></param>
        ///<param name="hv_machine_y2"></param>
        ///<returns></returns>
        ///<remarks></remarks>
        public static bool VD_save_Hom_Mat_2D_NPoint(HTuple hv_saveFileName,
                                                     HTuple hv_px, HTuple hv_py,
                                                     HTuple hv_qx, HTuple hv_qy
                                                    )
        {
            HTuple hv_HomMat2D = null;

            HOperatorSet.VectorToHomMat2d(hv_px, hv_py, hv_qx, hv_qy, out hv_HomMat2D);
            HOperatorSet.WriteTuple(hv_HomMat2D, hv_saveFileName);
            return true;
        }
        /// <summary>
        /// 模板匹配
        /// </summary>
        /// <param name="ho_SearchImage">需要模板匹配的图像</param>
        /// <param name="hv_ModelID">模板ID</param>
        /// <param name="hv_MinScore">最小模板匹配分数</param>
        /// <param name="hv_RowCheck">模板的Row</param>
        /// <param name="hv_ColumnCheck">模板的Col</param>
        /// <param name="hv_AngleCheck">模板的Angle(弧度输出)</param>
        /// <param name="hv_Score">模板的Score</param>
        /// <param name="hv_AngleStart">模板的查找起始角度</param>
        /// <param name="hv_AngleExtend">模板的查找角度范围</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool MatchTemplate(HObject ho_SearchImage,
                                         HTuple hv_ModelID,
                                         HTuple hv_MinScore,
                                         out HTuple hv_RowCheck,
                                         out HTuple hv_ColumnCheck,
                                         out HTuple hv_AngleCheck,
                                         out HTuple hv_Score,
                                         double hv_AngleStart ,
                                         double hv_AngleExtend ,
                                         double hv_AngleStep = 0,//"Auto",
                                         int numMatches = 1)
        {
            HTuple hv_TmpMinScore = hv_MinScore;
            if (hv_MinScore.D > 0.3)
                hv_TmpMinScore = hv_MinScore - 0.3;

            HOperatorSet.FindShapeModel(ho_SearchImage, hv_ModelID, (new HTuple(hv_AngleStart)).TupleRad(), 
                                       (new HTuple(hv_AngleExtend)).TupleRad(), hv_TmpMinScore, new HTuple(numMatches), 
                                        new HTuple(0.5), new HTuple("least_squares"),
                                        new HTuple(4), new HTuple(0.7), out hv_RowCheck, out hv_ColumnCheck, out hv_AngleCheck, out hv_Score);
            if (hv_Score.TupleLength() > 0)
                return hv_Score >= hv_MinScore;
            else
                return false;      
            //********** Function  End  *********** *
        }
        /// <summary>
        /// 模板匹配
        /// </summary>
        /// <param name="ho_SearchImage">需要模板匹配的图像</param>
        /// <param name="hv_ModelID">模板ID</param>
        /// <param name="hv_MinScore">最小模板匹配分数</param>
        /// <param name="hv_ModelRow">模板的Row</param>
        /// <param name="hv_ModelCol">模板的Col</param>
        /// <param name="hv_ModelFitRow"></param>
        /// <param name="hv_ModelFitCol"></param>
        /// <param name="hv_RowCheck"></param>
        /// <param name="hv_ColumnCheck"></param>
        /// <param name="hv_AngleCheck">模板的Angle(弧度输出)</param>
        /// <param name="hv_Score">模板的Score</param>
        /// <param name="hv_FitRowCheck"></param>
        /// <param name="hv_FitColCheck"></param>
        /// <param name="hv_AngleStart">模板的查找起始角度</param>
        /// <param name="hv_AngleExtend">模板的查找角度范围</param>
        /// <param name="hv_AngleStep"></param>
        /// <param name="numMatches"></param>
        /// <returns></returns>
        public static bool MatchTemplate(HObject ho_SearchImage,
                                         HTuple hv_ModelID,
                                         HTuple hv_MinScore,
                                         HTuple hv_ModelRow, HTuple hv_ModelCol, HTuple hv_ModelFitRow, HTuple hv_ModelFitCol,
                                         out HTuple hv_RowCheck,
                                         out HTuple hv_ColumnCheck,
                                         out HTuple hv_AngleCheck,
                                         out HTuple hv_Score,
                                         out HTuple hv_FitRowCheck,
                                         out HTuple hv_FitColCheck,
                                         double hv_AngleStart ,
                                         double hv_AngleExtend,
                                         double hv_AngleStep = 0,//"Auto",
                                         int numMatches = 1)
        {
            HalconPackage.MatchTemplate(ho_SearchImage,
                                        hv_ModelID,
                                        hv_MinScore,
                                        out hv_RowCheck,
                                        out hv_ColumnCheck,
                                        out hv_AngleCheck,
                                        out hv_Score,
                                        hv_AngleStart,
                                        hv_AngleExtend,
                                        0,
                                        numMatches: numMatches);
            hv_FitRowCheck = hv_RowCheck;
            hv_FitColCheck = hv_ColumnCheck;
            if (hv_Score.TupleLength() > 0 && hv_Score >= hv_MinScore)
            {
                //if (hv_ModelFitRow.D != 0 && hv_ModelFitCol.D != 0)
                //{
                //    HTuple tempHommat = new HTuple();
                //    HOperatorSet.VectorAngleToRigid(hv_ModelRow, hv_ModelCol, 0, hv_RowCheck, hv_ColumnCheck, hv_AngleCheck, out tempHommat);
                //    HOperatorSet.AffineTransPixel(tempHommat, hv_ModelFitRow, hv_ModelFitCol, out hv_FitRowCheck, out hv_FitColCheck);
                //}
                return true;
            }
            else
                return false;
            //********** Function  End  *********** *
            //todo: 计算之后,    hv_FitRowCheck = hv_RowCheck;     应该相等
            //                   hv_FitColCheck = hv_ColumnCheck;  应该相等  
        }
    

        /// <summary>
        /// 比例缩放模板匹配
        /// </summary>
        /// <param name="ho_SearchImage">需要匹配的图像</param>
        /// <param name="hv_ModelID">模板ID</param>
        /// <param name="hv_MinScore">最低模板匹配分数</param>
        /// <param name="hv_RowCheck">匹配模板的图像行坐标</param>
        /// <param name="hv_ColumnCheck">匹配模板的图像列坐标</param>
        /// <param name="hv_AngleCheck">匹配模板的角度坐标</param>
        /// <param name="hv_Scale">匹配模板的比例</param>
        /// <param name="hv_Score">匹配模板的分数</param>
        /// <param name="hv_AngleStart">模板搜索的起始角度</param>
        /// <param name="hv_AngleExtend">模板搜索的角度范围</param>
        /// <param name="hv_ScaledMin">模板搜索的最小缩放</param>
        /// <param name="hv_ScaledMax">模板搜索的最大缩放</param>
        /// <returns>True: 模板匹配完成
        /// False: 无法找到模板</returns>
        /// <remarks></remarks>
        public static bool Match_ScaledTemplate(HObject ho_SearchImage,
                        HTuple hv_ModelID,
                        HTuple hv_MinScore,
                        out HTuple hv_RowCheck,
                        out HTuple hv_ColumnCheck,
                        out HTuple hv_AngleCheck,
                        out HTuple hv_Scale,
                        out HTuple hv_Score,
                        double hv_AngleStart = -180,
                        double hv_AngleExtend = 360,
                        double hv_AngleStep = 0,//"Auto",
                        double hv_ScaledMin = 0.2,
                        double hv_ScaledMax = 2.0,
                        int numMatches = 1)
        {

            HTuple hv_TmpMinScore = hv_MinScore;
            if (hv_MinScore.D > 0.3)
                hv_TmpMinScore = hv_MinScore - 0.3;

            HOperatorSet.FindScaledShapeModel( ho_SearchImage,
                                               hv_ModelID,
                                               (new HTuple(hv_AngleStart)).TupleRad(),
                                               (new HTuple(hv_AngleExtend)).TupleRad(),
                                               new HTuple(hv_ScaledMin),
                                               new HTuple(hv_ScaledMax),
                                               hv_TmpMinScore,
                                               new HTuple(numMatches),
                                               new HTuple(0.5),
                                               new HTuple("least_squares"),
                                               new HTuple(4),
                                               new HTuple(0.7),
                                               out hv_RowCheck,
                                               out hv_ColumnCheck,
                                               out hv_AngleCheck,
                                               out hv_Scale,
                                               out hv_Score);
            if (hv_Score.TupleLength() > 0)
                return hv_Score >= hv_MinScore;
            else
                return false;  
        }

        public static bool Match_ScaledTemplate(HObject ho_SearchImage,
                        HTuple hv_ModelID,
                        HTuple hv_MinScore,
                        HTuple hv_ModelRow, HTuple hv_ModelCol, HTuple hv_ModelFitRow, HTuple hv_ModelFitCol,
                        out HTuple hv_RowCheck,
                        out HTuple hv_ColumnCheck,
                        out HTuple hv_AngleCheck,
                        out HTuple hv_Scale,
                        out HTuple hv_Score,
                        out HTuple hv_FitRowCheck,
                        out HTuple hv_FitColCheck,
                        double hv_AngleStart = -180,
                        double hv_AngleExtend = 360,
                        double hv_AngleStep = 0,//"Auto",
                        double hv_ScaledMin = 0.2,
                        double hv_ScaledMax = 2.0,
                        int numMatches = 1)
        {
            Match_ScaledTemplate(ho_SearchImage,
                                 hv_ModelID,
                                 hv_MinScore,
                                out hv_RowCheck,
                                out hv_ColumnCheck,
                                out hv_AngleCheck,
                                out hv_Scale,
                                out hv_Score,
                                hv_AngleStart,
                                hv_AngleExtend,
                                hv_AngleStep,//"Auto",
                                hv_ScaledMin,
                                hv_ScaledMax,
                                numMatches);
            //HTuple hv_TmpMinScore = hv_MinScore;
            //if (hv_MinScore.D > 0.3)
            //    hv_TmpMinScore = hv_MinScore - 0.3;
            //hv_FitRowCheck = 0; hv_FitColCheck = 0;
            //HOperatorSet.FindScaledShapeModel(ho_SearchImage,
            //                                   hv_ModelID,
            //                                   (new HTuple(hv_AngleStart)).TupleRad(),
            //                                   (new HTuple(hv_AngleExtend)).TupleRad(),
            //                                   new HTuple(hv_ScaledMin),
            //                                   new HTuple(hv_ScaledMax),
            //                                   hv_TmpMinScore,
            //                                   new HTuple(numMatches),
            //                                   new HTuple(0.5),
            //                                   new HTuple("least_squares"),
            //                                   new HTuple(0),
            //                                   new HTuple(0.7),
            //                                   out hv_RowCheck,
            //                                   out hv_ColumnCheck,
            //                                   out hv_AngleCheck,
            //                                   out hv_Scale,
            //                                   out hv_Score);
            hv_FitRowCheck = hv_RowCheck; hv_FitColCheck = hv_ColumnCheck;
            if (hv_Score.TupleLength() > 0)
            {
                if (hv_ModelFitRow.D != 0 && hv_ModelFitCol.D != 0)
                {
                    HTuple tempHommat = new HTuple();
                    HOperatorSet.VectorAngleToRigid(hv_ModelRow, hv_ModelCol, 0, hv_RowCheck, hv_ColumnCheck, hv_AngleCheck, out tempHommat);
                    HOperatorSet.AffineTransPixel(tempHommat, hv_ModelFitRow, hv_ModelFitCol, out hv_FitRowCheck, out hv_FitColCheck);
                }
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 显示找到的模板
        /// </summary>
        /// <param name="hv_ExpDefaultWinHandle">显示的图像窗口</param>
        /// <param name="ho_ModelContours">模板轮廓</param>
        /// <param name="hv_RowCheck">模板的Row</param>
        /// <param name="hv_ColumnCheck">模板的Col</param>
        /// <param name="hv_AngleCheck">模板的角度</param>
        /// <param name="hv_Score">模板的分数</param>
        /// <param name="dispColor">显示的颜色</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool DispFindedModel(HTuple hv_ExpDefaultWinHandle,
                                               HObject ho_ModelContours,
                                               HTuple hv_RowCheck,
                                               HTuple hv_ColumnCheck,
                                               HTuple hv_AngleCheck,
                                               HTuple hv_Score,
                                               string dispColor = "green")
        {
            HTuple hv_MatchingObjIdx = null;
            HTuple hv_HomMat = null;

            HObject ho_TransContours = null;
            HOperatorSet.GenEmptyObj(out ho_TransContours);

            if (ho_ModelContours == null) 
                return false;
      
            if (ho_ModelContours.CountObj() <= 0)
                return false;

            HOperatorSet.SetColor(hv_ExpDefaultWinHandle, new HTuple(dispColor));

            //Matching 01: transform the model contours into the detected positions
            for (int iLoop = (new HTuple(0)).I; iLoop < (new HTuple(hv_Score.TupleLength())).I; iLoop ++)//TupleSub(new HTuple(1))).
            {
                hv_MatchingObjIdx = new HTuple(iLoop);
                HOperatorSet.HomMat2dIdentity(out hv_HomMat);
                HOperatorSet.HomMat2dRotate(hv_HomMat, hv_AngleCheck.TupleSelect(hv_MatchingObjIdx), 
                    new HTuple(0), new HTuple(0), out hv_HomMat);
                HOperatorSet.HomMat2dTranslate(hv_HomMat, hv_RowCheck.TupleSelect(hv_MatchingObjIdx), 
                    hv_ColumnCheck.TupleSelect(hv_MatchingObjIdx), out hv_HomMat);
                ho_TransContours.Dispose();
                HOperatorSet.AffineTransContourXld(ho_ModelContours, out ho_TransContours, hv_HomMat);
                HOperatorSet.DispObj(ho_TransContours, hv_ExpDefaultWinHandle);
            }
            return true;
        }

        /// <summary>
        /// 显示找到的模板
        /// </summary>
        /// <param name="hv_ExpDefaultWinHandle">显示的图像窗口</param>
        /// <param name="ho_ModelContours">模板轮廓</param>
        /// <param name="hv_RowCheck">模板的Row</param>
        /// <param name="hv_ColumnCheck">模板的Col</param>
        /// <param name="hv_AngleCheck">模板的角度</param>
        /// <param name="hv_Score">模板的分数</param>
        /// <param name="dispColor">显示的颜色</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool DispFindedModel(HTuple hv_ExpDefaultWinHandle,
                                               HObject ho_ModelContours,
                                               HTuple hv_RowCheck,
                                               HTuple hv_ColumnCheck,
                                               HTuple hv_AngleCheck,
                                               HTuple hv_Score,HTuple hv_FitRow,HTuple hv_FitCol,
                                               string dispColor = "green",int dispCol = 5)
        {
            HTuple hv_MatchingObjIdx = null;
            HTuple hv_HomMat = null;

            HObject ho_TransContours = null;
            HOperatorSet.GenEmptyObj(out ho_TransContours);

            if (ho_ModelContours == null)
                return false;

            if (ho_ModelContours.CountObj() <= 0)
                return false;

            HOperatorSet.SetColor(hv_ExpDefaultWinHandle, new HTuple(dispColor));

            //Matching 01: transform the model contours into the detected positions
            for (int iLoop = ((new HTuple(0))).I; iLoop < (((new HTuple(hv_Score.TupleLength())))).I; iLoop++)//TupleSub(new HTuple(1))).
            {
                hv_MatchingObjIdx = new HTuple(iLoop);
                HOperatorSet.HomMat2dIdentity(out hv_HomMat);
                HOperatorSet.HomMat2dRotate(hv_HomMat, hv_AngleCheck.TupleSelect(hv_MatchingObjIdx),
                    new HTuple(0), new HTuple(0), out hv_HomMat);
                HOperatorSet.HomMat2dTranslate(hv_HomMat, hv_RowCheck.TupleSelect(hv_MatchingObjIdx),
                    hv_ColumnCheck.TupleSelect(hv_MatchingObjIdx), out hv_HomMat);

                ho_TransContours.Dispose();
                HOperatorSet.AffineTransContourXld(ho_ModelContours, out ho_TransContours, hv_HomMat);
                HOperatorSet.DispObj(ho_TransContours, hv_ExpDefaultWinHandle);
            }
            if (hv_RowCheck.Length > 0)
            {
                HOperatorSet.SetColor(hv_ExpDefaultWinHandle, "red");
                HOperatorSet.DispCross(hv_ExpDefaultWinHandle, hv_RowCheck, hv_ColumnCheck, 40, 0);
                set_display_font(hv_ExpDefaultWinHandle, 13, "mono", "false", "true");
                disp_message(hv_ExpDefaultWinHandle, "Row: " + Math.Round(hv_RowCheck.D, 3).ToString(), 0, new HTuple(dispCol));
                disp_message(hv_ExpDefaultWinHandle, "Col: " + Math.Round(hv_ColumnCheck.D, 3).ToString(), 15, new HTuple(dispCol));
                disp_message(hv_ExpDefaultWinHandle, "Ang: " + Math.Round(hv_AngleCheck.TupleDeg().D, 3).ToString(), 30, new HTuple(dispCol));
                disp_message(hv_ExpDefaultWinHandle, "Score: " + Math.Round(hv_Score.D, 3).ToString(), 45, new HTuple(dispCol));

            }
            return true;
        }


        /// <summary>
        /// 显示找到的模板
        /// </summary>
        /// <param name="hv_ExpDefaultWinHandle">显示的图像窗口</param>
        /// <param name="ho_ModelContours">模板轮廓</param>
        /// <param name="hv_RowCheck">模板的Row</param>
        /// <param name="hv_ColumnCheck">模板的Col</param>
        /// <param name="hv_AngleCheck">模板的角度</param>
        /// <param name="hv_Score">模板的分数</param>
        /// <param name="dispColor">显示的颜色</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool DispFindedScaledModel(HTuple hv_ExpDefaultWinHandle,
                                               HObject ho_ModelContours,
                                               HTuple hv_RowCheck,
                                               HTuple hv_ColumnCheck,
                                               HTuple hv_AngleCheck,HTuple hv_Scaled,
                                               HTuple hv_Score, HTuple hv_FitRow, HTuple hv_FitCol,
                                               string dispColor = "green", int dispCol = 5)
        {
            HTuple hv_MatchingObjIdx = null;
            HTuple hv_HomMat = null;

            HObject ho_TransContours = null;
            HOperatorSet.GenEmptyObj(out ho_TransContours);

            if (ho_ModelContours == null)
                return false;

            if (ho_ModelContours.CountObj() <= 0)
                return false;

            HOperatorSet.SetColor(hv_ExpDefaultWinHandle, new HTuple(dispColor));

            //Matching 01: transform the model contours into the detected positions
            for (int iLoop = ((new HTuple(0))).I; iLoop < (((new HTuple(hv_Score.TupleLength())))).I; iLoop++)//TupleSub(new HTuple(1))).
            {
                hv_MatchingObjIdx = new HTuple(iLoop);
                HOperatorSet.HomMat2dIdentity(out hv_HomMat);
                HOperatorSet.HomMat2dScale(hv_HomMat, hv_Scaled.TupleSelect(
                    hv_MatchingObjIdx), hv_Scaled.TupleSelect(hv_MatchingObjIdx), 0, 0, out hv_HomMat);
                HOperatorSet.HomMat2dRotate(hv_HomMat, hv_AngleCheck.TupleSelect(hv_MatchingObjIdx),
                    new HTuple(0), new HTuple(0), out hv_HomMat);
                HOperatorSet.HomMat2dTranslate(hv_HomMat, hv_RowCheck.TupleSelect(hv_MatchingObjIdx),
                    hv_ColumnCheck.TupleSelect(hv_MatchingObjIdx), out hv_HomMat);

                ho_TransContours.Dispose();
                HOperatorSet.AffineTransContourXld(ho_ModelContours, out ho_TransContours, hv_HomMat);
                HOperatorSet.DispObj(ho_TransContours, hv_ExpDefaultWinHandle);
            }
            if (hv_RowCheck.Length > 0)
            {
                HOperatorSet.SetColor(hv_ExpDefaultWinHandle, "red");
                HOperatorSet.DispCross(hv_ExpDefaultWinHandle, hv_RowCheck, hv_ColumnCheck, 40, 0);
                set_display_font(hv_ExpDefaultWinHandle, 13, "mono", "false", "true");
                disp_message(hv_ExpDefaultWinHandle, "Row: " + Math.Round(hv_RowCheck.D, 3).ToString(), 0, new HTuple(dispCol));
                disp_message(hv_ExpDefaultWinHandle, "Col: " + Math.Round(hv_ColumnCheck.D, 3).ToString(), 15, new HTuple(dispCol));
                disp_message(hv_ExpDefaultWinHandle, "Ang: " + Math.Round(hv_AngleCheck.TupleDeg().D, 3).ToString(), 30, new HTuple(dispCol));
                disp_message(hv_ExpDefaultWinHandle, "Score: " + Math.Round(hv_Score.D, 3).ToString(), 45, new HTuple(dispCol));
            }
            return true;
        }

        /// <summary>
        /// 矩阵转换
        /// </summary>
        /// <param name="hv_HomMat2D">矩阵</param>
        /// <param name="hv_RowCheck">图像行坐标</param>
        /// <param name="hv_ColumnCheck">图像列坐标</param>
        /// <param name="hv_AngleCheck">图像角度</param>
        /// <param name="hv_Score">模板匹配分数</param>
        /// <param name="ProcessResult">图像处理结果的对象</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool VD_AffineTransPoint2d(HTuple hv_HomMat2D,
                                                     HTuple hv_RowCheck,
                                                     HTuple hv_ColumnCheck,
                                                     HTuple hv_AngleCheck,
                                                     HTuple hv_Score,
                                                     ref Class_ProcessResult ProcessResult)
        {
            HTuple hv_output_X = new HTuple(0);
            HTuple hv_output_Y = new HTuple(0);
            HTuple hv_AngleCheck_Degree = null;

            if (hv_Score.Length >= 1)
            {
                //弧度到角度的转换
                HOperatorSet.TupleDeg(hv_AngleCheck, out hv_AngleCheck_Degree);

                if (hv_HomMat2D != null && hv_HomMat2D.Length > 0)
                {
                    //图像坐标->世界坐标的转换
                    HOperatorSet.AffineTransPoint2d(hv_HomMat2D, hv_RowCheck, hv_ColumnCheck, out hv_output_X, out hv_output_Y);
                }
                ProcessResult.X = hv_output_X[0].D;
                ProcessResult.Y = hv_output_Y[0].D;

                ProcessResult.Angle = hv_AngleCheck_Degree[0].D;
                ProcessResult.Score = hv_Score[0].D;
                ProcessResult.status = true;

                ProcessResult.Row = hv_RowCheck[0].D;
                ProcessResult.Col = hv_ColumnCheck[0].D;
            }
            else
                ProcessResult.status = false;

            return true;
        }

        public static bool VD_AffineTransPoint2d(HTuple hv_HomMat2D,
                                                     HTuple hv_ModelRow, HTuple hv_ModelCol,
                                                     HTuple hv_RowCheck,
                                                     HTuple hv_ColumnCheck,
                                                     HTuple hv_AngleCheck,
                                                     HTuple hv_Score,
                                                     ref Class_ProcessResult ProcessResult)
        {
            HTuple hv_output_X = new HTuple(0);
            HTuple hv_output_Y = new HTuple(0);
            HTuple hv_output_ModelX = 0;
            HTuple hv_output_ModelY = 0;
            HTuple hv_AngleCheck_Degree = null;

            if (hv_Score.Length >= 1)
            {
                try
                {
                    //弧度到角度的转换
                    HOperatorSet.TupleDeg(hv_AngleCheck, out hv_AngleCheck_Degree);

                if (hv_HomMat2D != null && hv_HomMat2D.Length > 0)
                {
                    //图像坐标->世界坐标的转换
                    HOperatorSet.AffineTransPoint2d(hv_HomMat2D, hv_RowCheck, hv_ColumnCheck, out hv_output_X, out hv_output_Y);
                    HOperatorSet.AffineTransPoint2d(hv_HomMat2D, hv_ModelRow, hv_ModelCol, out hv_output_ModelX, out hv_output_ModelY);
                }

                    ProcessResult.ModelRow = hv_ModelRow[0].D;
                    ProcessResult.ModelCol = hv_ModelCol[0].D;
                    ProcessResult.ModelX = hv_output_ModelX[0].D;
                    ProcessResult.ModelY = hv_output_ModelY[0].D;

                    ProcessResult.Row = hv_RowCheck[0].D;
                    ProcessResult.Col = hv_ColumnCheck[0].D;
                    ProcessResult.X = hv_output_X[0].D;
                    ProcessResult.Y = hv_output_Y[0].D;

                    ProcessResult.Angle = hv_AngleCheck_Degree[0].D;
                    ProcessResult.Score = hv_Score[0].D;
                    ProcessResult.status = true;

                }
                catch(Exception e)
                {
                    Debug.WriteLine("标定转换错误" + e.Message);
                }

            }
            else
                ProcessResult.status = false;

            return true;
        }
        public static bool VD_AffineTransPoint2d(HTuple hv_HomMat2D,
                                                     HTuple hv_ModelRow, HTuple hv_ModelCol,
                                                     HTuple hv_RowCheck,
                                                     HTuple hv_ColumnCheck,
                                                     HTuple hv_AngleCheck,
                                                     HTuple hv_Score,int numMatches,
                                                     ref Class_ProcessResult ProcessResult)
        {
            HTuple hv_output_X = new HTuple();
            HTuple hv_output_Y = new HTuple();
            HTuple hv_output_ModelX = 0;
            HTuple hv_output_ModelY = 0;
            HTuple hv_AngleCheck_Degree = new HTuple();

            if (hv_Score.Length >= 1)
            {
                ProcessResult.multModel = true;
                ProcessResult.New(hv_Score.Length);
                ProcessResult.status = true;
                try
                {
                    HOperatorSet.AffineTransPoint2d(hv_HomMat2D, hv_ModelRow, hv_ModelCol, out hv_output_ModelX, out hv_output_ModelY);
                    ProcessResult.ModelX = hv_output_ModelX[0].D;
                    ProcessResult.ModelY = hv_output_ModelY[0].D;
                }
                catch { }
                for (int i = 0; i < hv_Score.Length; i++)
                {
                    //弧度到角度的转换
                    HTuple tempA = new HTuple(0);
                    HOperatorSet.TupleDeg(hv_AngleCheck[i], out tempA);
                    hv_AngleCheck_Degree[i] = tempA;
                    if (hv_HomMat2D != null && hv_HomMat2D.Length > 0)
                    {
                        HTuple tempX = new HTuple(0);
                        HTuple tempY = new HTuple(0);
                        //图像坐标->世界坐标的转换
                        HOperatorSet.AffineTransPoint2d(hv_HomMat2D, hv_RowCheck[i], hv_ColumnCheck[i], out tempX, out tempY);
                        hv_output_X[i] = tempX;
                        hv_output_Y[i] = tempY;
                    }
                    ProcessResult.m_X[i] = hv_output_X[i].D;
                    ProcessResult.m_Y[i] = hv_output_Y[i].D;

                    ProcessResult.m_Angle[i] = hv_AngleCheck_Degree[i].D;
                    ProcessResult.m_Score[i] = hv_Score[i].D;

                    ProcessResult.m_Row[i] = hv_RowCheck[i].D;
                    ProcessResult.m_Col[i] = hv_ColumnCheck[i].D;
                }
                ProcessResult.Plus();
            }
            else
                ProcessResult.status = false;

            return true;
        }
        /// <summary>
        /// 矩阵转换
        /// </summary>
        /// <param name="hv_HomMat2D">矩阵</param>
        /// <param name="hv_RowCheck">图像行坐标</param>
        /// <param name="hv_ColumnCheck">图像列坐标</param>
        /// <param name="hv_AngleCheck">图像角度</param>
        /// <param name="hv_Score">模板匹配分数</param>
        /// <param name="ProcessResult">图像处理结果的对象</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool VD_AffineTransPoint2d(HTuple hv_HomMat2D,
                                                     HTuple hv_RowCheck,
                                                     HTuple hv_ColumnCheck,
                                                     HTuple hv_AngleCheck,
                                                     HTuple hv_Score,
                                                     HTuple hv_ModelRow, HTuple hv_ModelCol,
                                                     HTuple hv_FitRow, HTuple hv_FitCol,
                                                     HTuple hv_ModelFitRow, HTuple hv_ModelFitCol,
                                                     ref Class_ProcessResult ProcessResult)
        {
            HTuple hv_output_X = new HTuple(0);
            HTuple hv_output_Y = new HTuple(0);
            HTuple hv_AngleCheck_Degree = null;
            HTuple hv_output_ModelX = 0;
            HTuple hv_output_ModelY = 0;
            HTuple hv_output_FitX = 0;
            HTuple hv_output_FitY = 0;
            HTuple hv_output_ModelFitX = 0;
            HTuple hv_output_ModelFitY = 0;

            if (hv_Score.Length == 1)
            {
                ProcessResult.status = true;
                //弧度到角度的转换
                HOperatorSet.TupleDeg(hv_AngleCheck, out hv_AngleCheck_Degree);

                if (hv_HomMat2D != null && hv_HomMat2D.Length > 0)
                {
                    //图像坐标->世界坐标的转换
                    HOperatorSet.AffineTransPoint2d(hv_HomMat2D, hv_RowCheck, hv_ColumnCheck, out hv_output_X, out hv_output_Y);
                    HOperatorSet.AffineTransPoint2d(hv_HomMat2D, hv_ModelRow, hv_ModelCol, out hv_output_ModelX, out hv_output_ModelY);
                    HOperatorSet.AffineTransPoint2d(hv_HomMat2D, hv_ModelFitRow, hv_ModelFitCol, out hv_output_ModelFitX, out hv_output_ModelFitY);

                    if (hv_FitRow.D != 0 && hv_FitCol.D != 0)
                        HOperatorSet.AffineTransPoint2d(hv_HomMat2D, hv_FitRow, hv_FitCol, out hv_output_FitX, out hv_output_FitY);
                    else
                    {
                        hv_output_FitX = 0; hv_output_FitY = 0;
                    }
                }
                ProcessResult.X = hv_output_X[0].D;
                ProcessResult.Y = hv_output_Y[0].D;

                ProcessResult.Angle = hv_AngleCheck_Degree[0].D;
                ProcessResult.Score = hv_Score[0].D;
                try
                {
                    ProcessResult.ModelX = hv_output_ModelX[0].D;
                    ProcessResult.ModelY = hv_output_ModelY[0].D;
                    ProcessResult.ModelRow = hv_ModelRow[0].D;
                    ProcessResult.ModelCol = hv_ModelCol[0].D;
                    ProcessResult.ModelFitX = hv_output_ModelFitX[0].D;
                    ProcessResult.ModelFitY = hv_output_ModelFitY[0].D;
                }
                catch
                {

                }
                ProcessResult.Row = hv_RowCheck[0].D;
                ProcessResult.Col = hv_ColumnCheck[0].D;


                ProcessResult.FitRow = hv_FitRow[0].D;
                ProcessResult.FitCol = hv_FitCol[0].D;

                ProcessResult.FitX = hv_output_FitX[0].D;
                ProcessResult.FitY = hv_output_FitY[0].D;

            }
            else if (hv_Score.Length > 1)
            {
                ProcessResult.status = true;
            }
            else
                ProcessResult.status = false;

            return true;
        }

        /// <summary>
        /// 根据图像坐标获取世界坐标
        /// </summary>
        /// <param name="hv_HomMat2D">相机标定文件</param>
        /// <param name="Row">图像坐标Row</param>
        /// <param name="Column">图像坐标Col</param>
        /// <param name="World_X">世界坐标X</param>
        /// <param name="World_Y">世界坐标Y</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool Get_WorldCoordinate(HTuple hv_HomMat2D,
                                                  Double Row,
                                                  Double Column,
                                                  ref Double World_X,
                                                  ref Double World_Y)
        {

            HTuple hv_World_X = null;
            HTuple hv_World_Y = null;

            //图像坐标->世界坐标的转换
            HOperatorSet.AffineTransPoint2d(hv_HomMat2D, new HTuple(Row), new HTuple(Column), out hv_World_X, out hv_World_Y);

            if (hv_World_X.Length >= 1) 
            {

                World_X = hv_World_X[0];
                World_Y = hv_World_Y[0];

                return true;
            }
            else
                return false;
        }

        public static bool Distance2Points(Double x1, Double y1,
                                        Double x2, Double y2,
                                        out Double Distance)
        {
            Distance = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
            return true;
        }
        /// <summary>
        /// 根据图像坐标获取世界坐标
        /// </summary>
        /// <param name="hv_HomMat2D">相机标定文件</param>
        /// <param name="Start_Row">开始坐标Row</param>
        /// <param name="Start_Column">开始坐标Row</param>
        /// <param name="End_Row">结束坐标Row</param>
        /// <param name="End_Column">结束坐标Col</param>
        /// <param name="World_Distance">世界坐标距离</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool Get_WorldDistance(HTuple hv_HomMat2D,
                                             HTuple Start_Row,
                                             HTuple Start_Column,
                                             HTuple End_Row,
                                             HTuple End_Column,
                                             ref double World_Distance)
        {
            HTuple hv_World_Start_X = null;
            HTuple hv_World_Start_Y = null;

            HTuple hv_World_End_X = null;
            HTuple hv_World_End_Y = null;

            //图像坐标->世界坐标的转换
            HOperatorSet.AffineTransPoint2d(hv_HomMat2D, new HTuple(Start_Row), new HTuple(Start_Column), out hv_World_Start_X, out hv_World_Start_Y);
            HOperatorSet.AffineTransPoint2d(hv_HomMat2D, new HTuple(End_Row), new HTuple(End_Column), out hv_World_End_X, out hv_World_End_Y);

            if (hv_World_Start_X.Length >= 1) 
            {
                Distance2Points(hv_World_Start_X[0].D, hv_World_Start_Y[0].D, hv_World_End_X[0].D, hv_World_End_Y[0].D, out World_Distance);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 根据图像坐标获取世界坐标
        /// </summary>
        /// <param name="hv_HomMat2D">相机标定文件</param>
        /// <param name="Image_Distance">图像坐标距离</param>
        /// <param name="World_Distance">世界坐标距离</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool Get_WorldDistance(HTuple hv_HomMat2D,
                                             double Image_Distance,
                                             ref double World_Distance)
        {

            HTuple hv_World_Start_X = null;
            HTuple hv_World_Start_Y = null;

            HTuple hv_World_End_X = null;
            HTuple hv_World_End_Y = null;

            //图像坐标->世界坐标的转换
            HOperatorSet.AffineTransPoint2d(hv_HomMat2D, new HTuple(0), new  HTuple(0), out hv_World_Start_X, out hv_World_Start_Y);
            HOperatorSet.AffineTransPoint2d(hv_HomMat2D, new HTuple(0), new HTuple(Image_Distance), out hv_World_End_X, out hv_World_End_Y);

            if (hv_World_Start_X.Length >= 1) 
            {
                Distance2Points(hv_World_Start_X[0].D, hv_World_Start_Y[0].D, hv_World_End_X[0].D, hv_World_End_Y[0].D, out World_Distance);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 设置区域为固定灰度值
        /// </summary>
        /// <param name="ho_image"></param>
        /// <param name="ho_Region"></param>
        /// <param name="GrayValue"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool SetRegion_GrayValue(ref HObject ho_image,
                                               HObject ho_Region,
                                                 int GrayValue)
        {
            HTuple hv_Row = null;
            HTuple hv_Column = null;
            HTuple hv_Length = null;
            HTuple hv_Newtuple = null;


            HOperatorSet.GetRegionPoints(ho_Region, out hv_Row, out hv_Column);

            HOperatorSet.TupleLength(hv_Row, out hv_Length);

            HOperatorSet.TupleGenConst(hv_Length, new HTuple(GrayValue), out hv_Newtuple);

            HOperatorSet.SetGrayval(ho_image, hv_Row, hv_Column, hv_Newtuple);

            return true;
        }

        /// <summary>
        /// 线段测量
        /// </summary>
        /// <remarks></remarks>
        public static bool Measure_Line(ref HObject ho_Image,
                                 Double LineStart_Row, Double LineStart_Col,
                                 Double LineEnd_Row, Double LineEnd_Col,
                                 Double MinEdgeAmplitude, int ROI_Width,
                                 ref HTuple hv_Row_Measure, ref HTuple hv_Column_Measure,
                                 ref HTuple hv_Amplitude_Measure, ref HTuple hv_Distance_Measure,
                                 Double Sigma = 1.0, string Interpolation = "nearest_neighbor", string Transition = "all", string Selection = "all")
        {
            //判断直线距离
            double  distance_Line = 0;
            distance_Line = Math.Sqrt(Math.Pow(LineEnd_Row - LineStart_Row, 2) + Math.Pow(LineEnd_Col - LineStart_Col, 2));
            if (distance_Line <= 1) 
            {
                MessageBox.Show("输入的测量直线长度<= 1");
                return false;
            }
        
            // Local control variables 
            HTuple hv_Pointer = null, hv_Type = null;
            HTuple hv_Width = null, hv_Height = null;
            HTuple hv_WindowHandle = null;
            //, hv_AmplitudeThreshold As HTuple = Nothing
            HTuple hv_ROIWidth = null, hv_LineRowStart_Measure_01_0 = null;
            HTuple hv_LineColumnStart_Measure_01_0 = null;
            HTuple hv_LineRowEnd_Measure_01_0 = null;
            HTuple hv_LineColumnEnd_Measure_01_0 = null;
            HTuple hv_TmpCtrl_Row = null, hv_TmpCtrl_Column = null;
            HTuple hv_TmpCtrl_Dr = null, hv_TmpCtrl_Dc = null;
            HTuple hv_TmpCtrl_Phi = null, hv_TmpCtrl_Len1 = null;
            HTuple hv_TmpCtrl_Len2 = null, hv_MsrHandle_Measure_01_0 = null;
            //Dim hv_Row_Measure As HTuple = Nothing, hv_Column_Measure As HTuple = Nothing
            //Dim hv_Amplitude_Measure As HTuple = Nothing, hv_Distance_Measure As HTuple = Nothing

            HOperatorSet.GetImagePointer1(ho_Image, out hv_Pointer, out hv_Type, out hv_Width, out hv_Height);

            //dev_close_window(...);
            //dev_open_window(...);
            //HOperatorSet.DispObj(ho_Image, hv_ExpDefaultWinHandle)

            //Code generated by Measure 01
            //Prepare measurement
            //hv_AmplitudeThreshold = New HTuple(40)
            hv_ROIWidth = new HTuple(ROI_Width);
            HOperatorSet.SetSystem(new HTuple("int_zooming"), new HTuple("true"));
            //Coordinates for line Measure 01 [0]
            hv_LineRowStart_Measure_01_0 = new HTuple(LineStart_Row);
            hv_LineColumnStart_Measure_01_0 = new HTuple(LineStart_Col);
            hv_LineRowEnd_Measure_01_0 = new HTuple(LineEnd_Row);
            hv_LineColumnEnd_Measure_01_0 = new HTuple(LineEnd_Col);
            //Convert coordinates to rectangle2 type
            hv_TmpCtrl_Row = (new HTuple(0.5)).TupleMult(hv_LineRowStart_Measure_01_0.TupleAdd(hv_LineRowEnd_Measure_01_0));
            hv_TmpCtrl_Column = (new HTuple(0.5)).TupleMult(hv_LineColumnStart_Measure_01_0.TupleAdd(hv_LineColumnEnd_Measure_01_0));
            hv_TmpCtrl_Dr = hv_LineRowStart_Measure_01_0.TupleSub(hv_LineRowEnd_Measure_01_0);
            hv_TmpCtrl_Dc = hv_LineColumnEnd_Measure_01_0.TupleSub(hv_LineColumnStart_Measure_01_0);
            hv_TmpCtrl_Phi = hv_TmpCtrl_Dr.TupleAtan2(hv_TmpCtrl_Dc);
            hv_TmpCtrl_Len1 = (new HTuple(0.5)).TupleMult(((((hv_TmpCtrl_Dr.TupleMult(hv_TmpCtrl_Dr))).TupleAdd(hv_TmpCtrl_Dc.TupleMult(hv_TmpCtrl_Dc)))).TupleSqrt());
            hv_TmpCtrl_Len2 = hv_ROIWidth;
            //Create measure for line Measure 01 [0]
            //Attention: This assumes all images have the same size!
            //获取扫描范围与方向，带角度矩阵
            HOperatorSet.GenMeasureRectangle2(hv_TmpCtrl_Row, hv_TmpCtrl_Column, hv_TmpCtrl_Phi,
                                                hv_TmpCtrl_Len1, hv_TmpCtrl_Len2, hv_Width, hv_Height, new HTuple(Interpolation),
                                                out hv_MsrHandle_Measure_01_0);

            //***************************************************************
            //* The code which follows is to be executed once / measurement *
            //***************************************************************
            //Load image
            //ho_Image.Dispose()
            //HOperatorSet.ReadImage(ho_Image, New HTuple("E:/js/ClassLibJs_Measure/HalconProject/ss.bmp"))
            //Execute measurements
            HOperatorSet.MeasurePos(ho_Image, hv_MsrHandle_Measure_01_0, new HTuple(Sigma), new HTuple(MinEdgeAmplitude),
                                    new HTuple(Transition), new HTuple(Selection),
                                    out hv_Row_Measure, out hv_Column_Measure,
                                    out hv_Amplitude_Measure, out hv_Distance_Measure);
            //Do something with the results
            //Clear measure when done
            HOperatorSet.CloseMeasure(hv_MsrHandle_Measure_01_0);

            //ho_Image.Dispose()
            return true;
        }


        //以下为新增集成找线功能 20180222

        public void Fit_Line(HObject Image,			//图像
            //ref HObject objDisp,			//显示图形
                             HTuple HomMat2D,			//ROI仿射变换矩阵
                             int Elements,				//找边缘点的数量，即卡尺工具的数量
                             int Threshold,			//边缘阈值
                             double Sigma,				//边缘滤波系数
                             string Transition,		//边缘极性
                             string Point_Select,		//边缘点的选择
                             HTuple ROI_X,				//rake工具x数组
                             HTuple ROI_Y,				//rake工具y数组
                             int Caliper_Height,		//卡尺工具高度
                             int Caliper_Width,		//卡尺工具宽度
                             int Min_Points_Num,		//最小有效点数，即边缘点数要大于等于该值
                             out HObject Caliper_Regions,	//产生的卡尺工具图形
                             out HTuple Edges_X,			//找到的边缘点x数据
                             out HTuple Edges_Y,			//找到的边缘点y数据
                             out HObject Result_xld,		//拟合得到的直线
                             out HTuple Result_X,			//拟合得到的直线的点的x数组
                             out HTuple Result_Y			//拟合得到的直线的点的y数组

                             )
        {
            HObject Cross;
            HOperatorSet.GenEmptyObj(out Cross);
            HOperatorSet.GenEmptyObj(out Caliper_Regions);
            HOperatorSet.GenEmptyObj(out Result_xld);
            Edges_X = new HTuple();
            Edges_Y = new HTuple();
            Result_X = new HTuple();
            Result_Y = new HTuple();

            try
            {
                //判断图像是否为空

                HTuple Row0, Row1, Col0, Col1;

                //判断rake工具的ROI是否有效
                if (ROI_Y.Length < 2)
                {
                    //disp_message( hv_WindowHandle, HTuple hv_String, 12,
                    //             12, "red",  "window", "false");
                    //Error.strErrorInfo = "直线ROI不正确!";
                    MessageBox.Show("直线ROI不正确!");
                    Cross.Dispose();
                    return;
                }
                //判断ROI仿射变换矩阵是否有效，有效的时候，有6个数据 
                if (HomMat2D!=null &&  HomMat2D.Length < 6)
                {
                    //矩阵无效，直接用原始ROI执行rake工具找边缘点
                    Result_xld.Dispose();
                    rake(Image, out Caliper_Regions, Elements, Caliper_Height, Caliper_Width, Sigma, Threshold,
                    Transition, Point_Select, ROI_Y[0], ROI_X[0],
                    ROI_Y[1], ROI_X[1], out Edges_Y, out Edges_X);
                }
                else
                {
                    HTuple New_ROI_Y, New_ROI_X;
                    //矩阵有效，先产生新的ROI,用新的ROI执行rake工具找边缘点
                    HOperatorSet.AffineTransPoint2d(HomMat2D, ROI_Y, ROI_X, out New_ROI_Y, out New_ROI_X);
                    rake(Image, out Caliper_Regions, Elements, Caliper_Height, Caliper_Width, Sigma, Threshold,
                    Transition, Point_Select, New_ROI_Y[0], New_ROI_X[0], New_ROI_Y[1], New_ROI_X[1], out Edges_Y, out Edges_X);
                }
                //把产生的卡尺工具图像添加到显示图形
                //Concat_Obj(ref objDisp, ref Caliper_Regions, ref objDisp);

                //判断是否找到有边缘点，如果有，产生边缘点x图形，并添加到显示图形
                if (Edges_Y.Length > 0)
                {
                    HOperatorSet.GenCrossContourXld(out Cross, Edges_Y, Edges_X, 20, (new HTuple(45)).TupleRad());
                    //Concat_Obj(ref objDisp, ref Cross, ref objDisp);
                }
                //如果边缘点数大于等于最小点数，进行直线拟合；否则返回错误信息
                if (Edges_Y.Length >= Min_Points_Num)
                {
                    //拟合直线
                    pts_to_best_line(out Result_xld, Edges_Y, Edges_X, Min_Points_Num, out Row0, out Col0, out Row1, out Col1);
                    //把直线的点添加到结果数组
                    Result_Y = Row0.TupleConcat(Row1);
                    Result_X = Col0.TupleConcat(Col1);

                    //Error.strErrorInfo = "拟合直线成功!";
                }
                else
                {
                    MessageBox.Show("拟合直线找到的边缘点太少!");

                }

            }
            catch (Exception)
            {

                Cross.Dispose();

                MessageBox.Show("拟合直线过程失败!");
            }
            Cross.Dispose();

        }


        /// <summary>
        /// 找直线交点坐标
        /// </summary>
        /// <param name="hv_Rows1">第一条直线起点X坐标</param>
        /// <param name="hv_Columns1">第一条直线起点Y坐标</param>
        /// <param name="hv_Rows2">第一条直线终点X坐标</param>
        /// <param name="hv_Columns2">第一条直线终点Y坐标</param>
        /// <param name="hv_RowLine1">第二条直线起点X坐标</param>
        /// <param name="hv_ColLine1">第二条直线起点Y坐标</param>
        /// <param name="hv_RowLine2">第二条直线终点X坐标</param>
        /// <param name="hv_ColLine2">第二条直线终点X坐标</param>
        /// <param name="hv_Row">交点坐标X</param>
        /// <param name="hv_Column">交点坐标Y</param>
        /// <param name="hv_IsParallel">直线是否平行</param>
        public  bool get_Intersection(HTuple hv_Rows1,
                                      HTuple hv_Columns1,
                                      HTuple hv_Rows2,
                                      HTuple hv_Columns2,
                                      HTuple hv_RowLine1,
                                      HTuple hv_ColLine1,
                                      HTuple hv_RowLine2,
                                      HTuple hv_ColLine2,
                                      out HTuple hv_Row,//交点坐标X
                                      out HTuple hv_Column,//交点坐标Y
                                      out HTuple hv_IsParallel//直线是否平行
                                     )
        {
            try
            {
                HOperatorSet.IntersectionLl(hv_Rows1, hv_Columns1, hv_Rows2, hv_Columns2,
                                      hv_RowLine1, hv_ColLine1, hv_RowLine2, hv_ColLine2, out hv_Row, out hv_Column, out hv_IsParallel);
                if (hv_IsParallel == 1)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                hv_Row = 0;
                hv_Column = 0;
                hv_IsParallel = 1;
                return false;
            }

        }

        /// <summary>
        /// 对象是否初始化
        /// </summary>
        /// <param name="Obj"></param>
        /// <returns></returns>
        public static bool ObjectValided(HObject Obj)
        {
            if (Obj == null)
                return false;
            if (!Obj.IsInitialized())
            {
                return false;
            }
            if (Obj.CountObj() < 1)
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// 图像滤波
        /// </summary>
        /// <param name="ho_Image">输入图像</param>
        /// <param name="ho_ImageMedian">滤波后图像</param>
        /// <param name="Filter_type">滤膜类型筛选，默认'circle'</param>
        /// <param name="Radius">滤膜的半径，默认20</param>
        /// <param name="Border_treatment">边界处理，默认值'mirrored'</param>
        public void MedianImage(
                                HObject ho_Image,
                                HObject ho_ImageMedian,
                                HTuple Filter_type,
                                HTuple Radius,
                                HTuple Border_treatment

                                )
        {
            try
            {
                //判断图像是否为空
                if (!ObjectValided(ho_Image))
                {
                    MessageBox.Show("图像为空!");
                    return;
                }
                HOperatorSet.MedianImage(ho_Image, out ho_ImageMedian, Filter_type, Radius, Border_treatment);

            }
            catch (Exception)
            {
                return;
            }

        }

        /// <summary>
        /// 分离Region获得交点
        /// </summary>
        /// <param name="m_Image">待处理图片</param>
        /// <param name="ho_Region">输入搜索到的区域</param>
        /// <param name="Sigma">图像模糊度</param>
        /// <param name="Threshold">微分阈值</param>
        /// <param name="Transition">极性</param>
        /// <param name="Select">选择</param>
        /// <param name="Intersection_Row">输出交点坐标</param>
        /// <param name="Intersection_Column">输出交点坐标</param>
        public void SeparateRegionGetIntersection(
                                   HObject m_Image,//待处理图片
                                   HObject ho_Region,//输入搜索到的区域
                                   HTuple Sigma,//图像模糊度
                                   HTuple Threshold,//微分阈值
                                   HTuple Transition,//极性
                                   HTuple Select,//选择
                                   ref HTuple Intersection_Row,//输出交点坐标
                                   ref HTuple Intersection_Column//输出交点坐标
                                  )
        {

            HObject ho_ConnectedRegions,out_Region1,out_Region2,ho_Line1,ho_Line2,Region1, Region2;
            HTuple rake_width, hv_Row1, hv_Column1, hv_Row2, hv_Column2, rake_Height, rake_num, hv_IsParallel;
            HTuple Edges_Y, Edges_X;
            HTuple Ln1_Row1, Ln1_Column1, Ln1_Row2, Ln1_Column2;//拟合直线Ln1数据
            HTuple Ln2_Row1, Ln2_Column1, Ln2_Row2, Ln2_Column2;//拟合直线Ln2数据
            HOperatorSet.GenEmptyObj(out ho_ConnectedRegions);
            HOperatorSet.GenEmptyObj(out Region1);
            HOperatorSet.GenEmptyObj(out Region2);
            HOperatorSet.Connection(ho_Region, out ho_ConnectedRegions);
            if (ho_ConnectedRegions.CountObj() > 2)
            {
                MessageBox.Show("保存区域数不能大于2");
                return;
            }
            if (ho_ConnectedRegions.CountObj() < 2)
            {
                MessageBox.Show("保存区域数不能小于2");
            }

            HOperatorSet.SelectObj(ho_ConnectedRegions, out Region1, 1);
            HOperatorSet.SelectObj(ho_ConnectedRegions, out Region2, 2);


            //获取第一条直线
            RegionToLine(Region1, out rake_width, out rake_Height, out hv_Row1, out hv_Column1, out hv_Row2, out hv_Column2, out rake_num);

            rake(m_Image, out out_Region1, rake_num, rake_Height, rake_width, Sigma, Threshold,
                  Transition, Select, hv_Row1, hv_Column1, hv_Row2, hv_Column2, out Edges_Y, out Edges_X);
            //拟合直线Ln1
            pts_to_best_line(out  ho_Line1, Edges_Y, Edges_X, rake_num / 2, out  Ln1_Row1, out  Ln1_Column1, out  Ln1_Row2, out  Ln1_Column2);


            //获取第二条直线
            RegionToLine(Region2, out rake_width, out rake_Height, out hv_Row1, out hv_Column1, out hv_Row2, out hv_Column2, out rake_num);

            rake(m_Image, out out_Region2, rake_num, rake_Height, rake_width, Sigma, Threshold,
                  Transition, Select, hv_Row1, hv_Column1, hv_Row2, hv_Column2, out Edges_Y, out Edges_X);
            //拟合直线Ln2
            pts_to_best_line(out  ho_Line2, Edges_Y, Edges_X, rake_num / 2, out  Ln2_Row1, out  Ln2_Column1, out  Ln2_Row2, out  Ln2_Column2);

            //获取交点坐标
            get_Intersection(Ln1_Row1, Ln1_Column1, Ln1_Row2, Ln1_Column2,
                            Ln2_Row1, Ln2_Column1, Ln2_Row2, Ln2_Column2,
                          out Intersection_Row, out Intersection_Column, out hv_IsParallel);

        }

        /// <summary>
        /// 获取仿射矩形的4个顶点，4边中点
        /// </summary>
        /// <param name="hv_CenterY">仿射矩形中心坐标Y</param>
        /// <param name="hv_CenterX">仿射矩形中心坐标X</param>
        /// <param name="hv_Phi">仿射矩形角度</param>
        /// <param name="hv_Len1">仿射矩形宽的一半</param>
        /// <param name="hv_Len2">仿射矩形高的一半</param>
        /// <param name="hv_CornerY">仿射矩形端点Y</param>
        /// <param name="hv_CornerX">仿射矩形端点X</param>
        /// <param name="hv_LineCenterY">仿射矩形边中点Y</param>
        /// <param name="hv_LineCenterX">仿射矩形边中点X</param>
        public static void get_rectangle2_points_tlf(HTuple hv_CenterY,
                                              HTuple hv_CenterX,
                                              HTuple hv_Phi,
                                              HTuple hv_Len1,
                                              HTuple hv_Len2,
                                              out HTuple hv_CornerY,
                                              out HTuple hv_CornerX,
                                              out HTuple hv_LineCenterY,
                                              out HTuple hv_LineCenterX)
        {

            // Local iconic variables 

            // Local control variables 

            HTuple hv_RowT = null, hv_ColT = null, hv_Cos = null;
            HTuple hv_Sin = null;
            // Initialize local and output iconic variables 
            //矩形端点坐标变量，边中心坐标变量初始化
            hv_CornerX = new HTuple();
            hv_CornerY = new HTuple();
            hv_LineCenterX = new HTuple();
            hv_LineCenterY = new HTuple();
            //
            //
            //临时变量初始化
            hv_RowT = 0;
            hv_ColT = 0;
            //
            //判断仿射矩形是否有效
            if ((int)((new HTuple(hv_Len1.TupleLessEqual(0))).TupleOr(new HTuple(hv_Len2.TupleLessEqual(
                0)))) != 0)
            {

                return;
            }
            //
            //
            //计算仿射矩形角度的正余弦值
            HOperatorSet.TupleCos(hv_Phi, out hv_Cos);
            HOperatorSet.TupleSin(hv_Phi, out hv_Sin);
            //
            //矩形第一个端点坐标
            hv_ColT = (hv_CenterX - (hv_Len1 * hv_Cos)) - (hv_Len2 * hv_Sin);
            hv_RowT = hv_CenterY - (((-hv_Len1) * hv_Sin) + (hv_Len2 * hv_Cos));
            hv_CornerY = hv_CornerY.TupleConcat(hv_RowT);
            hv_CornerX = hv_CornerX.TupleConcat(hv_ColT);
            //
            //矩形第二个端点坐标
            hv_ColT = (hv_CenterX + (hv_Len1 * hv_Cos)) - (hv_Len2 * hv_Sin);
            hv_RowT = hv_CenterY - ((hv_Len1 * hv_Sin) + (hv_Len2 * hv_Cos));
            hv_CornerY = hv_CornerY.TupleConcat(hv_RowT);
            hv_CornerX = hv_CornerX.TupleConcat(hv_ColT);
            //
            //矩形第三个端点坐标
            hv_ColT = (hv_CenterX + (hv_Len1 * hv_Cos)) + (hv_Len2 * hv_Sin);
            hv_RowT = hv_CenterY - ((hv_Len1 * hv_Sin) - (hv_Len2 * hv_Cos));
            hv_CornerY = hv_CornerY.TupleConcat(hv_RowT);
            hv_CornerX = hv_CornerX.TupleConcat(hv_ColT);
            //
            //矩形第四个端点坐标
            hv_ColT = (hv_CenterX - (hv_Len1 * hv_Cos)) + (hv_Len2 * hv_Sin);
            hv_RowT = hv_CenterY - (((-hv_Len1) * hv_Sin) - (hv_Len2 * hv_Cos));
            hv_CornerY = hv_CornerY.TupleConcat(hv_RowT);
            hv_CornerX = hv_CornerX.TupleConcat(hv_ColT);
            //
            //矩形第一条边中心坐标
            if (hv_LineCenterY == null)
                hv_LineCenterY = new HTuple();
            hv_LineCenterY[0] = ((hv_CornerY.TupleSelect(0)) + (hv_CornerY.TupleSelect(1))) * 0.5;
            if (hv_LineCenterX == null)
                hv_LineCenterX = new HTuple();
            hv_LineCenterX[0] = ((hv_CornerX.TupleSelect(0)) + (hv_CornerX.TupleSelect(1))) * 0.5;
            //
            //矩形第二条边中心坐标
            if (hv_LineCenterY == null)
                hv_LineCenterY = new HTuple();
            hv_LineCenterY[1] = ((hv_CornerY.TupleSelect(1)) + (hv_CornerY.TupleSelect(2))) * 0.5;
            if (hv_LineCenterX == null)
                hv_LineCenterX = new HTuple();
            hv_LineCenterX[1] = ((hv_CornerX.TupleSelect(1)) + (hv_CornerX.TupleSelect(2))) * 0.5;
            //
            //
            //矩形第三条边中心坐标
            if (hv_LineCenterY == null)
                hv_LineCenterY = new HTuple();
            hv_LineCenterY[2] = ((hv_CornerY.TupleSelect(3)) + (hv_CornerY.TupleSelect(2))) * 0.5;
            if (hv_LineCenterX == null)
                hv_LineCenterX = new HTuple();
            hv_LineCenterX[2] = ((hv_CornerX.TupleSelect(3)) + (hv_CornerX.TupleSelect(2))) * 0.5;
            //
            //矩形第四条边中心坐标
            if (hv_LineCenterY == null)
                hv_LineCenterY = new HTuple();
            hv_LineCenterY[3] = ((hv_CornerY.TupleSelect(0)) + (hv_CornerY.TupleSelect(3))) * 0.5;
            if (hv_LineCenterX == null)
                hv_LineCenterX = new HTuple();
            hv_LineCenterX[3] = ((hv_CornerX.TupleSelect(0)) + (hv_CornerX.TupleSelect(3))) * 0.5;
            //
            //

            return;

        }

        /// <summary>
        /// region转直线参数
        /// </summary>
        /// <param name="ho_Region">用于转换的region</param>
        /// <param name="rake_width">rake直线所需宽度</param>
        /// <param name="hv_Row1">短边中点Row1</param>
        /// <param name="hv_Column1">短边中点Column1</param>
        /// <param name="hv_Row2">短边中点Row2</param>
        /// <param name="hv_Column2">短边中点Column2</param>
        /// <param name="rake_num">rake直线所需数量</param>
        ///  <param name="iScanDir">扫描方向 0上到下 1下到上 2左到右 3右到左</param>
        ///  <param name="iMinPixel">//扫描间隔像素</param>
        /// <returns></returns>
        public  bool RegionToLine(HObject ho_Region,                                         
                                         out HTuple rake_width,
                                         out HTuple rake_Height,
                                         out HTuple hv_Row1,
                                         out HTuple hv_Column1,
                                         out HTuple hv_Row2,
                                         out HTuple hv_Column2,
                                         out HTuple rake_num,
                                         int iScanDir = 0,
                                         int iMinPixel = 5
                                       )
        {
            if (iMinPixel <= 0)
                iMinPixel = 5;

            HTuple center_Row, center_Column1, ang, length1, length2, hv_CornerY, hv_CornerX, hv_LineCenterY, hv_LineCenterX, distance1, distance2;
            HOperatorSet.SmallestRectangle2(ho_Region, out center_Row, out  center_Column1, out ang,
                                            out length1,//长边一半
                                            out length2//短边一半
                                            );

            get_rectangle2_points_tlf(center_Row, center_Column1, ang, length1, length2, out hv_CornerY, out hv_CornerX, out hv_LineCenterY, out hv_LineCenterX);

            HOperatorSet.DistancePp(hv_LineCenterY[0], hv_LineCenterX[0], hv_LineCenterY[2], hv_LineCenterX[2], out distance1);
            HOperatorSet.DistancePp(hv_LineCenterY[1], hv_LineCenterX[1], hv_LineCenterY[3], hv_LineCenterX[3], out distance2);

            HTuple abs_X, abs_Y, lineX1, lineX3,lineY1,lineY3;

            lineX1 = hv_LineCenterX[1];
            lineX3 = hv_LineCenterX[3];
            lineY1 = hv_LineCenterY[1];
            lineY3 = hv_LineCenterY[3];


            HOperatorSet.TupleAbs(lineX1 - lineX3, out abs_X);
            HOperatorSet.TupleAbs(lineY1 - lineY3, out abs_Y);

            //if (distance1 > distance2)//找长边，用于rake 
            //hv_LineCenterX[0]，hv_LineCenterY[0]默认为短边中点，所以默认distance1 < distance2
           
                rake_num = distance2 / iMinPixel;
           
                if (abs_X<abs_Y)
                {
                    if (2 == iScanDir)
                    {
                        hv_Row1 = hv_LineCenterY[1];
                        hv_Column1 = hv_LineCenterX[1];
                        hv_Row2 = hv_LineCenterY[3];
                        hv_Column2 = hv_LineCenterX[3];
                    }
                    else
                    {
                        hv_Row1 = hv_LineCenterY[3];
                        hv_Column1 = hv_LineCenterX[3];
                        hv_Row2 = hv_LineCenterY[1];
                        hv_Column2 = hv_LineCenterX[1];
                    }
                }
                else
                {
                    if (0 == iScanDir)
                    {
                        hv_Row1 = hv_LineCenterY[1];
                        hv_Column1 = hv_LineCenterX[1];
                        hv_Row2 = hv_LineCenterY[3];
                        hv_Column2 = hv_LineCenterX[3];
                    }
                    else
                    {
                        hv_Row1 = hv_LineCenterY[3];
                        hv_Column1 = hv_LineCenterX[3];
                        hv_Row2 = hv_LineCenterY[1];
                        hv_Column2 = hv_LineCenterX[1];
                    }

                }
            if (length1 > length2)//找短边用于rake卡尺宽度
            {
                rake_width = length2 ;
                rake_Height = length1;
            }
            else
            {
                rake_width = length1;
                rake_Height = length2;
            }

            return true;
        }

        public void PointToRectangle1(  ref  HObject hv_Region,
                                          HTuple hv_Row1,
                                          HTuple hv_Column1,
                                          HTuple hv_Row2,
                                          HTuple hv_Column2,
                                          HTuple hv_width
                                     )

        {
            HTuple abs_X, abs_Y, row1=0, column1=0, row2=0, column2=0;

            HOperatorSet.TupleAbs(hv_Row1 - hv_Row2, out abs_X);
            HOperatorSet.TupleAbs(hv_Column1 - hv_Column2, out abs_Y);
            
            if (abs_X < abs_Y)
            {
                hv_Row1 -= hv_width;
                hv_Row2 += hv_width;
                if (hv_Column2 > hv_Column1)
                    HOperatorSet.GenRectangle1(out hv_Region, hv_Row1, hv_Column1, hv_Row2, hv_Column2);
                else 
                    HOperatorSet.GenRectangle1(out hv_Region,hv_Row1, hv_Column2, hv_Row2, hv_Column1 );//第一点必须比第二点的XY值要小，否则会参数报错
            }
            else
            {
                hv_Column1 += hv_width;
                hv_Column2 -= hv_width;
                if (hv_Row1 > hv_Row2)
                     HOperatorSet.GenRectangle1(out hv_Region, hv_Row2, hv_Column2, hv_Row1, hv_Column1);
                else
                     HOperatorSet.GenRectangle1(out hv_Region, hv_Row1, hv_Column2, hv_Row2, hv_Column1);
            }
        }

        public void UpdateImage(HObject Image,			//图像
                       ref  HObject objDisp,		//显示图形
                        HTuple hWindowHandle,	//窗口句柄
                        bool bInitial = false			//是否对图形进行初始化操作
                        )
        {
            //复位显示图形
            if (bInitial == true)
            {
                objDisp.Dispose();
                HOperatorSet.GenEmptyObj(out objDisp);
            }
            //清楚显示窗口
            //	HOperatorSet.ClearWindow(hWindowHandle);
            //显示图像
            HOperatorSet.DispObj(Image, hWindowHandle);
            //显示图形
            if (objDisp.IsInitialized() && !bInitial)
            {
                HOperatorSet.DispObj(objDisp, hWindowHandle);
            }
        }

        public void Concat_Obj(ref HObject Obj1, ref HObject Obj2, ref  HObject Obj3)
        {
            if (!Obj1.IsInitialized())
            {
                HOperatorSet.GenEmptyObj(out  Obj1);
            }
            if (!Obj2.IsInitialized())
            {
                HOperatorSet.GenEmptyObj(out Obj2);
            }
            {
                HOperatorSet.ConcatObj(Obj1, Obj2, out Obj3);
                HTuple Count = Obj3.CountObj();
            }
        }

      

    }
}
