using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using TRMDesktopUI.EventsModels;

namespace TRMDesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
    {
        private IEventAggregator _events;
        private SalesViewModel _salesVM;
        public ShellViewModel(IEventAggregator events, SalesViewModel salesVM)
        {
            _events = events;
            _salesVM = salesVM;

            _events.SubscribeOnUIThread(this);
            ActivateItemAsync(IoC.Get<LoginViewModel>());
        }
        public Task HandleAsync(LogOnEvent message, CancellationToken cancellationToken)
        {
            return ActivateItemAsync(_salesVM);
        }
    }
}
