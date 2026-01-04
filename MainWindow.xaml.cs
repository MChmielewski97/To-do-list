using System.Collections.Generic;
using System.Linq;
using System.Windows;
using WpfCrudApp.Models;
using WpfCrudApp.Services;

namespace WpfCrudApp
{
    public partial class MainWindow : Window
    {
        private List<TaskItem> tasks = new();

        public MainWindow()
        {
            InitializeComponent();
            tasks = FileService.Load();
            RefreshList();
        }

        private void RefreshList()
        {
            TasksList.ItemsSource = null;
            TasksList.ItemsSource = tasks;
        }

        private bool Validate()
        {
            if (string.IsNullOrWhiteSpace(TitleBox.Text))
            {
                MessageBox.Show("Tytuł jest wymagany!");
                return false;
            }
            return true;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (!Validate()) return;

            tasks.Add(new TaskItem
            {
                Title = TitleBox.Text,
                Description = DescriptionBox.Text,
                DueDate = DueDatePicker.SelectedDate ?? System.DateTime.Now
            });

            FileService.Save(tasks);
            RefreshList();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (TasksList.SelectedItem is not TaskItem task || !Validate()) return;

            task.Title = TitleBox.Text;
            task.Description = DescriptionBox.Text;
            task.DueDate = DueDatePicker.SelectedDate ?? task.DueDate;

            FileService.Save(tasks);
            RefreshList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (TasksList.SelectedItem is not TaskItem task) return;

            tasks.Remove(task);
            FileService.Save(tasks);
            RefreshList();
        }

        private void TasksList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (TasksList.SelectedItem is not TaskItem task) return;

            TitleBox.Text = task.Title;
            DescriptionBox.Text = task.Description;
            DueDatePicker.SelectedDate = task.DueDate;
        }

        private void SearchBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            var query = SearchBox.Text.ToLower();
            TasksList.ItemsSource = tasks
                .Where(t => t.Title.ToLower().Contains(query))
                .ToList();
        }
    }
}
