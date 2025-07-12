using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.PixelCrew.UI.Widgets
{
    public class PredefinedDataGroup<TDataType, TItemType>
        : DataGroup<TDataType, TItemType>
        where TItemType : MonoBehaviour, IItemRenderer<TDataType>
    {
        public PredefinedDataGroup(Transform container)
            : base(null, container)
        {
            _createdItems
                .AddRange(container
                    .GetComponentsInChildren<TItemType>());
        }

        public override void SetData(IList<TDataType> data)
        {
            if (data.Count > _createdItems.Count)
            {
                throw new InvalidOperationException("Can't add more items, don't have enough space in container");
            }

            base.SetData(data);
        }
    }
}
