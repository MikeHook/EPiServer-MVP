using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Castle.MicroKernel;
using PageTypeBuilder;
using WebFormsMvp;

namespace EPiMVP.Castle
{
	public class CastlePresenterFactory : EPiPresenterFactory
	{
		private readonly IKernel presenterKernel;

		public CastlePresenterFactory(IKernel kernel)
		{
			if (kernel == null)
				throw new ArgumentNullException("kernel");
			this.presenterKernel = kernel;
		}

		protected override bool CanUseConstructor(ConstructorInfo constructor, Type viewType, Type pageDataType)
		{
			ParameterInfo[] parameters = constructor.GetParameters();
			if (parameters[0].ParameterType.IsAssignableFrom(viewType))
				return parameters[1].ParameterType.IsAssignableFrom(pageDataType);
			else
				return false;
		}

		protected override IPresenter CreatePageDataPresenterInstance(Type presenterType, TypedPageData pageData, Type viewType, IEPiView view)
		{
			if (presenterType == (Type) null)
				throw new ArgumentNullException("presenterType");
			if (viewType == (Type) null)
				throw new ArgumentNullException("viewType");
			if (view == null)
				throw new ArgumentNullException("view");
			Dictionary<string, object> dictionary = new Dictionary<string, object>()
			                                        	{
			                                        		{
			                                        			"view",
			                                        			(object) view
			                                        			},
			                                        		{
			                                        			"pageData",
			                                        			(object) pageData
			                                        			}
			                                        	};
			return (IPresenter) this.presenterKernel.Resolve(presenterType, (IDictionary) dictionary);
		}

		/// <summary>
		/// Create a presenter instance without the pageData parameter
		/// </summary>
		protected override IPresenter CreatePresenterInstance(Type presenterType, Type viewType, IEPiView view)
		{
			if (presenterType == (Type) null)
				throw new ArgumentNullException("presenterType");
			if (viewType == (Type) null)
				throw new ArgumentNullException("viewType");
			if (view == null)
				throw new ArgumentNullException("view");
			Dictionary<string, object> dictionary = new Dictionary<string, object>()
			                                        	{
			                                        		{
			                                        			"view",
			                                        			(object) view
			                                        			}
			                                        	};
			return (IPresenter) this.presenterKernel.Resolve(presenterType, (IDictionary) dictionary);
		}
	}
}
