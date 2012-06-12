using PageTypeBuilder;
using WebFormsMvp;

namespace EPiMVP
{
	public abstract class EPiPageDataPresenter<TView, TPageDataType> : Presenter<TView> where TView : class, IView where TPageDataType : TypedPageData
	{
		public TPageDataType CurrentPage { get; private set; }

		protected EPiPageDataPresenter(TView view, TPageDataType pageData)
			: base(view)
		{
			CurrentPage = (TPageDataType)pageData;
		}

		public override void ReleaseView() { }
	}
}