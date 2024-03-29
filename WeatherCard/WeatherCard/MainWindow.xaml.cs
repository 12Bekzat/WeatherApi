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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WeatherCard
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Search()
		{
			string city = cityTextBox.Text;

			WeatherAPIService weatherAPI = new WeatherAPIService(city);

			if(weatherAPI.xmlDocument == null)
			{
				MessageBox.Show("Введен неверный город");
				return;
			}

			WeatherData weather = new WeatherData(city);

			List<DayTemperature> dayTemperatures = weather.GetWeather();

			listBox.ItemsSource = dayTemperatures;
		}

		private void cityTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				Search();
				e.Handled = true;
			}
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			cityTextBox.Focus();
		}
	}
}
