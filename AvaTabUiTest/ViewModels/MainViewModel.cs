using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using AvaTabUiTest.MarinosEntities;
using AvaTabUiTest.Utils.Impl.ViewModel;
using ReactiveUI;

namespace AvaTabUiTest.ViewModels
{
    public class MainViewModel : TabViewModel
    {
        public ReactiveCommand<Unit, Unit> RefBooksCmd { get; }
        public ReactiveCommand<Unit, Unit> STSiKCmd    { get; }
        public ReactiveCommand<Unit, Unit> SMSCmd      { get; }


        public MainViewModel()
        {
            RefBooksCmd = ReactiveCommand.Create(OnRefBooks);
            STSiKCmd    = ReactiveCommand.Create(OnSTSiK);
            SMSCmd      = ReactiveCommand.Create(OnSMS);
        }

        private void OnSMS()
        {

        }

        private void OnSTSiK()
        {

        }

        private void OnRefBooks()
        {
            this.AddAndSwitchView(() => new RefBooksViewModel());
        }
    }
}
