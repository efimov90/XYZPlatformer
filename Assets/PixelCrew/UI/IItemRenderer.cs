namespace Assets.CommonComponents.UI
{
    public interface IItemRenderer<in TDataType>
    {
        void SetData(TDataType data, int index);
    }
}
