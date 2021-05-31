using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DifferenzXamarinDemo.Services
{
    public class LayoutService
    {
        static LayoutService()
        {

            FontSize08 = sizeConvertAsPerDevice(08);
            FontSize10 = sizeConvertAsPerDevice(10);
            FontSize11 = sizeConvertAsPerDevice(11);
            FontSize12 = sizeConvertAsPerDevice(12);
            FontSize13 = sizeConvertAsPerDevice(13);
            FontSize14 = sizeConvertAsPerDevice(14);
            FontSize15 = sizeConvertAsPerDevice(15);
            FontSize16 = sizeConvertAsPerDevice(16);
            FontSize17 = sizeConvertAsPerDevice(17);
            FontSize18 = sizeConvertAsPerDevice(18);
            FontSize20 = sizeConvertAsPerDevice(20);
            FontSize22 = sizeConvertAsPerDevice(22);
            FontSize24 = sizeConvertAsPerDevice(24);
            FontSize25 = sizeConvertAsPerDevice(25);
            FontSize26 = sizeConvertAsPerDevice(26);
            FontSize30 = sizeConvertAsPerDevice(30);
            FontSize40 = sizeConvertAsPerDevice(40);
            FontSize50 = sizeConvertAsPerDevice(50);
            FontSize60 = sizeConvertAsPerDevice(60);
            FontSize70 = sizeConvertAsPerDevice(70);
            FontSize80 = sizeConvertAsPerDevice(80);
            FontSize100 = sizeConvertAsPerDevice(100);
            FontSize130 = sizeConvertAsPerDevice(130);

            HeightWidth1 = sizeConvertAsPerDevice(1);
            HeightWidth3 = sizeConvertAsPerDevice(3);
            HeightWidth15 = sizeConvertAsPerDevice(15);
            HeightWidth20 = sizeConvertAsPerDevice(20);
            HeightWidth22 = sizeConvertAsPerDevice(22);
            HeightWidth25 = sizeConvertAsPerDevice(25);
            HeightWidth30 = sizeConvertAsPerDevice(30);
            HeightWidth40 = sizeConvertAsPerDevice(40);
            HeightWidth45 = sizeConvertAsPerDevice(45);
            HeightWidth50 = sizeConvertAsPerDevice(50);
            HeightWidth60 = sizeConvertAsPerDevice(60);
            HeightWidth70 = sizeConvertAsPerDevice(70);
            HeightWidth80 = sizeConvertAsPerDevice(80);
            HeightWidth90 = sizeConvertAsPerDevice(90);
            HeightWidth100 = sizeConvertAsPerDevice(100);
            HeightWidth120 = sizeConvertAsPerDevice(120);
            HeightWidth130 = sizeConvertAsPerDevice(130);
            HeightWidth150 = sizeConvertAsPerDevice(150);
            HeightWidth180 = sizeConvertAsPerDevice(180);
            HeightWidth200 = sizeConvertAsPerDevice(200);
            HeightWidth300 = sizeConvertAsPerDevice(300);
            HeightWidth400 = sizeConvertAsPerDevice(400);

            ButtonCornerRadius10 = (int)sizeConvertAsPerDevice(10);
            ButtonCornerRadius15 = (int)sizeConvertAsPerDevice(15);
            ButtonCornerRadius25 = (int)sizeConvertAsPerDevice(25);
        }

        static double SmallDeviceSize = 700;

        static double CalculateSize(double val, double d)
        {
            if (d == 0)
            {
                return val;
            }
            if (Device.Idiom == TargetIdiom.Phone)
            {
                if (val > 0)
                {
                    var half = val / d;
                    val = val - half;
                }
                else if (val < 0)
                {
                    var half = Math.Abs(val) / d;
                    val = -(Math.Abs(val) - half);
                }
            }
            else
            {
                if (val > 0)
                {
                    var half = val / d;
                    val = val + half;
                }
                else if (val < 0)
                {
                    var half = Math.Abs(val) / d;
                    val = -(Math.Abs(val) + half);
                }
            }
            return val;
        }

        public static double sizeConvertAsPerDevice(double size)
        {
            try
            {
                if (size <= 0) { return 0; }
                int d = 0;
                if (Device.Idiom == TargetIdiom.Phone)
                {

                    var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
                    var Height = mainDisplayInfo.Height / mainDisplayInfo.Density;

                    if (Device.RuntimePlatform == Device.iOS)
                    {
                        if (mainDisplayInfo.Height <= 1136)
                        {
                            d = 5;
                        }
                        else if (mainDisplayInfo.Height <= 1334)
                        {
                            d = 7;
                        }
                    }
                    else
                    {
                        if (Height <= SmallDeviceSize)
                        {
                            d = 4;
                        }
                    }
                }
                else
                {
                    d = 2;
                }
                size = CalculateSize(size, d);
            }
            catch (Exception exception)
            {
            }
            return size;
        }

        #region Font Size

        public static Double FontSize08 { get; set; }
        public static Double FontSize10 { get; set; }
        public static Double FontSize11 { get; set; }
        public static Double FontSize12 { get; set; }
        public static Double FontSize13 { get; set; }
        public static Double FontSize14 { get; set; }
        public static Double FontSize15 { get; set; }
        public static Double FontSize16 { get; set; }
        public static Double FontSize17 { get; set; }
        public static Double FontSize18 { get; set; }
        public static Double FontSize20 { get; set; }
        public static Double FontSize22 { get; set; }
        public static Double FontSize24 { get; set; }
        public static Double FontSize25 { get; set; }
        public static Double FontSize26 { get; set; }
        public static Double FontSize30 { get; set; }
        public static Double FontSize40 { get; set; }
        public static Double FontSize50 { get; set; }
        public static Double FontSize60 { get; set; }
        public static Double FontSize70 { get; set; }
        public static Double FontSize80 { get; set; }
        public static Double FontSize100 { get; set; }
        public static Double FontSize130 { get; set; }

        #endregion

        #region View Height Width

        public static Double HeightWidth1 { get; set; }
        public static Double HeightWidth3 { get; set; }
        public static Double HeightWidth15 { get; set; }
        public static Double HeightWidth20 { get; set; }
        public static Double HeightWidth22 { get; set; }
        public static Double HeightWidth25 { get; set; }
        public static Double HeightWidth30 { get; set; }
        public static Double HeightWidth40 { get; set; }
        public static Double HeightWidth45 { get; set; }
        public static Double HeightWidth50 { get; set; }
        public static Double HeightWidth60 { get; set; }
        public static Double HeightWidth70 { get; set; }
        public static Double HeightWidth80 { get; set; }
        public static Double HeightWidth90 { get; set; }
        public static Double HeightWidth100 { get; set; }
        public static Double HeightWidth120 { get; set; }
        public static Double HeightWidth130 { get; set; }
        public static Double HeightWidth150 { get; set; }
        public static Double HeightWidth180 { get; set; }
        public static Double HeightWidth200 { get; set; }
        public static Double HeightWidth300 { get; set; }
        public static Double HeightWidth400 { get; set; }

        #endregion

        #region Corner Radius
        
        public static int ButtonCornerRadius10 { get; set; }
        public static int ButtonCornerRadius15 { get; set; }
        public static int ButtonCornerRadius25 { get; set; }

        #endregion
    }
}
