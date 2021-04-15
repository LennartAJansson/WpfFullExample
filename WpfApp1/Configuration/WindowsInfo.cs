﻿using System.Windows;

namespace WpfApp1.Configuration
{
    public class WindowsInfo
    {
        public const string SectionName = "WindowsInfo";

        public double Height { get; set; }

        public double Width { get; set; }

        public double Left { get; set; }

        public double Top { get; set; }

        public WindowState State { get; set; }
    }
}