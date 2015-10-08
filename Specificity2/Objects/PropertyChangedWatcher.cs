// <copyright file="PropertyChangedWatcher.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>

namespace Testing.Specificity2.Objects
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// Defines a test helper that watches an object that implements <see cref="INotifyPropertyChanged"/> for
    /// <see cref="INotifyPropertyChanged.PropertyChanged"/> events.
    /// </summary>
    internal sealed class PropertyChangedWatcher : EventWatcher<PropertyChangedEventArgs>, IDisposable
    {
        /// <summary>
        /// The source.
        /// </summary>
        private readonly INotifyPropertyChanged source;

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyChangedWatcher"/> class.
        /// </summary>
        /// <param name="source">The source object to watch.</param>
        public PropertyChangedWatcher(INotifyPropertyChanged source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            this.source = source;
            this.source.PropertyChanged += this.EventHandler;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.source.PropertyChanged -= this.EventHandler;
        }
    }
}