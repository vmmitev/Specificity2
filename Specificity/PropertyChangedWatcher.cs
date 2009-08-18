//-----------------------------------------------------------------------------
// <copyright file="PropertyChangedWatcher.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Defines a test helper that watches an object that implements <see cref="INotifyPropertyChanged"/> for
    /// <see cref="INotifyPropertyChanged.PropertyChanged"/> events.
    /// </summary>
    [SuppressMessage("Microsoft.Naming",
        "CA1710:IdentifiersShouldHaveCorrectSuffix",
        Justification = "The name is correct.")]
    public class PropertyChangedWatcher : EventWatcher<PropertyChangedEventArgs>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyChangedWatcher"/> class.
        /// </summary>
        /// <param name="source">The source object to watch.</param>
        public PropertyChangedWatcher(INotifyPropertyChanged source)
        {
            source.PropertyChanged += this.EventHandler;
        }
    }
}
