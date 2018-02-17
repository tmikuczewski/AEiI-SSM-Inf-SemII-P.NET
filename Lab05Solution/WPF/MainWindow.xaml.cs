using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

using Res = WPF.Properties.Resources;
using WPF.ServiceDALReference;
using DALService = WPF.ServiceDALReference.ServiceDALClient;

namespace WPF
{
	public partial class MainWindow
	{
		private readonly DALService _service = new DALService();

		public ObservableCollection<Person> People = new ObservableCollection<Person>();

		static MainWindow()
		{
			CultureInfo currentCulture = CultureInfo.CurrentCulture;
			Thread.CurrentThread.CurrentCulture = currentCulture;
			Thread.CurrentThread.CurrentUICulture = currentCulture;
		}

		public MainWindow()
		{
			InitializeComponent();

			this._service.Open();

			LoadPeople();
		}

		private void LoadPeople()
		{
			this.ListView.Items.Clear();
			foreach (Person person in this._service.GetPeople())
			{
				person.Password = "********";
				this.ListView.Items.Add(person);
			}
		}

		private void LoginButton_Click(object sender, RoutedEventArgs e)
		{
			string username = this.LoginUsernameTextBox.Text,
				password = this.LoginPasswordTextBox.Text;

			Person person = this._service.Find(username, password);
			if (person != null)
			{
				this.LoginTextBlock.Text = person.Name;
				this.StatusBarItem.Content = Res.Ready;
			}
			else
			{
				this.LoginTextBlock.Text = string.Empty;
				this.StatusBarItem.Content = Res.UserNotFound;
			}
		}

		private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if ((sender as ListView)?.SelectedItem is Person person)
			{
				this.UsernameTextBox.Text = person.Username;
				this.PasswordTextBox.Text = string.Empty;
				this.NameTextBox.Text = person.Name;
			}
		}

		private void AddButton_Click(object sender, RoutedEventArgs e)
		{
			string username = this.UsernameTextBox.Text,
				password = this.PasswordTextBox.Text,
				name = this.NameTextBox.Text;

			if (!string.IsNullOrEmpty(username)
			    && !string.IsNullOrEmpty(password)
			    && !string.IsNullOrEmpty(this.NameTextBox.Text))
			{
				Person person = this._service.Find(username, null);
				if (person == null)
				{
					if (this._service.AddPerson(new Person
					{
						Username = username,
						Password = password,
						Name = name
					}))
					{
						LoadPeople();
						this.StatusBarItem.Content = Res.Ready;
					}
					else
					{
						this.StatusBarItem.Content = Res.UserExists;
					}
				}
			}
		}

		private void EditButton_Click(object sender, RoutedEventArgs e)
		{
			if ((this.ListView.SelectedIndex != -1) && !string.IsNullOrEmpty(this.PasswordTextBox.Text))
			{
				var person = (Person) this.ListView.SelectedItem;

				string username = this.UsernameTextBox.Text,
					password = this.PasswordTextBox.Text,
					name = this.NameTextBox.Text;

				person.Username = username;
				person.Password = password;
				person.Name = name;

				if (this._service.EditPerson(person))
				{
					LoadPeople();
					this.StatusBarItem.Content = Res.Ready;
				}
				else
				{
					this.StatusBarItem.Content = Res.UserNotFound;
				}
			}
		}

		private void DeleteButton_Click(object sender, RoutedEventArgs e)
		{
			if (this.ListView.SelectedIndex != -1)
			{
				var person = (Person) this.ListView.SelectedItem;

				if (this._service.RemovePerson(person.Id))
				{
					LoadPeople();
					this.StatusBarItem.Content = Res.Ready;
				}
			}
		}

		protected override void OnClosed(EventArgs e)
		{
			this._service.Close();
			base.OnClosed(e);
		}
	}
}