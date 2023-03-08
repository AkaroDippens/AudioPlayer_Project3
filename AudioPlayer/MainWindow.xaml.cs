using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using static System.Net.WebRequestMethods;

namespace AudioPlayer
{
    public partial class MainWindow : Window
    {
        List<string> listok = new List<string>();
        public static string[] files;
        MediaPlayer mediaPlayer = new MediaPlayer();
        /*List<string> songs = new List<string>();*/
        public MainWindow()
        {
            InitializeComponent();
            mediaPlayer = new MediaPlayer();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*  OpenFileDialog ofd = new OpenFileDialog();*/
            /*var dialog = new CommonOpenFileDialog { IsFolderPicker = true };
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                files = Directory.GetFiles(dialog.FileName).ToList();
                foreach (string file in files) //Только mp3 файлы добавляются в ListBox
                {
                    if (file.Contains(".mp3"))
                    {
                        songPaths.Add(file.Substring(42));
                    }
                }
            }*/
            Task volumeUpdateTask = VolumeUpdateAsync();
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.CheckFileExists = false;
            dlg.CheckPathExists = true;
            dlg.FileName = "Folder Selection";
            dlg.Filter = "Folders|no.files";

            if (dlg.ShowDialog() == true)
            {
                string folderPath = Path.GetDirectoryName(dlg.FileName);

                files = Directory.GetFiles(folderPath, "*.*", SearchOption.TopDirectoryOnly).Where(file => file.ToLower().EndsWith(".mp3") ||
                                                        file.ToLower().EndsWith(".m4a") ||
                                                        file.ToLower().EndsWith(".wav") ||
                                                        file.ToLower().EndsWith(".pcm")).ToArray();

                if (files.Length > 0)
                {
                    int n = 0;
                    var trackTitles = files.Select(file => Path.GetFileNameWithoutExtension(file)).ToList();
                    /*Listik.ItemsSource = trackTitles;*/
                    Listik.ItemsSource = trackTitles;
                    string selectsong = (string)Listik.SelectedItem;
                    while (n < files.Length)
                    {
                        if (files[n] == selectsong)
                        {
                            mediaPlayer.Open(new Uri(files[0]));
                            mediaPlayer.Play();
                        }
                        else
                        {
                            n++;
                        }
                        
                    }
                }
                else
                {
                    MessageBox.Show("В выбранной папке нет поддерживаемых аудиозаписей");
                }
            }

            /*media.Source = new Uri(ofd.FileName);
            string col = ofd.FileName;
            string sub = col.Substring(42);*/
            /*textview.Items.Add(sub);*/
           
            media.LoadedBehavior = MediaState.Manual;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {  
            if (media.Source != null)
            {
                if (mediaPlayer.NaturalDuration.HasTimeSpan)
                {
                    Status.Content = String.Format("{0} / {1}",
                        mediaPlayer.Position.ToString(@"mm\:ss"),
                        mediaPlayer.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
                }
                else
                {
                    return;
                }
            }
            else
            {
                Status.Content = "Файл не найден";
            }
        }
        

        private void btn_play_Click(object sender, RoutedEventArgs e)
        {
            media.Play();
            mediaPlayer.Play();
        }

        private void btn_pause_Click(object sender, RoutedEventArgs e)
        {
            media.Pause();
            mediaPlayer.Pause();
        }
        private void btn_stop_Click(object sender, RoutedEventArgs e)
        {
            media.Stop();
            mediaPlayer.Stop();
        }

        private async Task VolumeUpdateAsync()
        {
            while (true)
            {
                await Task.Delay(500);
                Application.Current.Dispatcher.Invoke(() =>
                {
                    volumeSlider.Value = mediaPlayer.Volume;
                });
            }
        }
        private void ChangeMediaVolume(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (mediaPlayer != null)
                mediaPlayer.Volume = (double)volumeSlider.Value;
            if (media != null)
                media.Volume = (double)volumeSlider.Value;
        }
        private void mediaElem(object sender, RoutedEventArgs e)
        {
            audio_Slider.Maximum = media.NaturalDuration.TimeSpan.TotalSeconds;
            if (mediaPlayer.NaturalDuration.HasTimeSpan)
            {
                audio_Slider.Maximum = mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
            }
            else
            {
                return;
            }
        }
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mediaPlayer.Position = TimeSpan.FromSeconds(audio_Slider.Value);
            media.Position = TimeSpan.FromSeconds(audio_Slider.Value);
        }
        private void ListBox_Changed(object sender, SelectionChangedEventArgs e)
        {
            string path = @"C:\Users\mirzo\Downloads\Telegram Desktop\";
            string selectedSong = (string)Listik.SelectedItem;
            string[] files = Directory.GetFiles(path);
            foreach(string item in files)
            {
                if (Path.GetFileName(item).Contains(selectedSong))
                {
                    media.Source = new Uri(item);
                    mediaPlayer.Play();
                    media.Play();
                    mediaPlayer.MediaEnded += MediaEnded;
                    break;
                }
                else
                {
                    media.Stop();
                    mediaPlayer.Stop();
                }
            }
           /* while (n < files.Length)
            {
                Lable.Content = selectedSong;
                if (files[n] == selectedSong)
                {
                    
                    media.Source = new Uri(selectedSong);
                    media.Play();
                    break;
                }
                else
                {
                    n++;
                }
            }*/
        }
        private void MediaEnded(object sender, EventArgs e)
        {
            int nextSongIndex = Listik.SelectedIndex + 1;
            if (nextSongIndex < Listik.Items.Count)
            {
                Listik.SelectedIndex = nextSongIndex;
                string nextSong = (string)Listik.SelectedItem;
                media.Source = new Uri(nextSong);
                mediaPlayer.Play();
            }
            else if (nextSongIndex >= Listik.Items.Count)
            {
                nextSongIndex = 0;
                Listik.SelectedIndex = nextSongIndex;
                string nextSong = (string)Listik.SelectedItem;
                media.Source = new Uri(nextSong);
                mediaPlayer.Play();
            }
        }
    }
}