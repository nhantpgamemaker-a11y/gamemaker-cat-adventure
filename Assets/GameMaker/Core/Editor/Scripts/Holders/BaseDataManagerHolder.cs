using System;
using System.Collections.Generic;
using System.Linq;
using GameMaker.Core.Runtime;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace GameMaker.Core.Editor
{
    public abstract class BaseDataManagerHolder<M> : BaseHolder where M :IDefinition
    {
        protected SerializedProperty serializedProperty;
        protected SerializedProperty definitionProperty;
        private System.Collections.IList _items;
        private Button _addButton;
        private Button _removeButton;
        protected ListView itemListView;

        void OnUndoRedo()
        {
            serializedProperty.serializedObject.Update();
            MakeItemSource(GetItemSource());
            itemListView.Rebuild();
            itemListView.RefreshItems();
        }
        public BaseDataManagerHolder(VisualElement root) : base(root)
        {
            _items = new List<object>();
        }
        public override void Bind(SerializedProperty elementProperty)
        {
            base.Bind(elementProperty);
            serializedProperty = elementProperty;
            definitionProperty = elementProperty.FindPropertyRelative("definitions");
            Root.RegisterCallback<AttachToPanelEvent>(_ =>
            {
                Undo.undoRedoPerformed += OnUndoRedo;
            });

            Root.RegisterCallback<DetachFromPanelEvent>(_ =>
            {
                Undo.undoRedoPerformed -= OnUndoRedo;
            });
            itemListView = Root.Q<ListView>("ItemListView");
            itemListView.selectionType = SelectionType.Multiple;
            itemListView.itemsSource = _items;
            MakeItemSource(GetItemSource());
            itemListView.makeItem = MakeItem;
            itemListView.bindItem = BindItem;
            itemListView.itemIndexChanged += ItemIndexChanged;
            itemListView.Rebuild();
            itemListView.RefreshItems();
            _addButton = Root.Q<Button>("AddButton");
            _removeButton = Root.Q<Button>("RemoveButton");
            _addButton.clicked += OnAddButtonClicked;
            _removeButton.clicked += OnRemoveButtonClicked;
        }
        protected void MakeItemSource(System.Collections.IList itemSource)
        {
            _items.Clear();
            foreach(var item in itemSource)
            {
                _items.Add(item);
            }
        }
        protected virtual System.Collections.IList GetItemSource()
        {
            var items = new List<object>();
            for (var i = 0; i < definitionProperty.arraySize; i++)
                items.Add(definitionProperty.GetArrayElementAtIndex(i).objectReferenceValue);
            return items;
        }
        protected virtual void ItemIndexChanged(int oldIndex, int newIndex)
        {
            definitionProperty.MoveArrayElement(oldIndex, newIndex);
            definitionProperty.serializedObject.ApplyModifiedProperties();
        }
        protected abstract BaseDefinitionHolder CreateHolder();
        protected virtual string GetTitle() => "Title";
        protected virtual VisualElement MakeItem()
        {
            var holder = CreateHolder();
            var root = holder.Root;
            root.userData = holder;
            return root;
        }
        protected virtual void BindItem(VisualElement element, int index)
        {
            var holder = (BaseDefinitionHolder)element.userData;
            var itemProperty = definitionProperty.GetArrayElementAtIndex(index);
            holder.Bind(itemProperty);
        }
        protected virtual void OnRemoveButtonClicked()
        {
            var selectedIndices = itemListView.selectedIndices;
            if (selectedIndices.Count() == 0) return;
            ConfirmWindowEditor.ShowWindow("Delete Items",
            "Are you sure you want to delete there item?",
            () =>
            {
                var ids = selectedIndices.Select(x => _items[x]).ToList();
                foreach (var id in ids)
                {
                    _items.Remove(id);
                }
                itemListView.RefreshItems();

                var indices = selectedIndices
                .OrderByDescending(i => i)
                .ToList();
                foreach (var index in indices)
                {
                    definitionProperty.DeleteArrayElementAtIndex(index);
                }
                serializedProperty.serializedObject.ApplyModifiedProperties();
            },
            () =>
            {

            });
        }
        protected virtual void OnAddButtonClicked()
        {
            var inheritanceClassTypes = new List<Type>();
            var definitionType = typeof(M);
            if (definitionType.IsAbstract)
                inheritanceClassTypes = TypeUtils.GetAllDerivedNonAbstractTypes(typeof(M)).ToList();
            else
            {
                inheritanceClassTypes.Add(typeof(M));
            }
            List<ActionData> actionDatas = new();
            EditorWindow window = null;
            foreach(var type in inheritanceClassTypes)
            {
                var actionData = new ActionData(type.Name, () =>
                {
                    var item = (M)Activator.CreateInstance(type);
                    int newIndex = definitionProperty.arraySize;
                    definitionProperty.InsertArrayElementAtIndex(newIndex);
                    var newElement = definitionProperty.GetArrayElementAtIndex(newIndex);
                    newElement.managedReferenceValue = item;
                    _items.Add(item.GetName());
                    definitionProperty.serializedObject.ApplyModifiedProperties();
                    definitionProperty.serializedObject.Update();
                    itemListView.RefreshItems();
                });
                actionDatas.Add(actionData);
            }
            window = ButtonActionWindowEditor.ShowWindow(GetTitle(),actionDatas);
        }
    }
}
