using System;

namespace IntroductionToNet.Shared.Library
{
    public static class MessageGenerator
    {
        public static string GetGreeting(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                name = "user";

            return $"{DateTime.Now.ToLongTimeString()} Hello, {name}!";
        }
    }
}
