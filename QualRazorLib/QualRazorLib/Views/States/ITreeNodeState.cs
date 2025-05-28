namespace QualRazorLib.Views.States
{
    public interface ITreeNodeState:IExpandState,ISelectedState, IHiddenState
    {
        int Level { get; }

    }
}
