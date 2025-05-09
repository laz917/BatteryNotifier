using System;

namespace BatteryNotifier.Forms {
	public class BatteryNotificationSettingsDto {
		public string Title { get; set; }
		public string MessageTemplate { get; set; }
		float threshold;
		public float ThresholdReal { get => threshold; set => threshold = value; }
		public bool PlaySound { get; set; }
		public bool ShowNotification { get; set; }
		public string Music { get; set; }
		public TimeSpan Duration { get; set; }

		public bool MaxOncePerThreshold { get; set; }

		public BatteryNotificationSettingsDto(string title, string messageTemplate, float threshold, string? music, bool showNotification, TimeSpan duration, bool maxOncePerThreshold) {
			this.Title = title;
			this.MessageTemplate = messageTemplate ?? throw new ArgumentNullException(nameof(messageTemplate));
			this.threshold = threshold;
			this.Music = music;
			this.PlaySound = !string.IsNullOrEmpty(music);
			this.ShowNotification = showNotification;
			this.Duration = duration;
			this.MaxOncePerThreshold = maxOncePerThreshold;

			if (!IsValidTemplate(this.MessageTemplate)) throw new ArgumentException(null, nameof(messageTemplate));
		}

		public string BuildMessage() => String.Format(MessageTemplate, ThresholdReal.ToString("0%"));
		public static bool IsValidTemplate(string messageTemplate) => true;
	}
}
