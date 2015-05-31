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

namespace Kirnau.Social.TwitterGrains
{
    using System;
    using Orleans.CodeGeneration;
    using Orleans;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Collections.Generic;
    using System.Collections;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    [SerializableAttribute()]
    [global::Orleans.CodeGeneration.GrainStateAttribute("Kirnau.Social.TwitterGrains.Kirnau.Social.TwitterGrains.CounterGrain")]
    public class CounterGrainState : global::Orleans.CodeGeneration.GrainState, ICounterState
    {
        

            public Int32 @Counter { get; set; }

            public override void SetAll(System.Collections.Generic.IDictionary<string,object> values)
            {   
                object value;
                if (values == null) { InitStateFields(); return; }
                if (values.TryGetValue("Counter", out value)) @Counter = value is Int64 ? (Int32)(Int64)value : (Int32)value;
            }

            public override System.String ToString()
            {
                return System.String.Format("CounterGrainState( Counter={0} )", @Counter);
            }
        
        public CounterGrainState() : 
                base("Kirnau.Social.TwitterGrains.CounterGrain")
        {
            this.InitStateFields();
        }
        
        public override System.Collections.Generic.IDictionary<string, object> AsDictionary()
        {
            System.Collections.Generic.Dictionary<string, object> result = new System.Collections.Generic.Dictionary<string, object>();
            result["Counter"] = this.Counter;
            return result;
        }
        
        private void InitStateFields()
        {
            this.Counter = default(Int32);
        }
        
        [global::Orleans.CodeGeneration.CopierMethodAttribute()]
        public static object _Copier(object original)
        {
            CounterGrainState input = ((CounterGrainState)(original));
            return input.DeepCopy();
        }
        
        [global::Orleans.CodeGeneration.SerializerMethodAttribute()]
        public static void _Serializer(object original, global::Orleans.Serialization.BinaryTokenStreamWriter stream, System.Type expected)
        {
            CounterGrainState input = ((CounterGrainState)(original));
            input.SerializeTo(stream);
        }
        
        [global::Orleans.CodeGeneration.DeserializerMethodAttribute()]
        public static object _Deserializer(System.Type expected, global::Orleans.Serialization.BinaryTokenStreamReader stream)
        {
            CounterGrainState result = new CounterGrainState();
            result.DeserializeFrom(stream);
            return result;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    [SerializableAttribute()]
    [global::Orleans.CodeGeneration.GrainStateAttribute("Kirnau.Social.TwitterGrains.Kirnau.Social.TwitterGrains.HashtagGrain")]
    public class HashtagGrainState : global::Orleans.CodeGeneration.GrainState, ITotalsState
    {
        

            public Int32 @Positive { get; set; }

            public Int32 @Negative { get; set; }

            public Int32 @Total { get; set; }

            public DateTime @LastUpdated { get; set; }

            public String @Hashtag { get; set; }

            public Boolean @BeenCounted { get; set; }

            public String @LastTweet { get; set; }

            public override void SetAll(System.Collections.Generic.IDictionary<string,object> values)
            {   
                object value;
                if (values == null) { InitStateFields(); return; }
                if (values.TryGetValue("Positive", out value)) @Positive = value is Int64 ? (Int32)(Int64)value : (Int32)value;
                if (values.TryGetValue("Negative", out value)) @Negative = value is Int64 ? (Int32)(Int64)value : (Int32)value;
                if (values.TryGetValue("Total", out value)) @Total = value is Int64 ? (Int32)(Int64)value : (Int32)value;
                if (values.TryGetValue("LastUpdated", out value)) @LastUpdated = (DateTime) value;
                if (values.TryGetValue("Hashtag", out value)) @Hashtag = (String) value;
                if (values.TryGetValue("BeenCounted", out value)) @BeenCounted = (Boolean) value;
                if (values.TryGetValue("LastTweet", out value)) @LastTweet = (String) value;
            }

            public override System.String ToString()
            {
                return System.String.Format("HashtagGrainState( Positive={0} Negative={1} Total={2} LastUpdated={3} Hashtag={4} BeenCounted={5} LastTweet={6} )", @Positive, @Negative, @Total, @LastUpdated, @Hashtag, @BeenCounted, @LastTweet);
            }
        
        public HashtagGrainState() : 
                base("Kirnau.Social.TwitterGrains.HashtagGrain")
        {
            this.InitStateFields();
        }
        
        public override System.Collections.Generic.IDictionary<string, object> AsDictionary()
        {
            System.Collections.Generic.Dictionary<string, object> result = new System.Collections.Generic.Dictionary<string, object>();
            result["Positive"] = this.Positive;
            result["Negative"] = this.Negative;
            result["Total"] = this.Total;
            result["LastUpdated"] = this.LastUpdated;
            result["Hashtag"] = this.Hashtag;
            result["BeenCounted"] = this.BeenCounted;
            result["LastTweet"] = this.LastTweet;
            return result;
        }
        
        private void InitStateFields()
        {
            this.Positive = default(Int32);
            this.Negative = default(Int32);
            this.Total = default(Int32);
            this.LastUpdated = default(DateTime);
            this.Hashtag = default(String);
            this.BeenCounted = default(Boolean);
            this.LastTweet = default(String);
        }
        
        [global::Orleans.CodeGeneration.CopierMethodAttribute()]
        public static object _Copier(object original)
        {
            HashtagGrainState input = ((HashtagGrainState)(original));
            return input.DeepCopy();
        }
        
        [global::Orleans.CodeGeneration.SerializerMethodAttribute()]
        public static void _Serializer(object original, global::Orleans.Serialization.BinaryTokenStreamWriter stream, System.Type expected)
        {
            HashtagGrainState input = ((HashtagGrainState)(original));
            input.SerializeTo(stream);
        }
        
        [global::Orleans.CodeGeneration.DeserializerMethodAttribute()]
        public static object _Deserializer(System.Type expected, global::Orleans.Serialization.BinaryTokenStreamReader stream)
        {
            HashtagGrainState result = new HashtagGrainState();
            result.DeserializeFrom(stream);
            return result;
        }
    }
}
#pragma warning restore 162
#pragma warning restore 219
#pragma warning restore 693
#pragma warning restore 1591
#pragma warning restore 1998
#endif
