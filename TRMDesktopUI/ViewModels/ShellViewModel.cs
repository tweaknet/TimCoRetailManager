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
        private LoginViewModel _loginVM;
        private IEventAggregator _events;
        private SalesViewModel _salesVM;
        private SimpleContainer _container;
        public ShellViewModel(LoginViewModel loginVM, IEventAggregator events, SalesViewModel salesVM, SimpleContainer container)
        {
            _events = events;
            _events.SubscribeOnUIThread(this);// .Subscribe(this);
            _salesVM = salesVM;
            _loginVM = loginVM;
            _container = container;
            ActivateItemAsync(_loginVM);
        }

        public Task HandleAsync(LogOnEvent message, CancellationToken cancellationToken)
        {
            _loginVM = _container.GetInstance<LoginViewModel>();
            return ActivateItemAsync(_salesVM);
        }
    }
}
