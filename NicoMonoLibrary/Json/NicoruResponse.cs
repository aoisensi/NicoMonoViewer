using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace NicoMonoLibrary
{
	namespace Json
	{
		[DataContract]
		public class NicoruResponse{
			[DataMember(Name = "status")]
			public string Status{get;set;}

			[DataMember(Name = "statuscode")]
			public int StatusCode{get;set;}
			
			[DataMember(Name = "result")]
			public Json.Result Result{get;set;}

			[DataMember(Name = "error")]
			public Json.Error Error{get;set;}
		}

		[DataContract]
		public class Result{
			[DataMember(Name = "items")]
			public Json.Items[] Items{get;set;}
			
			[DataMember(Name = "errors")]
			public Json.Errors[] Errors{get;set;}
		}
		
		[DataContract]
		public class Items{
			[DataMember(Name = "itemId")]
			public string ItemId{get;set;}
			
			[DataMember(Name = "count")]
			public int Count{get;set;}
		}
		
		[DataContract]
		public class Error{
			[DataMember(Name = "code")]
			public string Code{get;set;}
			
			[DataMember(Name = "description")]
			public string Description{get;set;}
		}
		
		public class Errors{
			[DataMember(Name = "itemId")]
			public string ItemId{get;set;}
			
			[DataMember(Name = "code")]
			public string Code{get;set;}
		}
	}
}
