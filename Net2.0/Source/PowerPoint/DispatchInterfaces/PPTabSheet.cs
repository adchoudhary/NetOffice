//Generated by LateBindingApi.CodeGenerator
using System;
using NetRuntimeSystem = System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Reflection;
using LateBindingApi.Core;
namespace LateBindingApi.PowerPointApi
{
	///<summary>
	/// DispatchInterface PPTabSheet SupportByLibrary PP09 
	///</summary>
	[SupportByLibrary("PP09")]
	public class PPTabSheet : COMObject
	{
		#pragma warning disable
		#region Construction

        /// <param name="parentObject">object there has created the proxy</param>
        /// <param name="comProxy">inner wrapped COM proxy</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
		public PPTabSheet(COMObject parentObject, object comProxy) : base(parentObject, comProxy)
		{
		}
		
		/// <param name="parentObject">object there has created the proxy</param>
        /// <param name="comProxy">inner wrapped COM proxy</param>
        /// <param name="comProxyType">Type of inner wrapped COM proxy"</param>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
		public PPTabSheet(COMObject parentObject, object comProxy, NetRuntimeSystem.Type comProxyType) : base(parentObject, comProxy, comProxyType)
		{
		}
		
		/// <param name="replacedObject">object to replaced. replacedObject are not usable after this action</param>
		[EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
		public PPTabSheet(COMObject replacedObject) : base(replacedObject)
		{
		}
		
		[EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
		public PPTabSheet()
		{
		}
		
		#endregion
		
		#region Properties

		/// <summary>
		/// SupportByLibrary PP09 
		/// </summary>
		[SupportByLibrary("PP09")]
		public LateBindingApi.PowerPointApi.Application Application
		{
			get
			{
				object[] paramsArray = null;
				object returnItem = Invoker.PropertyGet(this, "Application", paramsArray);
				LateBindingApi.PowerPointApi.Application newObject = LateBindingApi.Core.Factory.CreateObjectFromComProxy(this,returnItem) as LateBindingApi.PowerPointApi.Application;
				return newObject;
			}
		}

		/// <summary>
		/// SupportByLibrary PP09 
		/// </summary>
		[SupportByLibrary("PP09")]
		public COMObject Parent
		{
			get
			{
				object[] paramsArray = null;
				object returnItem = Invoker.PropertyGet(this, "Parent", paramsArray);
				COMObject newObject = LateBindingApi.Core.Factory.CreateObjectFromComProxy(this,returnItem);
				return newObject;
			}
		}

		/// <summary>
		/// SupportByLibrary PP09 
		/// </summary>
		[SupportByLibrary("PP09")]
		public string Name
		{
			get
			{
				object[] paramsArray = null;
				object returnItem = Invoker.PropertyGet(this, "Name", paramsArray);
				return (string)returnItem;
			}
			set
			{
				object[] paramsArray = Invoker.ValidateParamsArray(value);
				Invoker.PropertySet(this, "Name", paramsArray);
			}
		}

		/// <summary>
		/// SupportByLibrary PP09 
		/// </summary>
		[SupportByLibrary("PP09")]
		public Single ClientLeft
		{
			get
			{
				object[] paramsArray = null;
				object returnItem = Invoker.PropertyGet(this, "ClientLeft", paramsArray);
				return (Single)returnItem;
			}
		}

		/// <summary>
		/// SupportByLibrary PP09 
		/// </summary>
		[SupportByLibrary("PP09")]
		public Single ClientTop
		{
			get
			{
				object[] paramsArray = null;
				object returnItem = Invoker.PropertyGet(this, "ClientTop", paramsArray);
				return (Single)returnItem;
			}
		}

		/// <summary>
		/// SupportByLibrary PP09 
		/// </summary>
		[SupportByLibrary("PP09")]
		public Single ClientWidth
		{
			get
			{
				object[] paramsArray = null;
				object returnItem = Invoker.PropertyGet(this, "ClientWidth", paramsArray);
				return (Single)returnItem;
			}
		}

		/// <summary>
		/// SupportByLibrary PP09 
		/// </summary>
		[SupportByLibrary("PP09")]
		public Single ClientHeight
		{
			get
			{
				object[] paramsArray = null;
				object returnItem = Invoker.PropertyGet(this, "ClientHeight", paramsArray);
				return (Single)returnItem;
			}
		}

		/// <summary>
		/// SupportByLibrary PP09 
		/// </summary>
		[SupportByLibrary("PP09")]
		public LateBindingApi.PowerPointApi.PPControls Controls
		{
			get
			{
				object[] paramsArray = null;
				object returnItem = Invoker.PropertyGet(this, "Controls", paramsArray);
				LateBindingApi.PowerPointApi.PPControls newObject = LateBindingApi.Core.Factory.CreateObjectFromComProxy(this,returnItem) as LateBindingApi.PowerPointApi.PPControls;
				return newObject;
			}
		}

		/// <summary>
		/// SupportByLibrary PP09 
		/// </summary>
		[SupportByLibrary("PP09")]
		public LateBindingApi.PowerPointApi.Tags Tags
		{
			get
			{
				object[] paramsArray = null;
				object returnItem = Invoker.PropertyGet(this, "Tags", paramsArray);
				LateBindingApi.PowerPointApi.Tags newObject = LateBindingApi.Core.Factory.CreateObjectFromComProxy(this,returnItem) as LateBindingApi.PowerPointApi.Tags;
				return newObject;
			}
		}

		/// <summary>
		/// SupportByLibrary PP09 
		/// </summary>
		[SupportByLibrary("PP09")]
		public string OnActivate
		{
			get
			{
				object[] paramsArray = null;
				object returnItem = Invoker.PropertyGet(this, "OnActivate", paramsArray);
				return (string)returnItem;
			}
			set
			{
				object[] paramsArray = Invoker.ValidateParamsArray(value);
				Invoker.PropertySet(this, "OnActivate", paramsArray);
			}
		}

		#endregion

		#region Methods

		/// <summary>
		/// SupportByLibrary PP09 
		/// </summary>
		[SupportByLibrary("PP09")]
		public void Select()
		{
			object[] paramsArray = null;
			Invoker.Method(this, "Select", paramsArray);
		}

		#endregion
		#pragma warning restore
	}
}