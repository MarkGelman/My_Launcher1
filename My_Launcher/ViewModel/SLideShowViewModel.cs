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

            // Setting up a timer for automatically changing slides
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5); // Slide change interval (5 seconds in this case)
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



        // Method for switching to next slide
        public void NextSlide()
        {
            if (CurrentIndex < Images.Count - 1)
            {
                CurrentIndex++;
            }
            else
            {
                CurrentIndex = 0; // Return to the first slide if the end of the list is reached
            }
        }

        private void Load_LoginForm()
        {
           
        }
    }

}
