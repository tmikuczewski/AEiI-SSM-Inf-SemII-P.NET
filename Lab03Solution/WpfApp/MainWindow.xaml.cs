using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

using Res = WpfApp.Properties.Resources;

namespace WpfApp
{
	public partial class MainWindow
	{
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
			if (MessageBox.Show(Res.CloseConfirmation, Res.Exit, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
			{
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
				case "Exit":
					Close();
					break;
				default:
					return;
			}
		}
	}
}