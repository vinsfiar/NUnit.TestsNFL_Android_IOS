using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.TestsNFL_Android_IOS.IOS_Pages
{
    public static class SignInOutPage
    {
        public static string EmailUsernameField { get; set; } = "//*[@class='UIATextField']";
        public static string PasswordField { get; set; } = "//*[@class='UIAView' and ./*[@text='showPasswordIcon']]";
        public static string LogIn { get; set; } = "//*[@text='LOGIN']";
        public static string LogOut { get; set; } = "//*[@text='LOGOUT']";

        public static string YourProfile { get; set; } = "//*[@text='Your profile' and @class='UIAStaticText']";
        public static string User { get; set; } = "//*[@text='Username']";
        public static string Email { get; set; } = "//*[@text='Email']";
        public static string Password { get; set; } = "//*[@text='Password']";

        public static string YourSub { get; set; } = "//*[@text='Your subscription' and @class='UIAStaticText']";
        public static string Sub { get; set; } = "//*[@text='Subscription']";
        public static string Bill { get; set; } = "//*[@text='Billed date']";
        public static string Access { get; set; } = "//*[@text='Access until']";

    }
}
