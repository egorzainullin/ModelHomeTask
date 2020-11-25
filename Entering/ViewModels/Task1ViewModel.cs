using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;
using Entering.Annotations;

namespace Entering.ViewModels
{
    public class Task1ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public Complex ZValue { get; set; }

        public string Test { get; set; } 
    }
}