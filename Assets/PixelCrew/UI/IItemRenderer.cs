namespace Assets.PixelCrew.UI
{
    public interface IItemRenderer<in TDataType>
    {
        void SetData(TDataType data, int index);
    }
}
