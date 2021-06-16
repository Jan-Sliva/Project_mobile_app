using System;
using System.Collections.Generic;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Widget;
using CustomRenderer;
using CustomRenderer.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using Frontend.ViewModels;
using Xamarin.Forms.Platform.Android;
using Android.OS;
using Android.Content.Res;
using Android.Graphics;
using Color = Android.Graphics.Color;
using Frontend.Droid;
using Android.Runtime;

[assembly: ExportRenderer(typeof(Entry), typeof(CustomEntryRenderer))]
namespace Frontend.Droid
{
    [Obsolete]
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control == null || e.NewElement == null) return;

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                Control.BackgroundTintList = ColorStateList.ValueOf(Color.ParseColor("#3F51B5"));
            else
                Control.Background.SetColorFilter(Color.ParseColor("#3F51B5"), PorterDuff.Mode.SrcAtop);

            IntPtr IntPtrtextViewClass = JNIEnv.FindClass(typeof(TextView));
            IntPtr mCursorDrawableResProperty = JNIEnv.GetFieldID(IntPtrtextViewClass, "mCursorDrawableRes", "I");

            // my_cursor is the xml file name which we defined above
            JNIEnv.SetField(Control.Handle, mCursorDrawableResProperty, Resource.Drawable.CustomCursorColour);
        }
    }
}