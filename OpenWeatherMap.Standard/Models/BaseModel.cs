using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace OpenWeatherMap.Standard.Models
{
    /// <summary>
    /// BaseModel for, you know, Models
    /// </summary>
    [Serializable]
    public class BaseModel : INotifyPropertyChanged
    {
        /// <summary>
        /// set the property and notify changes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="backingStore">private field</param>
        /// <param name="value">new value</param>
        /// <param name="propertyName">property name</param>
        /// <param name="onChanged">Action to trigger</param>
        /// <returns>true if it was changed</returns>
        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
