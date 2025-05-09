using System;

namespace BatteryNotifier.Forms {

	public partial class  Dashboard
   {
		private class BatteryNotification {
			public BatteryNotification(BatteryNotificationSettingsDto settings, bool canNotify) {
				this.Settings = settings ?? throw new ArgumentNullException(nameof(settings));
				this.CanNotify = canNotify;
			}

			public BatteryNotificationSettingsDto Settings { get; set; }
			public bool CanNotify { get; set; } = true;
			public string Title { get => this.Settings.Title; set => this.Settings.Title = value; }
			public string GetMessage() => this.Settings.BuildMessage();
		}
	}
}
