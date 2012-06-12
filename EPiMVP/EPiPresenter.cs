using WebFormsMvp;

namespace EPiMVP
{
	/// <summary>
    /// This is a Presenter without a page type. 
    /// </summary>
    public abstract class EPiPresenter<TView> : Presenter<TView> where TView : class, IView
    {
        protected EPiPresenter(TView view) : base(view) { }

        public override void ReleaseView() { }
    }
}