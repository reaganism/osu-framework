// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Collections.Generic;
using osu.Framework.Extensions.ListExtensions;
using osu.Framework.Lists;

namespace osu.Framework.Platform
{
    public partial class GameHost
    {
        /// <summary>
        ///     The main window of this host.
        /// </summary>
        public IWindow MainWindow { get; private set; }

        [Obsolete("Use MainWindow", error: true)]
        public IWindow Window => MainWindow;

        private readonly List<IWindow> windows = [];

        /// <summary>
        ///     The windows managed by this host, including <see cref="MainWindow"/>.
        /// </summary>
        public SlimReadOnlyListWrapper<IWindow> Windows => windows.AsSlimReadOnly();

        /// <summary>
        ///     Creates a new window managed by this host.
        /// </summary>
        /// <returns>The window instance being created.</returns>
        public virtual IWindow CreateWindow()
        {
            var window = CreateWindow(rendererToGraphicsSurfaceType(ResolvedRenderer));
            windows.Add(window);
            return window;
        }
    }
}
