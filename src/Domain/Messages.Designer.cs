﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Domain {
    using System;
    using System.Reflection;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Messages {
        
        private static System.Resources.ResourceManager resourceMan;
        
        private static System.Globalization.CultureInfo resourceCulture;
        
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Messages() {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager {
            get {
                if (object.Equals(null, resourceMan)) {
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager("Domain.Messages", typeof(Messages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        internal static string TheJuroShouldBePositive {
            get {
                return ResourceManager.GetString("TheJuroShouldBePositive", resourceCulture);
            }
        }
        
        internal static string TheJuroShouldBeLessOrEqualToOne {
            get {
                return ResourceManager.GetString("TheJuroShouldBeLessOrEqualToOne", resourceCulture);
            }
        }
        
        internal static string TheMesesShouldBePositive {
            get {
                return ResourceManager.GetString("TheMesesShouldBePositive", resourceCulture);
            }
        }
        
        internal static string TheValorInicialShouldBePositive {
            get {
                return ResourceManager.GetString("TheValorInicialShouldBePositive", resourceCulture);
            }
        }
        
        internal static string TheMesesMaxValue {
            get {
                return ResourceManager.GetString("TheMesesMaxValue", resourceCulture);
            }
        }
        
        internal static string TheValorInicialMaxValue {
            get {
                return ResourceManager.GetString("TheValorInicialMaxValue", resourceCulture);
            }
        }
    }
}