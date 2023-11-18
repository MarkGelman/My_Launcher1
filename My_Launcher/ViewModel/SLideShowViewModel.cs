using My_Launcher.Model;
using My_Launcher.Model.DB;
using My_Launcher.Model.IHelper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace My_Launcher.ViewModel
{
    internal class SlideShowViewModel : ForPropertyChanged
    {
        private ObservableCollection<SlideShowModel> images;
        ImageFileProvider imageFileProvider;
        private DispatcherTimer timer;

        public string pathToTopImageFiles = "view/res/top";
        public string pathToBackImageFiles = "view/res/background";
        private int currentIndex = 0;
        
     
        public SlideShowViewModel()
        {
            imageFileProvider = new ImageFileProvider();
            var topImagesPathsList = imageFileProvider.GetImageFilesPaths(pathToTopImageFiles);
            var backgroundImagesPathsList = imageFileProvider.GetImageFilesPaths(pathToBackImageFiles);
            Images = new ObservableCollection<SlideShowModel>();

            foreach (var topImageFile in topImagesPathsList)
                foreach (var backImageFile in backgroundImagesPathsList)
                    if (topImageFile == backImageFile)
                        Images.Add(
                            new SlideShowModel { pathToBackImageFile = backImageFile, pathToTopImageFile = topImageFile });
                       
            // Настройка таймера для автоматической смены слайдов
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5); // Интервал смены слайдов (5 секунд в данном случае)
            timer.Tick += (sender, e) => NextSlide();
            timer.Start();
        }

        public ObservableCollection<SlideShowModel> Images
        {
            get { return images; }
            set
            {
                images = value;
                OnPropertyChanged(nameof(Images));
            }
        }

        public int CurrentIndex
        {
            get { return currentIndex; }
            set
            {
                currentIndex = value;
                OnPropertyChanged(nameof(CurrentIndex));
            }
        }

        

        // Метод для переключения к следующему слайду
        public void NextSlide()
        {
            if (CurrentIndex < Images.Count - 1)
            {
                CurrentIndex++;
            }
            else
            {
                CurrentIndex = 0; // Вернуться к первому слайду, если достигнут конец списка
            }
        }

        private void Load_LoginForm()
        {
           
        }
    }

}
