//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#if !EXCLUDE_CODEGEN
#pragma warning disable 162
#pragma warning disable 219
#pragma warning disable 693
#pragma warning disable 1591
#pragma warning disable 1998

namespace TwitterGrainInterfaces
{
    using System;
    using System.Net;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.IO;
    using System.Collections.Generic;
    using System.Reflection;
    using Orleans.Serialization;
    using TwitterGrainInterfaces;
    using Orleans;
    using Orleans.Runtime;
    using System.Collections;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public class CounterFactory
    {
        

                        public static TwitterGrainInterfaces.ICounter GetGrain(long primaryKey)
                        {
                            return Cast(global::Orleans.CodeGeneration.GrainFactoryBase.MakeGrainReferenceInternal(typeof(TwitterGrainInterfaces.ICounter), -1196808756, primaryKey));
                        }

                        public static TwitterGrainInterfaces.ICounter GetGrain(long primaryKey, string grainClassNamePrefix)
                        {
                            return Cast(global::Orleans.CodeGeneration.GrainFactoryBase.MakeGrainReferenceInternal(typeof(TwitterGrainInterfaces.ICounter), -1196808756, primaryKey, grainClassNamePrefix));
                        }

                        public static TwitterGrainInterfaces.ICounter GetGrain(System.Guid primaryKey)
                        {
                            return Cast(global::Orleans.CodeGeneration.GrainFactoryBase.MakeGrainReferenceInternal(typeof(TwitterGrainInterfaces.ICounter), -1196808756, primaryKey));
                        }

                        public static TwitterGrainInterfaces.ICounter GetGrain(System.Guid primaryKey, string grainClassNamePrefix)
                        {
                            return Cast(global::Orleans.CodeGeneration.GrainFactoryBase.MakeGrainReferenceInternal(typeof(TwitterGrainInterfaces.ICounter), -1196808756, primaryKey, grainClassNamePrefix));
                        }

            public static TwitterGrainInterfaces.ICounter Cast(global::Orleans.Runtime.IAddressable grainRef)
            {
                
                return CounterReference.Cast(grainRef);
            }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.0.0.0")]
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
        [System.SerializableAttribute()]
        [global::Orleans.CodeGeneration.GrainReferenceAttribute("TwitterGrainInterfaces.TwitterGrainInterfaces.ICounter")]
        internal class CounterReference : global::Orleans.Runtime.GrainReference, global::Orleans.Runtime.IAddressable, TwitterGrainInterfaces.ICounter
        {
            

            public static TwitterGrainInterfaces.ICounter Cast(global::Orleans.Runtime.IAddressable grainRef)
            {
                
                return (TwitterGrainInterfaces.ICounter) global::Orleans.Runtime.GrainReference.CastInternal(typeof(TwitterGrainInterfaces.ICounter), (global::Orleans.Runtime.GrainReference gr) => { return new CounterReference(gr);}, grainRef, -1196808756);
            }
            
            protected internal CounterReference(global::Orleans.Runtime.GrainReference reference) : 
                    base(reference)
            {
            }
            
            protected internal CounterReference(SerializationInfo info, StreamingContext context) : 
                    base(info, context)
            {
            }
            
            protected override int InterfaceId
            {
                get
                {
                    return -1196808756;
                }
            }
            
            public override string InterfaceName
            {
                get
                {
                    return "TwitterGrainInterfaces.TwitterGrainInterfaces.ICounter";
                }
            }
            
            [global::Orleans.CodeGeneration.CopierMethodAttribute()]
            public static object _Copier(object original)
            {
                CounterReference input = ((CounterReference)(original));
                return ((CounterReference)(global::Orleans.Runtime.GrainReference.CopyGrainReference(input)));
            }
            
            [global::Orleans.CodeGeneration.SerializerMethodAttribute()]
            public static void _Serializer(object original, global::Orleans.Serialization.BinaryTokenStreamWriter stream, System.Type expected)
            {
                CounterReference input = ((CounterReference)(original));
                global::Orleans.Runtime.GrainReference.SerializeGrainReference(input, stream, expected);
            }
            
            [global::Orleans.CodeGeneration.DeserializerMethodAttribute()]
            public static object _Deserializer(System.Type expected, global::Orleans.Serialization.BinaryTokenStreamReader stream)
            {
                return CounterReference.Cast(((global::Orleans.Runtime.GrainReference)(global::Orleans.Runtime.GrainReference.DeserializeGrainReference(expected, stream))));
            }
            
            public override bool IsCompatible(int interfaceId)
            {
                return (interfaceId == this.InterfaceId);
            }
            
            protected override string GetMethodName(int interfaceId, int methodId)
            {
                return CounterMethodInvoker.GetMethodName(interfaceId, methodId);
            }
            
            System.Threading.Tasks.Task TwitterGrainInterfaces.ICounter.IncrementCounter()
            {

                return base.InvokeMethodAsync<object>(732981053, new object[] {} );
            }
            
            System.Threading.Tasks.Task TwitterGrainInterfaces.ICounter.ResetCounter()
            {

                return base.InvokeMethodAsync<object>(1574597839, new object[] {} );
            }
            
            System.Threading.Tasks.Task<int> TwitterGrainInterfaces.ICounter.GetTotalCounter()
            {

                return base.InvokeMethodAsync<System.Int32>(-1311190982, new object[] {} );
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    [global::Orleans.CodeGeneration.MethodInvokerAttribute("TwitterGrainInterfaces.TwitterGrainInterfaces.ICounter", -1196808756)]
    internal class CounterMethodInvoker : global::Orleans.CodeGeneration.IGrainMethodInvoker
    {
        
        int global::Orleans.CodeGeneration.IGrainMethodInvoker.InterfaceId
        {
            get
            {
                return -1196808756;
            }
        }
        
        global::System.Threading.Tasks.Task<object> global::Orleans.CodeGeneration.IGrainMethodInvoker.Invoke(global::Orleans.Runtime.IAddressable grain, int interfaceId, int methodId, object[] arguments)
        {

            try
            {                    if (grain == null) throw new System.ArgumentNullException("grain");
                switch (interfaceId)
                {
                    case -1196808756:  // ICounter
                        switch (methodId)
                        {
                            case 732981053: 
                                return ((ICounter)grain).IncrementCounter().ContinueWith(t => {if (t.Status == System.Threading.Tasks.TaskStatus.Faulted) throw t.Exception; return (object)null; });
                            case 1574597839: 
                                return ((ICounter)grain).ResetCounter().ContinueWith(t => {if (t.Status == System.Threading.Tasks.TaskStatus.Faulted) throw t.Exception; return (object)null; });
                            case -1311190982: 
                                return ((ICounter)grain).GetTotalCounter().ContinueWith(t => {if (t.Status == System.Threading.Tasks.TaskStatus.Faulted) throw t.Exception; return (object)t.Result; });
                            default: 
                            throw new NotImplementedException("interfaceId="+interfaceId+",methodId="+methodId);
                        }
                    default:
                        throw new System.InvalidCastException("interfaceId="+interfaceId);
                }
            }
            catch(Exception ex)
            {
                var t = new System.Threading.Tasks.TaskCompletionSource<object>();
                t.SetException(ex);
                return t.Task;
            }
        }
        
        public static string GetMethodName(int interfaceId, int methodId)
        {

            switch (interfaceId)
            {
                
                case -1196808756:  // ICounter
                    switch (methodId)
                    {
                        case 732981053:
                            return "IncrementCounter";
                    case 1574597839:
                            return "ResetCounter";
                    case -1311190982:
                            return "GetTotalCounter";
                    
                        default: 
                            throw new NotImplementedException("interfaceId="+interfaceId+",methodId="+methodId);
                    }

                default:
                    throw new System.InvalidCastException("interfaceId="+interfaceId);
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public class TweetDispatcherGrainFactory
    {
        

                        public static TwitterGrainInterfaces.ITweetDispatcherGrain GetGrain(long primaryKey)
                        {
                            return Cast(global::Orleans.CodeGeneration.GrainFactoryBase.MakeGrainReferenceInternal(typeof(TwitterGrainInterfaces.ITweetDispatcherGrain), -52569496, primaryKey));
                        }

                        public static TwitterGrainInterfaces.ITweetDispatcherGrain GetGrain(long primaryKey, string grainClassNamePrefix)
                        {
                            return Cast(global::Orleans.CodeGeneration.GrainFactoryBase.MakeGrainReferenceInternal(typeof(TwitterGrainInterfaces.ITweetDispatcherGrain), -52569496, primaryKey, grainClassNamePrefix));
                        }

                        public static TwitterGrainInterfaces.ITweetDispatcherGrain GetGrain(System.Guid primaryKey)
                        {
                            return Cast(global::Orleans.CodeGeneration.GrainFactoryBase.MakeGrainReferenceInternal(typeof(TwitterGrainInterfaces.ITweetDispatcherGrain), -52569496, primaryKey));
                        }

                        public static TwitterGrainInterfaces.ITweetDispatcherGrain GetGrain(System.Guid primaryKey, string grainClassNamePrefix)
                        {
                            return Cast(global::Orleans.CodeGeneration.GrainFactoryBase.MakeGrainReferenceInternal(typeof(TwitterGrainInterfaces.ITweetDispatcherGrain), -52569496, primaryKey, grainClassNamePrefix));
                        }

            public static TwitterGrainInterfaces.ITweetDispatcherGrain Cast(global::Orleans.Runtime.IAddressable grainRef)
            {
                
                return TweetDispatcherGrainReference.Cast(grainRef);
            }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.0.0.0")]
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
        [System.SerializableAttribute()]
        [global::Orleans.CodeGeneration.GrainReferenceAttribute("TwitterGrainInterfaces.TwitterGrainInterfaces.ITweetDispatcherGrain")]
        internal class TweetDispatcherGrainReference : global::Orleans.Runtime.GrainReference, global::Orleans.Runtime.IAddressable, TwitterGrainInterfaces.ITweetDispatcherGrain
        {
            

            public static TwitterGrainInterfaces.ITweetDispatcherGrain Cast(global::Orleans.Runtime.IAddressable grainRef)
            {
                
                return (TwitterGrainInterfaces.ITweetDispatcherGrain) global::Orleans.Runtime.GrainReference.CastInternal(typeof(TwitterGrainInterfaces.ITweetDispatcherGrain), (global::Orleans.Runtime.GrainReference gr) => { return new TweetDispatcherGrainReference(gr);}, grainRef, -52569496);
            }
            
            protected internal TweetDispatcherGrainReference(global::Orleans.Runtime.GrainReference reference) : 
                    base(reference)
            {
            }
            
            protected internal TweetDispatcherGrainReference(SerializationInfo info, StreamingContext context) : 
                    base(info, context)
            {
            }
            
            protected override int InterfaceId
            {
                get
                {
                    return -52569496;
                }
            }
            
            public override string InterfaceName
            {
                get
                {
                    return "TwitterGrainInterfaces.TwitterGrainInterfaces.ITweetDispatcherGrain";
                }
            }
            
            [global::Orleans.CodeGeneration.CopierMethodAttribute()]
            public static object _Copier(object original)
            {
                TweetDispatcherGrainReference input = ((TweetDispatcherGrainReference)(original));
                return ((TweetDispatcherGrainReference)(global::Orleans.Runtime.GrainReference.CopyGrainReference(input)));
            }
            
            [global::Orleans.CodeGeneration.SerializerMethodAttribute()]
            public static void _Serializer(object original, global::Orleans.Serialization.BinaryTokenStreamWriter stream, System.Type expected)
            {
                TweetDispatcherGrainReference input = ((TweetDispatcherGrainReference)(original));
                global::Orleans.Runtime.GrainReference.SerializeGrainReference(input, stream, expected);
            }
            
            [global::Orleans.CodeGeneration.DeserializerMethodAttribute()]
            public static object _Deserializer(System.Type expected, global::Orleans.Serialization.BinaryTokenStreamReader stream)
            {
                return TweetDispatcherGrainReference.Cast(((global::Orleans.Runtime.GrainReference)(global::Orleans.Runtime.GrainReference.DeserializeGrainReference(expected, stream))));
            }
            
            public override bool IsCompatible(int interfaceId)
            {
                return (interfaceId == this.InterfaceId);
            }
            
            protected override string GetMethodName(int interfaceId, int methodId)
            {
                return TweetDispatcherGrainMethodInvoker.GetMethodName(interfaceId, methodId);
            }
            
            System.Threading.Tasks.Task TwitterGrainInterfaces.ITweetDispatcherGrain.AddScore(int @score, string[] @hashtags, string @tweet)
            {

                return base.InvokeMethodAsync<object>(-997505293, new object[] {@score, @hashtags, @tweet} );
            }
            
            System.Threading.Tasks.Task<TwitterGrainInterfaces.Totals[]> TwitterGrainInterfaces.ITweetDispatcherGrain.GetTotals(string[] @hashtags)
            {

                return base.InvokeMethodAsync<TwitterGrainInterfaces.Totals[]>(1690947172, new object[] {@hashtags} );
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    [global::Orleans.CodeGeneration.MethodInvokerAttribute("TwitterGrainInterfaces.TwitterGrainInterfaces.ITweetDispatcherGrain", -52569496)]
    internal class TweetDispatcherGrainMethodInvoker : global::Orleans.CodeGeneration.IGrainMethodInvoker
    {
        
        int global::Orleans.CodeGeneration.IGrainMethodInvoker.InterfaceId
        {
            get
            {
                return -52569496;
            }
        }
        
        global::System.Threading.Tasks.Task<object> global::Orleans.CodeGeneration.IGrainMethodInvoker.Invoke(global::Orleans.Runtime.IAddressable grain, int interfaceId, int methodId, object[] arguments)
        {

            try
            {                    if (grain == null) throw new System.ArgumentNullException("grain");
                switch (interfaceId)
                {
                    case -52569496:  // ITweetDispatcherGrain
                        switch (methodId)
                        {
                            case -997505293: 
                                return ((ITweetDispatcherGrain)grain).AddScore((Int32)arguments[0], (String[])arguments[1], (String)arguments[2]).ContinueWith(t => {if (t.Status == System.Threading.Tasks.TaskStatus.Faulted) throw t.Exception; return (object)null; });
                            case 1690947172: 
                                return ((ITweetDispatcherGrain)grain).GetTotals((String[])arguments[0]).ContinueWith(t => {if (t.Status == System.Threading.Tasks.TaskStatus.Faulted) throw t.Exception; return (object)t.Result; });
                            default: 
                            throw new NotImplementedException("interfaceId="+interfaceId+",methodId="+methodId);
                        }
                    default:
                        throw new System.InvalidCastException("interfaceId="+interfaceId);
                }
            }
            catch(Exception ex)
            {
                var t = new System.Threading.Tasks.TaskCompletionSource<object>();
                t.SetException(ex);
                return t.Task;
            }
        }
        
        public static string GetMethodName(int interfaceId, int methodId)
        {

            switch (interfaceId)
            {
                
                case -52569496:  // ITweetDispatcherGrain
                    switch (methodId)
                    {
                        case -997505293:
                            return "AddScore";
                    case 1690947172:
                            return "GetTotals";
                    
                        default: 
                            throw new NotImplementedException("interfaceId="+interfaceId+",methodId="+methodId);
                    }

                default:
                    throw new System.InvalidCastException("interfaceId="+interfaceId);
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public class HashtagGrainFactory
    {
        

                        public static TwitterGrainInterfaces.IHashtagGrain GetGrain(long primaryKey, string keyExt)
                        {
                            return Cast(global::Orleans.CodeGeneration.GrainFactoryBase.MakeKeyExtendedGrainReferenceInternal(typeof(TwitterGrainInterfaces.IHashtagGrain), 1848443735, primaryKey, keyExt));
                        }

                        public static TwitterGrainInterfaces.IHashtagGrain GetGrain(long primaryKey, string keyExt, string grainClassNamePrefix)
                        {
                            return Cast(global::Orleans.CodeGeneration.GrainFactoryBase.MakeKeyExtendedGrainReferenceInternal(typeof(TwitterGrainInterfaces.IHashtagGrain), 1848443735, primaryKey, keyExt, grainClassNamePrefix));
                        }

                        public static TwitterGrainInterfaces.IHashtagGrain GetGrain(System.Guid primaryKey, string keyExt)
                        {
                            return Cast(global::Orleans.CodeGeneration.GrainFactoryBase.MakeKeyExtendedGrainReferenceInternal(typeof(TwitterGrainInterfaces.IHashtagGrain), 1848443735, primaryKey, keyExt));
                        }

                        public static TwitterGrainInterfaces.IHashtagGrain GetGrain(System.Guid primaryKey, string keyExt, string grainClassNamePrefix)
                        {
                            return Cast(global::Orleans.CodeGeneration.GrainFactoryBase.MakeKeyExtendedGrainReferenceInternal(typeof(TwitterGrainInterfaces.IHashtagGrain), 1848443735, primaryKey, keyExt,grainClassNamePrefix));
                        }

            public static TwitterGrainInterfaces.IHashtagGrain Cast(global::Orleans.Runtime.IAddressable grainRef)
            {
                
                return HashtagGrainReference.Cast(grainRef);
            }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.0.0.0")]
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
        [System.SerializableAttribute()]
        [global::Orleans.CodeGeneration.GrainReferenceAttribute("TwitterGrainInterfaces.TwitterGrainInterfaces.IHashtagGrain")]
        internal class HashtagGrainReference : global::Orleans.Runtime.GrainReference, global::Orleans.Runtime.IAddressable, TwitterGrainInterfaces.IHashtagGrain
        {
            

            public static TwitterGrainInterfaces.IHashtagGrain Cast(global::Orleans.Runtime.IAddressable grainRef)
            {
                
                return (TwitterGrainInterfaces.IHashtagGrain) global::Orleans.Runtime.GrainReference.CastInternal(typeof(TwitterGrainInterfaces.IHashtagGrain), (global::Orleans.Runtime.GrainReference gr) => { return new HashtagGrainReference(gr);}, grainRef, 1848443735);
            }
            
            protected internal HashtagGrainReference(global::Orleans.Runtime.GrainReference reference) : 
                    base(reference)
            {
            }
            
            protected internal HashtagGrainReference(SerializationInfo info, StreamingContext context) : 
                    base(info, context)
            {
            }
            
            protected override int InterfaceId
            {
                get
                {
                    return 1848443735;
                }
            }
            
            public override string InterfaceName
            {
                get
                {
                    return "TwitterGrainInterfaces.TwitterGrainInterfaces.IHashtagGrain";
                }
            }
            
            [global::Orleans.CodeGeneration.CopierMethodAttribute()]
            public static object _Copier(object original)
            {
                HashtagGrainReference input = ((HashtagGrainReference)(original));
                return ((HashtagGrainReference)(global::Orleans.Runtime.GrainReference.CopyGrainReference(input)));
            }
            
            [global::Orleans.CodeGeneration.SerializerMethodAttribute()]
            public static void _Serializer(object original, global::Orleans.Serialization.BinaryTokenStreamWriter stream, System.Type expected)
            {
                HashtagGrainReference input = ((HashtagGrainReference)(original));
                global::Orleans.Runtime.GrainReference.SerializeGrainReference(input, stream, expected);
            }
            
            [global::Orleans.CodeGeneration.DeserializerMethodAttribute()]
            public static object _Deserializer(System.Type expected, global::Orleans.Serialization.BinaryTokenStreamReader stream)
            {
                return HashtagGrainReference.Cast(((global::Orleans.Runtime.GrainReference)(global::Orleans.Runtime.GrainReference.DeserializeGrainReference(expected, stream))));
            }
            
            public override bool IsCompatible(int interfaceId)
            {
                return (interfaceId == this.InterfaceId);
            }
            
            protected override string GetMethodName(int interfaceId, int methodId)
            {
                return HashtagGrainMethodInvoker.GetMethodName(interfaceId, methodId);
            }
            
            System.Threading.Tasks.Task TwitterGrainInterfaces.IHashtagGrain.AddScore(int @score, string @lastTweet)
            {

                return base.InvokeMethodAsync<object>(-1303993644, new object[] {@score, @lastTweet} );
            }
            
            System.Threading.Tasks.Task<TwitterGrainInterfaces.Totals> TwitterGrainInterfaces.IHashtagGrain.GetTotals()
            {

                return base.InvokeMethodAsync<TwitterGrainInterfaces.Totals>(-2004439872, new object[] {} );
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    [global::Orleans.CodeGeneration.MethodInvokerAttribute("TwitterGrainInterfaces.TwitterGrainInterfaces.IHashtagGrain", 1848443735)]
    internal class HashtagGrainMethodInvoker : global::Orleans.CodeGeneration.IGrainMethodInvoker
    {
        
        int global::Orleans.CodeGeneration.IGrainMethodInvoker.InterfaceId
        {
            get
            {
                return 1848443735;
            }
        }
        
        global::System.Threading.Tasks.Task<object> global::Orleans.CodeGeneration.IGrainMethodInvoker.Invoke(global::Orleans.Runtime.IAddressable grain, int interfaceId, int methodId, object[] arguments)
        {

            try
            {                    if (grain == null) throw new System.ArgumentNullException("grain");
                switch (interfaceId)
                {
                    case 1848443735:  // IHashtagGrain
                        switch (methodId)
                        {
                            case -1303993644: 
                                return ((IHashtagGrain)grain).AddScore((Int32)arguments[0], (String)arguments[1]).ContinueWith(t => {if (t.Status == System.Threading.Tasks.TaskStatus.Faulted) throw t.Exception; return (object)null; });
                            case -2004439872: 
                                return ((IHashtagGrain)grain).GetTotals().ContinueWith(t => {if (t.Status == System.Threading.Tasks.TaskStatus.Faulted) throw t.Exception; return (object)t.Result; });
                            default: 
                            throw new NotImplementedException("interfaceId="+interfaceId+",methodId="+methodId);
                        }
                    default:
                        throw new System.InvalidCastException("interfaceId="+interfaceId);
                }
            }
            catch(Exception ex)
            {
                var t = new System.Threading.Tasks.TaskCompletionSource<object>();
                t.SetException(ex);
                return t.Task;
            }
        }
        
        public static string GetMethodName(int interfaceId, int methodId)
        {

            switch (interfaceId)
            {
                
                case 1848443735:  // IHashtagGrain
                    switch (methodId)
                    {
                        case -1303993644:
                            return "AddScore";
                    case -2004439872:
                            return "GetTotals";
                    
                        default: 
                            throw new NotImplementedException("interfaceId="+interfaceId+",methodId="+methodId);
                    }

                default:
                    throw new System.InvalidCastException("interfaceId="+interfaceId);
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    [global::Orleans.CodeGeneration.RegisterSerializerAttribute()]
    internal class TwitterGrainInterfaces_TotalsSerialization
    {
        
        static TwitterGrainInterfaces_TotalsSerialization()
        {
            Register();
        }
        
        public static object DeepCopier(object original)
        {
            TwitterGrainInterfaces.Totals input = ((TwitterGrainInterfaces.Totals)(original));
            TwitterGrainInterfaces.Totals result = new TwitterGrainInterfaces.Totals();
            Orleans.Serialization.SerializationContext.Current.RecordObject(original, result);
            result.Hashtag = input.Hashtag;
            result.LastTweet = input.LastTweet;
            result.LastUpdated = input.LastUpdated;
            result.Negative = input.Negative;
            result.Positive = input.Positive;
            result.Total = input.Total;
            return result;
        }
        
        public static void Serializer(object untypedInput, Orleans.Serialization.BinaryTokenStreamWriter stream, System.Type expected)
        {
            TwitterGrainInterfaces.Totals input = ((TwitterGrainInterfaces.Totals)(untypedInput));
            Orleans.Serialization.SerializationManager.SerializeInner(input.Hashtag, stream, typeof(string));
            Orleans.Serialization.SerializationManager.SerializeInner(input.LastTweet, stream, typeof(string));
            Orleans.Serialization.SerializationManager.SerializeInner(input.LastUpdated, stream, typeof(System.DateTime));
            Orleans.Serialization.SerializationManager.SerializeInner(input.Negative, stream, typeof(int));
            Orleans.Serialization.SerializationManager.SerializeInner(input.Positive, stream, typeof(int));
            Orleans.Serialization.SerializationManager.SerializeInner(input.Total, stream, typeof(int));
        }
        
        public static object Deserializer(System.Type expected, global::Orleans.Serialization.BinaryTokenStreamReader stream)
        {
            TwitterGrainInterfaces.Totals result = new TwitterGrainInterfaces.Totals();
            result.Hashtag = ((string)(Orleans.Serialization.SerializationManager.DeserializeInner(typeof(string), stream)));
            result.LastTweet = ((string)(Orleans.Serialization.SerializationManager.DeserializeInner(typeof(string), stream)));
            result.LastUpdated = ((System.DateTime)(Orleans.Serialization.SerializationManager.DeserializeInner(typeof(System.DateTime), stream)));
            result.Negative = ((int)(Orleans.Serialization.SerializationManager.DeserializeInner(typeof(int), stream)));
            result.Positive = ((int)(Orleans.Serialization.SerializationManager.DeserializeInner(typeof(int), stream)));
            result.Total = ((int)(Orleans.Serialization.SerializationManager.DeserializeInner(typeof(int), stream)));
            return result;
        }
        
        public static void Register()
        {
            global::Orleans.Serialization.SerializationManager.Register(typeof(TwitterGrainInterfaces.Totals), DeepCopier, Serializer, Deserializer);
        }
    }
}
#pragma warning restore 162
#pragma warning restore 219
#pragma warning restore 693
#pragma warning restore 1591
#pragma warning restore 1998
#endif