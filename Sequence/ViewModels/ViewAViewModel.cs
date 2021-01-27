using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsingEventAggregator.Core;

namespace Sequence.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        IEventAggregator _ea;
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public ViewAViewModel(IEventAggregator ea)
        {
            Message = "View A from your Prism Module";
            _ea = ea;
            _ea.GetEvent<MessageSentEvent>().Subscribe(MessageReceived);
        }
        private void MessageReceived(string message)
        {
           this.Message= message;
            Debug.WriteLine(this.Message);
        }
    }
}
