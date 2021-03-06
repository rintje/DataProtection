﻿using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace DataProtectionExtensions.Test
{
	public static class TestCertificate
	{
		private static readonly string _certificateBytes = "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";

		/// <summary>
		/// Gets an embedded test certificate to check encryption/decryption functions.
		/// </summary>
		/// <returns>
		/// An <see cref="X509Certificate2"/> that can be used for encryption/decryption.
		/// </returns>
		public static X509Certificate2 GetCertificate()
		{
			// Certificate originally generated with
			// makecert -sv privatekey.pvk -n "CN=Key Protection" keyprotection.cer -sky Exchange
			// pvk2pfx /pvk privatekey.pvk /spc keyprotection.cer /pfx keyprotection.pfx
			// The above bytes are the keyprotection.pfx certificate.
			var bytes = Convert.FromBase64String(_certificateBytes);
			return new X509Certificate2(bytes);
		}
	}
}
