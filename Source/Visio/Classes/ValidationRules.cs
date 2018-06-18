﻿using System;
using NetRuntimeSystem = System;
using System.ComponentModel;
using NetOffice.Attributes;

namespace NetOffice.VisioApi
{
	/// <summary>
	/// CoClass ValidationRules 
	/// SupportByVersion Visio, 14,15,16
	/// </summary>
	/// <remarks> MSDN Online: http://msdn.microsoft.com/en-us/en-us/library/ff769439(v=office.14).aspx </remarks>
	[SupportByVersion("Visio", 14,15,16)]
	[EntityType(EntityType.IsCoClass)]
	[TypeId("000D0A3A-0000-0000-C000-000000000046")]
 	public interface ValidationRules : IVValidationRules
	{

	}
}
