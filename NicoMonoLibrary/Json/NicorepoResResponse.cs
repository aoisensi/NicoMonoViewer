using System;
using System.Runtime.Serialization;

namespace NicoMonoLibrary
{
	namespace Json
	{
		[DataContract]
		public class NicorepoResResponse
		{
			[DataMember(Name = "code")]
			public string Code {get;set;}

			[DataMember(Name = "status_code")]
			public string StatusCode {get;set;}

			[DataMember(Name = "res_time")]
			public string ResTime {get;set;}

			[DataMember(Name = "res_number")]
			public string ResNumber{get;set;}

			[DataMember(Name = "status")]
			public string Status {get;set;}
		}
	}
}

