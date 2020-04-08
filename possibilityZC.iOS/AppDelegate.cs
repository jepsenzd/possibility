using Syncfusion.XForms.iOS.ComboBox;
using Syncfusion.XForms.iOS.Core;
using Syncfusion.XForms.iOS.Graphics;
using Syncfusion.SfRotator.XForms.iOS;
using Syncfusion.XForms.iOS.BadgeView;
using Syncfusion.XForms.iOS.Border;
using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

using Syncfusion.SfAutoComplete.XForms.iOS;

using Syncfusion.SfBusyIndicator.XForms.iOS;

using Syncfusion.SfNavigationDrawer.XForms.iOS;

using Syncfusion.SfRating.XForms.iOS;

using Syncfusion.SfMaps.XForms.iOS;

using Syncfusion.SfPullToRefresh.XForms.iOS;

using Syncfusion.ListView.XForms.iOS;

using Syncfusion.XForms.iOS.TabView;

using Syncfusion.XForms.iOS.TextInputLayout;

using Syncfusion.XForms.iOS.Buttons;

using Syncfusion.XForms.iOS.Cards;

using Syncfusion.XForms.iOS.Accordion;

namespace possibilityZC.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            Core.Init();
            SfGradientViewRenderer.Init();
            SfSegmentedControlRenderer.Init();
            SfComboBoxRenderer.Init();
            SfBorderRenderer.Init();
            SfRotatorRenderer.Init();
            SfBadgeViewRenderer.Init();
            
			SfAutoCompleteRenderer.Init();
			
			
			SfBusyIndicatorRenderer.Init();
			
			
			SfNavigationDrawerRenderer.Init();
			
			
			SfRatingRenderer.Init();
			
			
			SfMapsRenderer.Init();
			
			
			SfPullToRefreshRenderer.Init();
			
			
			SfListViewRenderer.Init();
			
			
			SfTabViewRenderer.Init();
			
			
			SfTextInputLayoutRenderer.Init();
			
			
			SfButtonRenderer.Init();
			
			
			SfCardViewRenderer.Init();
			
			
			SfCardLayoutRenderer.Init();
			
			
			SfAccordionRenderer.Init();
			
			
			SfSwitchRenderer.Init();
			
			LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
