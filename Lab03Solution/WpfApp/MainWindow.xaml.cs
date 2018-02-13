using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Win32;

using WpfApp.Code;
using Res = WpfApp.Properties.Resources;

namespace WpfApp
{
	public partial class MainWindow
	{
		private AboutWindow _aboutWindow;

		private int _count;
		private double _rangeFrom;
		private double _rangeTo;

		private bool _workInProgress;

		static MainWindow()
		{
			CultureInfo currentCulture = CultureInfo.CurrentCulture;
			Thread.CurrentThread.CurrentCulture = currentCulture;
			Thread.CurrentThread.CurrentUICulture = currentCulture;
		}

		public MainWindow()
		{
			InitializeComponent();
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			if (!this._workInProgress && MessageBox.Show(Res.CloseConfirmation, Res.Exit, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
			{
				this._aboutWindow?.Close();
				base.OnClosing(e);
			}
			else
			{
				e.Cancel = true;
			}
		}

		private void MenuItem_Click(object sender, RoutedEventArgs e)
		{
			switch (((MenuItem) e.Source).Name)
			{
				case "New":
					this.ListBox.Items.Clear();
					break;
				case "Load":
					LoadData();
					break;
				case "Save":
					SaveData();
					break;
				case "Exit":
					Close();
					break;
				case "About":
					this._aboutWindow = new AboutWindow();
					this._aboutWindow.Show();
					break;
				default:
					return;
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (!GetData())
			{
				return;
			}

			this.StartButton.IsEnabled = this.Load.IsEnabled = this.Save.IsEnabled = this.Exit.IsEnabled = false;
			this.StatusBarItem.Content = Res.Working;
			this.ProgressBar.Value = 0;
			this.ProgressBar.Maximum = this._count;

			this._workInProgress = true;

			new Thread(Generate).Start();
		}

		private bool GetData()
		{
			this.StatusBarItem.Content = Res.Ready;

			var errors = new List<string>();
			if (!int.TryParse(this.NoOfEltsTextBox.Text, out this._count))
			{
				errors.Add(Res.NoOfElements);
			}
			if (!double.TryParse(this.RangeFromTextBox.Text, out this._rangeFrom))
			{
				errors.Add(Res.RangeFrom);
			}
			if (!double.TryParse(this.RangeToTextBox.Text, out this._rangeTo))
			{
				errors.Add(Res.RangeTo);
			}

			if (!errors.Any())
			{
				return true;
			}

			this.StatusBarItem.Content = string.Format(errors.Count > 1 ? Res.Errors : Res.Error, string.Join(", ", errors));
			return false;
		}

		private void Generate()
		{
			var i = 0;
			foreach (double value in RandomGenerator.Generate(this._count, this._rangeFrom, this._rangeTo))
			{
				this.Dispatcher.Invoke(delegate
				{
					this.ListBox.Items.Add(value);
					this.ListBox.SelectedIndex = this.ListBox.Items.Count - 1;
					this.ListBox.ScrollIntoView(this.ListBox.SelectedItem);
					this.ListBox.UnselectAll();

					this.ProgressBar.Value = ++i;
				});
			}

			this.Dispatcher.Invoke(delegate
			{
				this.ProgressBar.Value = 0;
				this.ProgressBar.Maximum = 100;
				this.StatusBarItem.Content = Res.Ready;
				this.StartButton.IsEnabled = this.Load.IsEnabled = this.Save.IsEnabled = this.Exit.IsEnabled = true;

				this._workInProgress = false;
			});
		}

		private void LoadData()
		{
			if (!this._workInProgress)
			{
				var openFileDialog = new OpenFileDialog();
				if (openFileDialog.ShowDialog() == true)
				{
					foreach (string value in File.ReadAllLines(openFileDialog.FileName))
					{
						this.ListBox.Items.Add(value);
					}
				}
			}
		}

		private void SaveData()
		{
			if (!this._workInProgress)
			{
				var saveFileDialog = new SaveFileDialog();
				if (saveFileDialog.ShowDialog() == true)
				{
					File.WriteAllText(saveFileDialog.FileName, string.Join("\n", this.ListBox.Items.Cast<object>().Select(x => x.ToString())));
				}
			}
		}

		private void NewCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			this.ListBox.Items.Clear();
		}
		private void OpenCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			LoadData();
		}
		private void SaveCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			SaveData();
		}
		private void HelpCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			this._aboutWindow = new AboutWindow();
			this._aboutWindow.Show();
		}
	}
}