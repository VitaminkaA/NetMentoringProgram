using PerformanceCounterHelper;

namespace MvcMusicStore.Infrastructure
{
    [PerformanceCounterCategory("MVCMusicStore",
        System.Diagnostics.PerformanceCounterCategoryType.SingleInstance,
        "MVCMusicStore")]
    public enum Counters
    {
        [PerformanceCounter("Go To Login",
            "Go To Login",
            System.Diagnostics.PerformanceCounterType.NumberOfItems32)]
        GoToLogin,

        [PerformanceCounter("Successful Login",
            "Successful Login",
            System.Diagnostics.PerformanceCounterType.NumberOfItems32)]
        SuccessfulLogin,

        [PerformanceCounter("Failed Login",
            "Failed Login",
            System.Diagnostics.PerformanceCounterType.NumberOfItems32)]
        FailedLogin,

        [PerformanceCounter("Login Off",
            "Log Off",
            System.Diagnostics.PerformanceCounterType.NumberOfItems32)]
        LoginOff
    }
}