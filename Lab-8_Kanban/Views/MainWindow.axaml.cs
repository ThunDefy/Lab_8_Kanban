using Avalonia.Controls;
using Avalonia.Interactivity;
using Lab_8_Kanban.Models;
using Lab_8_Kanban.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using Avalonia.Media.Imaging;
using System.Reactive;

namespace Lab_8_Kanban.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            /*this.DataContext = new MainWindowViewModel();
            (this.DataContext as MainWindowViewModel).show = this;*/

            InitializeComponent();
            this.FindControl<MenuItem>("Exit").Click += ClickEventExit;
            this.FindControl<MenuItem>("About").Click += ClickEventAbout;
            this.FindControl<MenuItem>("Save").Click += ClickEventSave;
            this.FindControl<MenuItem>("Load").Click += ClickEventLoad;


        }

        private async void ClickEventExit(object? sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private async void ClickEventAbout(object? sender, RoutedEventArgs e)
        {
            await new About().ShowDialog((Window)this.VisualRoot);
            
        }

        private async void ClickEventSave(object? sender, RoutedEventArgs e)
        {
            string? path;
            var taskPath = new SaveFileDialog()
            {
                Title = "Save file",
                Filters = new List<FileDialogFilter>()
            };
            taskPath.Filters.Add(new FileDialogFilter() { Name = "Текстовый файл (.txt)", Extensions = { "txt" } });

            path = await taskPath.ShowAsync((Window)this.VisualRoot);
            if (path is not null)
            {

                var Pl = (this.DataContext as MainWindowViewModel).ItemsPlanned;
                var In = (this.DataContext as MainWindowViewModel).ItemsInWork;
                var Co = (this.DataContext as MainWindowViewModel).ItemsCompleted;
                using (StreamWriter wr = File.CreateText(path))
                {
                    wr.WriteLine(Pl.Count.ToString());
                    foreach (var item in Pl)
                    {
                        wr.WriteLine(item.Title);
                        wr.WriteLine(item.Notes);
                        wr.WriteLine(item.ImgName);
                    }
                    wr.WriteLine(In.Count.ToString());
                    foreach (var item in In)
                    {
                        wr.WriteLine(item.Title);
                        wr.WriteLine(item.Notes);
                        wr.WriteLine(item.ImgName);
                    }
                    wr.WriteLine(Co.Count.ToString());
                    foreach (var item in Co)
                    {
                        wr.WriteLine(item.Title);
                        wr.WriteLine(item.Notes);
                        wr.WriteLine(item.ImgName);
                    }

                }
                
            }
        }

        private async void ClickEventLoad(object? sender, RoutedEventArgs e)
        {
            string? path;
            var taskPath = new OpenFileDialog()
            {
                Title = "Open file",
                Filters = new List<FileDialogFilter>()
            };
            taskPath.Filters.Add(new FileDialogFilter() { Name = "TXT files", Extensions = { "txt" } });

            string[]? pathArray = await taskPath.ShowAsync((Window)this.VisualRoot);
            path = pathArray is null ? null : string.Join(@"\", pathArray);

            if (path != null)
            {
                var Pl = (this.DataContext as MainWindowViewModel).ItemsPlanned;
                var In = (this.DataContext as MainWindowViewModel).ItemsInWork;
                var Co = (this.DataContext as MainWindowViewModel).ItemsCompleted;
                Pl.Clear(); In.Clear(); Co.Clear();
                using (StreamReader sr = File.OpenText(path))
                {
                    int count;
                    if (!Int32.TryParse(sr.ReadLine(), out count)) return; // В первой строке должно быть количество студентов

                    for (int i = 0; i < count; i++)
                    {
                        Pl.Add(new Tasks(sr.ReadLine(), sr.ReadLine(), sr.ReadLine()));
                    }
                    count = 0;
                    if (!Int32.TryParse(sr.ReadLine(), out count)) return; // В первой строке должно быть количество студентов

                    for (int i = 0; i < count; i++)
                    {
                        In.Add(new Tasks(sr.ReadLine(), sr.ReadLine(), sr.ReadLine()));
                    }
                    count = 0;
                    if (!Int32.TryParse(sr.ReadLine(), out count)) return; // В первой строке должно быть количество студентов

                    for (int i = 0; i < count; i++)
                    {
                        Co.Add(new Tasks(sr.ReadLine(), sr.ReadLine(), sr.ReadLine()));
                    }

                }
            }
        }



    }
}
