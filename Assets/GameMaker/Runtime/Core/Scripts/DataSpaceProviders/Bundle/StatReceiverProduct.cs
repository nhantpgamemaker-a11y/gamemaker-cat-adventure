using System.Collections.Generic;

namespace GameMaker.Core.Runtime
{
    public enum ConsumeType
    {
        Add= 0 ,
        Set = 1
    }
    public class ItemReceiverProduct : BaseReceiverProduct
    {
        private string _name;
        private List<ItemPropertyDefinitionRef> _itemPropertyDefinitionRefs = new();
        public string Name { get => _name; }
        public List<ItemPropertyDefinitionRef> ItemPropertyDefinitionRefs { get => _itemPropertyDefinitionRefs; }
        public ItemReceiverProduct(string id, string name, List<ItemPropertyDefinitionRef> itemStatDefinitionRefs, string itemDetailDefinitionID) : base(itemDetailDefinitionID)
        {
            _name = name;
            _itemPropertyDefinitionRefs = itemStatDefinitionRefs;
        }
        public ItemDetailDefinition GetItemDetailDefinition()
        {
            return ItemDetailManager.Instance.GetDefinition(ID);
        }
    }
}