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
    public class RefBooksViewModel : TabViewModel
    {
        public ReactiveCommand<Unit, Unit> AnswersCmd { get; }
        
        public RefBooksViewModel()
        {
            AnswersCmd = ReactiveCommand.Create(OnAnswers);
        }
        //public RefBooksViewModel(int q)
        //{
        //    Title      = "int";
        //    AnswersCmd = ReactiveCommand.Create(OnAnswers);
        //}
        //public RefBooksViewModel(string q)
        //{
        //    Title      = "string";
        //    AnswersCmd = ReactiveCommand.Create(OnAnswers);
        //}
        //public RefBooksViewModel(string q, int w)
        //{
        //    Title      = "String Int";
        //    AnswersCmd = ReactiveCommand.Create(OnAnswers);
        //}

        private void OnAnswers()
        {
            //TabViewControl.SwitchView(TabViewControl.Tree.Root);
        }
    }
}
