

using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AccordianView.CustomControl
{
    public static class ViewExtensions
    {
        public static Task<bool> ColorTo(this VisualElement self, Action<bool> callback, uint length = 250, Easing easing = null)
        {
           
            //Func<double, bool> transform = (t) =>
                self.IsVisible = !self.IsVisible;
            
            //return ColorAnimation(self, "FadeTo", transform, callback, length, easing);
            self.Opacity = 0;
            return self.FadeTo(1, 1000);
        }

        public static void CancelAnimation(this VisualElement self)
        {
            self.AbortAnimation("ColorTo");
        }

        static Task<bool> ColorAnimation(VisualElement element, string name, Func<double, bool> transform, Action<bool> callback, uint length, Easing easing)
        {
            easing = easing ?? Easing.SinIn;
            var taskCompletionSource = new TaskCompletionSource<bool>();
            element.Animate(name, transform, callback, 16, length, easing, (v, c) => taskCompletionSource.SetResult(c));
            //element.Animate<bool>(name, transform, callback, 16, length, easing, (v, c) => taskCompletionSource.SetResult(c));
            return taskCompletionSource.Task;
        }

    }
}
