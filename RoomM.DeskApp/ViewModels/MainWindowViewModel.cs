using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Diagnostics;
using System.IO;
using System.Windows;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using RoomM.DeskApp.UIHelper;
using RoomM.DeskApp.Views;

namespace RoomM.DeskApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public static MainWindowViewModel instance;
        public const string READY = "sẵn sàng";
        public const string WAIT = "xin đợi...";
        public const string COMPLETE = "hoàn thành";

        public const int DARKSLATEGRAY = 0;
        public const int BLUE = 1;
        public const int ORAGNE = 2;


        public string statusState;
        public string statusExpend;

        public SolidColorBrush statusColor;


        public MainWindowViewModel() : base()
        {
            MainWindowViewModel.instance = this;
            this.StatusState = READY;
            this.StatusExpend = "";
            this.StatusColor = Brushes.DarkSlateGray;

            Console.WriteLine(Brushes.DarkSlateGray.ToString());


            // setup bkg color
            switch (Properties.Settings.Default.BkgColor) 
            {
                case DARKSLATEGRAY:
                    this.StatusColor = Brushes.DarkSlateGray;
                    break;
                case BLUE:
                    this.StatusColor = Brushes.DarkBlue;
                    break;
                case ORAGNE:
                    this.StatusColor = Brushes.DarkOrange;
                    break;
                default :
                    this.StatusColor = Brushes.DarkSlateGray;
                    break;
            }


            // Properties.Settings.Default.BkgColor = Brushes.DarkSlateGray;
            // Properties.Settings.Default.Save();
            // Console.WriteLine("###" + Properties.Settings.Default.BkgColor);

        }

        protected bool CanExecute() { return true; }

        public string StatusState 
        {
            get { return this.statusState; }
            set 
            {
                if (this.statusState != value)
                {
                    Console.WriteLine("change: " + value);

                    this.statusState = value;
                    this.RaisePropertyChanged(() => this.StatusState);
                }
            }
        }

        public string StatusExpend
        {
            get { return this.statusExpend; }
            set
            {
                if (this.statusExpend != value)
                {
                    this.statusExpend = value;
                    this.RaisePropertyChanged(() => this.StatusExpend);
                }
            }
        }

        public SolidColorBrush StatusColor
        {
            get { return this.statusColor; }
            set
            {
                if (this.statusColor != value)
                {
                    this.statusColor = value;
                    this.RaisePropertyChanged(() => this.StatusColor);
                }
            
            }
        }

        public void ChangeStateToReady(string expend = "")
        {
            this.StatusState = READY;
            this.StatusExpend = expend;
        }

        public void ChangeStateToComplete(string expend = "")
        {
            this.StatusState = COMPLETE;
            this.StatusExpend = expend;
        }

        public void ChangeStateToWait(string expend = "")
        {
            this.StatusState = WAIT;
            this.StatusExpend = expend;
        }

        //command

        public ICommand FakeCommand { get { return new RelayCommand(FakeCommandHandler, CanExecute); } }

        private void FakeCommandHandler()
        {
            Console.WriteLine("click");
            this.StatusExpend = "asbdjbakjsdkasndknaskdnklasdkl";
        }

        public ICommand BkgGrayCommand { get { return new RelayCommand(BkgGrayHandler, CanExecute); } }

        private void BkgGrayHandler()
        {
            this.StatusColor = Brushes.DarkSlateGray;
            Properties.Settings.Default.BkgColor = DARKSLATEGRAY;
            Properties.Settings.Default.Save();
        }

        public ICommand BkgBlueCommand { get { return new RelayCommand(BkgBlueHandler, CanExecute); } }

        private void BkgBlueHandler()
        {
            this.StatusColor = Brushes.DarkBlue;
            Properties.Settings.Default.BkgColor = BLUE;
            Properties.Settings.Default.Save();
        }

        public ICommand BkgOrangeCommand { get { return new RelayCommand(BkgOrangeHandler, CanExecute); } }

        private void BkgOrangeHandler()
        {
            this.StatusColor = Brushes.DarkOrange;
            Properties.Settings.Default.BkgColor = ORAGNE;
            Properties.Settings.Default.Save();
        }

        public ICommand HelpBookCommand { get { return new RelayCommand(HelpBookCommandHandler, CanExecute); } }

        private void HelpBookCommandHandler()
        {
            string dirpath = AppDomain.CurrentDomain.BaseDirectory;
            Process.Start(dirpath + "\\HelpBooks\\HelpBook.docx");
        }

        public ICommand AboutCommand { get { return new RelayCommand(AboutCommandHandler, CanExecute); } }

        private void AboutCommandHandler()
        {
            (new About()).ShowDialog();
        }

        public ICommand ExitCommand { get { return new RelayCommand(ExitCommandHandler, CanExecute); } }

        private void ExitCommandHandler()
        {
            Window window = System.Windows.Application.Current.Windows.OfType<Window>().Where(w => w.Name == "MainWindowForApp").FirstOrDefault();
            if (window != null) window.Close();
        }

    }
}
