﻿#pragma checksum "C:\Users\mrube\source\repos\SpotLightUWP\SpotLightUWP\Views\ImageGalleryDetailPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "95FC8A909A1D8AD8C1F0A4EDA473F1F6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SpotLightUWP.Views
{
    partial class ImageGalleryDetailPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.16.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_Image_Source(global::Windows.UI.Xaml.Controls.Image obj, global::Windows.UI.Xaml.Media.ImageSource value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::Windows.UI.Xaml.Media.ImageSource) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::Windows.UI.Xaml.Media.ImageSource), targetNullValue);
                }
                obj.Source = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_Primitives_ButtonBase_Command(global::Windows.UI.Xaml.Controls.Primitives.ButtonBase obj, global::System.Windows.Input.ICommand value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Windows.Input.ICommand) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Windows.Input.ICommand), targetNullValue);
                }
                obj.Command = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_MenuFlyoutItem_Command(global::Windows.UI.Xaml.Controls.MenuFlyoutItem obj, global::System.Windows.Input.ICommand value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Windows.Input.ICommand) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Windows.Input.ICommand), targetNullValue);
                }
                obj.Command = value;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.16.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class ImageGalleryDetailPage_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IImageGalleryDetailPage_Bindings
        {
            private global::SpotLightUWP.Views.ImageGalleryDetailPage dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.Image obj2;
            private global::Windows.UI.Xaml.Controls.Button obj4;
            private global::Windows.UI.Xaml.Controls.Button obj5;
            private global::Windows.UI.Xaml.Controls.Button obj7;
            private global::Windows.UI.Xaml.Controls.MenuFlyoutItem obj8;
            private global::Windows.UI.Xaml.Controls.MenuFlyoutItem obj9;

            private ImageGalleryDetailPage_obj1_BindingsTracking bindingsTracking;

            public ImageGalleryDetailPage_obj1_Bindings()
            {
                this.bindingsTracking = new ImageGalleryDetailPage_obj1_BindingsTracking(this);
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 2: // Views\ImageGalleryDetailPage.xaml line 17
                        this.obj2 = (global::Windows.UI.Xaml.Controls.Image)target;
                        break;
                    case 4: // Views\ImageGalleryDetailPage.xaml line 23
                        this.obj4 = (global::Windows.UI.Xaml.Controls.Button)target;
                        break;
                    case 5: // Views\ImageGalleryDetailPage.xaml line 27
                        this.obj5 = (global::Windows.UI.Xaml.Controls.Button)target;
                        break;
                    case 7: // Views\ImageGalleryDetailPage.xaml line 36
                        this.obj7 = (global::Windows.UI.Xaml.Controls.Button)target;
                        break;
                    case 8: // Views\ImageGalleryDetailPage.xaml line 44
                        this.obj8 = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)target;
                        break;
                    case 9: // Views\ImageGalleryDetailPage.xaml line 50
                        this.obj9 = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)target;
                        break;
                    default:
                        break;
                }
            }

            // IImageGalleryDetailPage_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.initialized = false;
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                this.bindingsTracking.ReleaseAllListeners();
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::SpotLightUWP.Views.ImageGalleryDetailPage)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::SpotLightUWP.Views.ImageGalleryDetailPage obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel(obj.ViewModel, phase);
                    }
                }
            }
            private void Update_ViewModel(global::SpotLightUWP.ViewModels.ImageGalleryDetailViewModel obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_ViewModel(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel_SelectedImage(obj.SelectedImage, phase);
                    }
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel_ToLeft(obj.ToLeft, phase);
                        this.Update_ViewModel_ToRight(obj.ToRight, phase);
                        this.Update_ViewModel_SaveImageAs(obj.SaveImageAs, phase);
                        this.Update_ViewModel_SetAsWallpaper(obj.SetAsWallpaper, phase);
                        this.Update_ViewModel_SetAsLockscreen(obj.SetAsLockscreen, phase);
                    }
                }
            }
            private void Update_ViewModel_SelectedImage(global::SpotLightUWP.Models.ImageDTO obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel_SelectedImage_URI(obj.URI, phase);
                    }
                }
            }
            private void Update_ViewModel_SelectedImage_URI(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Views\ImageGalleryDetailPage.xaml line 17
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Image_Source(this.obj2, (global::Windows.UI.Xaml.Media.ImageSource) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::Windows.UI.Xaml.Media.ImageSource), obj), null);
                }
            }
            private void Update_ViewModel_ToLeft(global::System.Windows.Input.ICommand obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\ImageGalleryDetailPage.xaml line 23
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_ButtonBase_Command(this.obj4, obj, null);
                }
            }
            private void Update_ViewModel_ToRight(global::System.Windows.Input.ICommand obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\ImageGalleryDetailPage.xaml line 27
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_ButtonBase_Command(this.obj5, obj, null);
                }
            }
            private void Update_ViewModel_SaveImageAs(global::System.Windows.Input.ICommand obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\ImageGalleryDetailPage.xaml line 36
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_ButtonBase_Command(this.obj7, obj, null);
                }
            }
            private void Update_ViewModel_SetAsWallpaper(global::System.Windows.Input.ICommand obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\ImageGalleryDetailPage.xaml line 44
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_MenuFlyoutItem_Command(this.obj8, obj, null);
                }
            }
            private void Update_ViewModel_SetAsLockscreen(global::System.Windows.Input.ICommand obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\ImageGalleryDetailPage.xaml line 50
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_MenuFlyoutItem_Command(this.obj9, obj, null);
                }
            }

            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.16.0")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private class ImageGalleryDetailPage_obj1_BindingsTracking
            {
                private global::System.WeakReference<ImageGalleryDetailPage_obj1_Bindings> weakRefToBindingObj; 

                public ImageGalleryDetailPage_obj1_BindingsTracking(ImageGalleryDetailPage_obj1_Bindings obj)
                {
                    weakRefToBindingObj = new global::System.WeakReference<ImageGalleryDetailPage_obj1_Bindings>(obj);
                }

                public ImageGalleryDetailPage_obj1_Bindings TryGetBindingObject()
                {
                    ImageGalleryDetailPage_obj1_Bindings bindingObject = null;
                    if (weakRefToBindingObj != null)
                    {
                        weakRefToBindingObj.TryGetTarget(out bindingObject);
                        if (bindingObject == null)
                        {
                            weakRefToBindingObj = null;
                            ReleaseAllListeners();
                        }
                    }
                    return bindingObject;
                }

                public void ReleaseAllListeners()
                {
                    UpdateChildListeners_ViewModel(null);
                }

                public void PropertyChanged_ViewModel(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    ImageGalleryDetailPage_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        string propName = e.PropertyName;
                        global::SpotLightUWP.ViewModels.ImageGalleryDetailViewModel obj = sender as global::SpotLightUWP.ViewModels.ImageGalleryDetailViewModel;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                            if (obj != null)
                            {
                                bindings.Update_ViewModel_SelectedImage(obj.SelectedImage, DATA_CHANGED);
                            }
                        }
                        else
                        {
                            switch (propName)
                            {
                                case "SelectedImage":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_SelectedImage(obj.SelectedImage, DATA_CHANGED);
                                    }
                                    break;
                                }
                                default:
                                    break;
                            }
                        }
                    }
                }
                private global::SpotLightUWP.ViewModels.ImageGalleryDetailViewModel cache_ViewModel = null;
                public void UpdateChildListeners_ViewModel(global::SpotLightUWP.ViewModels.ImageGalleryDetailViewModel obj)
                {
                    if (obj != cache_ViewModel)
                    {
                        if (cache_ViewModel != null)
                        {
                            ((global::System.ComponentModel.INotifyPropertyChanged)cache_ViewModel).PropertyChanged -= PropertyChanged_ViewModel;
                            cache_ViewModel = null;
                        }
                        if (obj != null)
                        {
                            cache_ViewModel = obj;
                            ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_ViewModel;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.16.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1: // Views\ImageGalleryDetailPage.xaml line 1
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)(target);
                    ((global::Windows.UI.Xaml.Controls.Page)element1).KeyDown += this.OnKeyDown;
                }
                break;
            case 2: // Views\ImageGalleryDetailPage.xaml line 17
                {
                    this.detailImage = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 3: // Views\ImageGalleryDetailPage.xaml line 21
                {
                    this.shapeGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 6: // Views\ImageGalleryDetailPage.xaml line 31
                {
                    this.previewImage = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.16.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1: // Views\ImageGalleryDetailPage.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    ImageGalleryDetailPage_obj1_Bindings bindings = new ImageGalleryDetailPage_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                }
                break;
            }
            return returnValue;
        }
    }
}
