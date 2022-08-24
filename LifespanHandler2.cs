using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaTM_acbas
{
    public class LifespanHandler2 : ILifeSpanHandler
    {
        //event that receive url popup
        public event Action popup_request;
        static public IBrowser popupBrowser = null;

        bool ILifeSpanHandler.OnBeforePopup(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {
            newBrowser = null; // out 변수는 참조를 위한 변수이기 때문에 반드시 값을 할당해야 한다.
            return false; // true이면 팝업이 뜨지 않게 된다.
        }

        bool ILifeSpanHandler.DoClose(IWebBrowser browserControl, IBrowser browser)
        { return false; }

        void ILifeSpanHandler.OnBeforeClose(IWebBrowser browserControl, IBrowser browser) { }
        void ILifeSpanHandler.OnAfterCreated(IWebBrowser browserControl, IBrowser browser)
        {
            if (browser.IsPopup) // 새로 생성된 크로미움 브라우저가 팝업 상태라면
                browser.CloseBrowser(true); // 바로 종료한다. 여기서 목적에 맞게 새로 코딩하자.
        }
    }
}
