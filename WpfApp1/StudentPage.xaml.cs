﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// StudentPage.xaml 的交互逻辑
    /// </summary>
    public partial class StudentPage : Window
    {
        public StudentPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StudentChooseCourse www = new StudentChooseCourse();
            www.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            StudentDropCourse www = new StudentDropCourse();
            www.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            StudentCheckScore www = new StudentCheckScore();
            www.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainWindow www = new MainWindow();
            www.Show();
            this.Close();
        }
    }
}
