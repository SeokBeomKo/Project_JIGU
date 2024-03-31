public abstract class FSMFactory<T, U, C> where T : BaseFSM<U>
{
    public abstract T CreateFSM(C controller);
}
