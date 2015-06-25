using Sitecore.Web.UI.WebControls;
using System;
using System.Web.Mvc;
using System.Web.UI;

namespace Sitecore.Base.Helpers
{
    public static class EditorFrameHelper
    {
        public static EditFrame EditFrameControl;

        private class FrameEditor : IDisposable
        {
            private bool _disposed;
            private readonly HtmlHelper _html;

            public FrameEditor(HtmlHelper html, string dataSource = null, string buttons = null)
            {
                this._html = html;
                EditFrameControl = new EditFrame
                {
                    DataSource = dataSource ?? "/sitecore/content/home",
                    Buttons = buttons ?? "/sitecore/content/Applications/WebEdit/Edit Frame Buttons/Default"
                };
                var output = new HtmlTextWriter(html.ViewContext.Writer);
                EditFrameControl.RenderFirstPart(output);
            }

            public void Dispose()
            {
                if (_disposed) return;

                _disposed = true;

                EditFrameControl.RenderLastPart(new HtmlTextWriter(_html.ViewContext.Writer));
                EditFrameControl.Dispose();
            }
        }

        public static IDisposable EditFrame(this HtmlHelper html, string dataSource = null, string buttons = null)
        {
            return new FrameEditor(html, dataSource, buttons);
        }

    }
}