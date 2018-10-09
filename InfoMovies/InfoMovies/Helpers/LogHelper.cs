using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace InfoMovies.Helpers
{
    public static class LogHelper
    {
        #region Constants

        private const string LOG_EVENT_HEAD = "========== [Event track] ==========";
        private const string LOG_EXCEPTION_HEAD = "========== [Exception track] ==========";
        private const string LOG_DETAILS = "========== [Properties] ==========";

        #endregion

        #region  Public Methods

        /// <summary>
        /// Track event to analytics and print on output window,
        /// if debugger attached
        /// </summary>
        /// <param name="eventName">Name of event</param>
        /// <param name="properties">Optional properties</param>
        public static void TrackEvent(string eventName, IDictionary<string, string> properties = null)
        {
            Analytics.TrackEvent(eventName, properties);

            if (Debugger.IsAttached)
                WriteOutputEvent(eventName, properties);
        }

        /// <summary>
        /// Track a error to analytics and print on output window,
        /// if debugger attached
        /// </summary>
        /// <param name="exception">Exception catched</param>
        /// <param name="properties">Optional properties</param>
        public static void LogException(Exception exception, IDictionary<string, string> properties = null)
        {
            Crashes.TrackError(exception, properties);

            if (Debugger.IsAttached)
                WriteOutputException(exception, properties);
        }


        #endregion

        #region Private Methods

        private static void WriteOutputEvent(string eventName, IDictionary<string, string> properties)
        {
            var formatedProperties = FormatProperties(properties);
            var message = string.Join(Environment.NewLine, LOG_EVENT_HEAD, $"Event Name: {eventName}",
                LOG_DETAILS, formatedProperties);

            Debug.WriteLine(message, nameof(InfoMovies));
        }

        private static void WriteOutputException(Exception exception, IDictionary<string, string> properties)
        {
            var formatedProperties = FormatProperties(properties);
            var message = string.Join(Environment.NewLine, LOG_EXCEPTION_HEAD,
                $"Exception:{exception?.GetType()?.Name}", $"Message: {exception?.Message}",
                $"Stack Trace: {exception?.StackTrace}", formatedProperties);

            Debug.WriteLine(message, nameof(InfoMovies));
        }

        private static string FormatProperties(IDictionary<string, string> properties) =>
            properties?.Count > 0
            ? string.Join(Environment.NewLine, properties
                .Select(s => string.Concat($"{s.Key}: ", $"{s.Value},")))
            : "[No properties]";

        #endregion
    }
}