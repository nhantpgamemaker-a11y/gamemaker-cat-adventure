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
        private string _itemDefinitionId;
        public string Name { get => _name; }
        public List<ItemPropertyDefinitionRef> ItemPropertyDefinitionRefs { get => _itemPropertyDefinitionRefs; }
        public string ItemDefinitionId { get => _itemDefinitionId; }
        public ItemReceiverProduct(string id, string name,List<ItemPropertyDefinitionRef> itemStatDefinitionRefs,string itemDefinitionId) : base(id)
        {
            _name = name;
            _itemPropertyDefinitionRefs = itemStatDefinitionRefs;
            _itemDefinitionId = itemDefinitionId;
        }
    }
}