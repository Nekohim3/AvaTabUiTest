using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AvaTabUiTest.MarinosEntities;
using AvaTabUiTest.Utils.Base.Tree;
using AvaTabUiTest.Utils.Impl;
using AvaTabUiTest.Utils.Impl.Tree;
using AvaTabUiTest.Utils.Impl.ViewModel;
using AvaTabUiTest.ViewModels;
using AvaTabUiTest.Views;

namespace AvaTabUiTest
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            g.CurrentShip = Ship.GetById(1);
            //var q = new TreeViewModelCollection<TabWindowViewModel>(new Stsik(Ship.GetById(1)));
            //q.GetAllNodesByWindowViewModel(null);
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var wnd  = new TabWindow();
                var vm   = new TabWindowViewModel(wnd);
                var root = new MainViewModel();
                wnd.DataContext = vm;
                TabViewControl.Init();
                //desktop.MainWindow = new MainWindow
                //{
                //    DataContext = new MainWindowViewModel(),
                //};
            }

            base.OnFrameworkInitializationCompleted();
        }
    }

    public class Stsik : TabViewModel
    {
        public Stsik(Ship anchor, ViewNodeBase<Ship>? parent = null) : base(anchor, parent)
        {

        }
    }
}
