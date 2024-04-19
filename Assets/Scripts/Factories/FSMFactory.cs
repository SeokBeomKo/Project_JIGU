public abstract class FSMFactory<TFSM, TState, TController> where TFSM : BaseFSM<TState>
{
    public abstract TFSM CreateFSM(TController controller);
}