using System;
using System.Reactive;
using Avalonia.Controls;
using AvaloniaApplication2.ViewModels;

namespace AvaloniaApplication2.Views
{
    public partial class MainWindow : Window
    {
        private bool bInit = true;
        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnDataContextChanged(EventArgs e)
        {
            base.OnDataContextChanged(e);

            MainWindowViewModel? viewModel = DataContext as MainWindowViewModel;

            if (bInit && viewModel != null)
            {
                bInit = false;
                viewModel.Init(this);
            }
        }
    }
}