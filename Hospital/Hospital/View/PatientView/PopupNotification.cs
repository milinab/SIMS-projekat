using System;
using Tulpep.NotificationWindow;

namespace Hospital.View.PatientView
{
    internal class PopupNotification
    {

        public static void SendPopupNotification(String titleText, String contentText) {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.notification;
            popup.TitleText = titleText;
            popup.ContentText = contentText;
            popup.Popup();

        }

    }
}
