using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Avalonia.Media;
using Avalonia.Media.Imaging;

namespace Lab_8_Kanban.Models
{
	public class Tasks : INotifyPropertyChanged
    {
		public event PropertyChangedEventHandler PropertyChanged;

		protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
			else return;
		}

		string title;
		public string Title
		{
			get { return title; }
			set { title = value; NotifyPropertyChanged(); }
		}

		string notes;
		public string Notes
		{
			get { return notes; }
			set { notes = value; NotifyPropertyChanged(); }
		}

		Bitmap img;
		
		public Bitmap Img
		{
			get { return img; }
			set 
			{
				img = value;
				NotifyPropertyChanged(); 
			}
		}

		string imgName;
		public string ImgName
		{
			get { return imgName; }
			set
			{
				imgName = value;
				NotifyPropertyChanged();
			}
		}
		public Tasks(string ti, string not, string im)
        {
			title = ti;
			notes = not;
			imgName = im;
			var image = new Bitmap(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + im.ToString());
			img = image;
        }
	}
}
