using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Threading;

namespace BinaryStudio.Modeling.Petal.Controls.Internal
    {
    public abstract class NotifyPropertyChangedDispatcherObject : INotifyPropertyChanged
        {
        [Browsable(false)] public Dispatcher Dispatcher { get; }
        [Browsable(false)] public Boolean InvokeRequired { get { return Dispatcher.Thread.ManagedThreadId != Thread.CurrentThread.ManagedThreadId; }}
        #region P:IsLoaded:Boolean
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Boolean IsLoadedProperty;
        [Browsable(false)]
        public Boolean IsLoaded
            {
            get { return IsLoadedProperty; }
            private set { SetValue(ref IsLoadedProperty,value,nameof(IsLoaded)); }
            }
        #endregion
        #region P:IsSelected:Boolean
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Boolean IsSelectedProperty;
        [Browsable(false)]
        public Boolean IsSelected
            {
            get { return IsSelectedProperty; }
            set { SetValue(ref IsSelectedProperty,value,nameof(IsSelected)); }
            }
        #endregion
        #region P:IsExpanded:Boolean
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Boolean IsExpandedProperty;
        [Browsable(false)]
        public Boolean IsExpanded
            {
            get { return IsExpandedProperty; }
            set { SetValue(ref IsExpandedProperty,value,nameof(IsExpanded)); }
            }
        #endregion

        protected NotifyPropertyChangedDispatcherObject()
            :this(Dispatcher.CurrentDispatcher)
            {
            }

        protected NotifyPropertyChangedDispatcherObject(Dispatcher dispatcher)
            {
            if (dispatcher == null) { throw new ArgumentNullException(nameof(dispatcher)); }
            Dispatcher = dispatcher;
            }

        #region M:OnPropertyChanged(String)
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>Raises the <see cref="INotifyPropertyChanged.PropertyChanged"/> event when the specified property has been changed.</summary>
        /// <param name="PropertyName">The property that has been changed.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] String PropertyName = null) {
            var handler = PropertyChanged;
            if (handler != null) {
                var e = new PropertyChangedEventArgs(PropertyName);
                if (InvokeRequired) {
                    Dispatcher.Invoke(DispatcherPriority.Normal, new Action(()=>{
                        handler.Invoke(this, e);
                        }));
                    }
                else
                    {
                    handler.Invoke(this, e);
                    }
                }
            }
        #endregion
        #region M:SetValue<T>(ref T,T,String):Boolean
        protected Boolean SetValue<T>(ref T field, T value, [CallerMemberName] String PropertyName = null) {
            var r = true;
            if (value is IEquatable<T> equatable) {
                r = equatable.Equals(field);
                }
            else if (typeof(T).IsSubclassOf(typeof(Enum)))
                {
                r = Equals(value, field);
                }
            else
                {
                r = Equals(value, field);
                }
            if (!r)
                {
                field = value;
                OnPropertyChanged(PropertyName);
                }
            return !r;
            }
        #endregion
        }

    public abstract class NotifyPropertyChangedDispatcherObject<T> : NotifyPropertyChangedDispatcherObject
        {
        #region P:Source:T
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private T SourceProperty;
        [Browsable(false)]
        public T Source
            {
            get { return SourceProperty; }
            protected set { SetValue(ref SourceProperty, value, nameof(Source)); }
            }
        #endregion

        #region ctor
        protected NotifyPropertyChangedDispatcherObject()
            {
            Source = default;
            }
        #endregion
        #region ctor{T}
        protected NotifyPropertyChangedDispatcherObject(T source)
            {
            Source = source;
            }
        #endregion
        }
    }