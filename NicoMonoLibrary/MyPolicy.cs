using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;


namespace NicoMonoLibrary
{
	public class MyPolicy : ICertificatePolicy
	{
		public bool CheckValidationResult (ServicePoint sp, X509Certificate certificate, WebRequest request, int error)
		{
			if (error == 0) {
				return true;
			}
			if (error == -2146762486) {
				return false;
			}
			return true;
		}
	}
}

