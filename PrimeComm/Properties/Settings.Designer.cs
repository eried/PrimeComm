﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34003
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PrimeComm.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool IgnoreInternalName {
            get {
                return ((bool)(this["IgnoreInternalName"]));
            }
            set {
                this["IgnoreInternalName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool ObfuscateVariables {
            get {
                return ((bool)(this["ObfuscateVariables"]));
            }
            set {
                this["ObfuscateVariables"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool RemoveComments {
            get {
                return ((bool)(this["RemoveComments"]));
            }
            set {
                this["RemoveComments"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool CompressSpaces {
            get {
                return ((bool)(this["CompressSpaces"]));
            }
            set {
                this["CompressSpaces"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("export (?<name>.*?)\\(")]
        public string RegexProgramName {
            get {
                return ((string)(this["RegexProgramName"]));
            }
            set {
                this["RegexProgramName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool EnableAdditionalProgramProcessing {
            get {
                return ((bool)(this["EnableAdditionalProgramProcessing"]));
            }
            set {
                this["EnableAdditionalProgramProcessing"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool SkipConflictingProcessChecking {
            get {
                return ((bool)(this["SkipConflictingProcessChecking"]));
            }
            set {
                this["SkipConflictingProcessChecking"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool ImageMethodDimgrobOptimizeSimilar {
            get {
                return ((bool)(this["ImageMethodDimgrobOptimizeSimilar"]));
            }
            set {
                this["ImageMethodDimgrobOptimizeSimilar"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool ImageMethodDimgrobOptimizeBlacks {
            get {
                return ((bool)(this["ImageMethodDimgrobOptimizeBlacks"]));
            }
            set {
                this["ImageMethodDimgrobOptimizeBlacks"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("DimgrobPieces")]
        public global::PrimeLib.ImageProcessingMode ImageMethod {
            get {
                return ((global::PrimeLib.ImageProcessingMode)(this["ImageMethod"]));
            }
            set {
                this["ImageMethod"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\"[^\"\"\\\\]*(?:\\\\.[^\"\"\\\\]*)*\"")]
        public string RegexStrings {
            get {
                return ((string)(this["RegexStrings"]));
            }
            set {
                this["RegexStrings"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("//.*")]
        public string RegexComments {
            get {
                return ((string)(this["RegexComments"]));
            }
            set {
                this["RegexComments"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("(?:[A-Za-z0-9+/]{4})*(?:[A-Za-z0-9+/]{2}==|[A-Za-z0-9+/]{3}=)?")]
        public string RegexBase64 {
            get {
                return ((string)(this["RegexBase64"]));
            }
            set {
                this["RegexBase64"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("([\"\'+/*-\\^@!:;,.?%=)(}{\\][|\\s])")]
        public string RegexOperators {
            get {
                return ((string)(this["RegexOperators"]));
            }
            set {
                this["RegexOperators"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("local (?<vars>.*?);")]
        public string RegexLocalVariables {
            get {
                return ((string)(this["RegexLocalVariables"]));
            }
            set {
                this["RegexLocalVariables"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("aa0")]
        public string VariableRefactoringStartingSeed {
            get {
                return ((string)(this["VariableRefactoringStartingSeed"]));
            }
            set {
                this["VariableRefactoringStartingSeed"] = value;
            }
        }
    }
}
