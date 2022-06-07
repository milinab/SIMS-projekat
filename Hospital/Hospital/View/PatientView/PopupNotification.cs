using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tulpep.NotificationWindow;

namespace Hospital.View.PatientView
{
    internal class PopupNotification
    {

        public static void sendPopupNotification(String titleText, String contentText) {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.notification;
            popup.TitleText = titleText;
            popup.ContentText = contentText;
            popup.Popup();

        }

    }
}
