using System;
using Xamarin.Forms;

namespace AccordianView.CustomControl
{
    public class AccordionCell : ViewCell
    {
        public static readonly BindableProperty HeaderProperty = BindableProperty.Create(nameof(Header), typeof(View),
            typeof(AccordionCell), propertyChanged: AccordionCell_SetHeaderText);

        public static readonly BindableProperty DetailProperty = BindableProperty.Create(nameof(Detail), typeof(View),
            typeof(AccordionCell), propertyChanged: AccordionCell_SetDetail);

        private static void AccordionCell_SetDetail(BindableObject bindable, object oldValue, object newValue)
        {
            var accordionCell = bindable as AccordionCell;
            if (newValue == null || accordionCell == null)
            {
                return;
            }
            accordionCell.detailView.Content = newValue as View;
        }

        private static void AccordionCell_SetHeaderText(BindableObject bindable, object oldValue, object newValue)
        {
            var accordionCell = bindable as AccordionCell;
            if (newValue == null || accordionCell == null)
            {
                return;
            }

            accordionCell.headerView.Content = newValue as View;
        }

        public View Header
        {
            get { return (View)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        public View Detail
        {
            get { return (View)GetValue(DetailProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        private ContentView headerView;
        private ContentView detailView;

        public AccordionCell()
        {

            //Init
            headerView = new ContentView();
            detailView = new ContentView { IsVisible = true };

            //TapGesture for hiding and showing
            var tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped +=   (sender, e) =>
            {
                
                Action<double> callback = input => detailView.Content.HeightRequest = input;
                double startingHeight = detailView.Content.Height;
                double endingHeight = -1;
                uint rate = 16;
                uint length = 3000;
                Easing easing = Easing.CubicOut;
                detailView.Animate("accordion", callback, startingHeight, endingHeight, rate, length, easing);

                this.ForceUpdateSize();
            };
            headerView.GestureRecognizers.Add(tapGesture);

            //Setting Cell View
            View = new StackLayout
            {
                Children =
                {
                    headerView,
                    detailView
                }
            };
        }
       

    }
}