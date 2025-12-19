using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace GameMaker.Core.Editor
{
    public abstract class BaseDefinitionHolder :BaseHolder
    {
        protected Button copyButton;
        protected Image iconPreviewImage;
        protected ObjectField iconField;
        protected TextField idTextField;
        protected TextField nameTextField;
        protected TextField titleTextField;
        protected TextField descriptionTextField;
        protected SerializedProperty serializedProperty;


        protected BaseDefinitionHolder(VisualElement root):base(root)
        {
            copyButton = root.Q<Button>("CopyIDButton");
            iconPreviewImage = root.Q<Image>("IconPreviewImage");
            iconField = root.Q<ObjectField>("IconField");
            idTextField = root.Q<TextField>("IDTextField");
            nameTextField = root.Q<TextField>("NameTextField");
            titleTextField = root.Q<TextField>("TitleTextField");
            descriptionTextField = root.Q<TextField>("DescriptionTextField");
        }

        public override void Bind(SerializedProperty elementProperty)
        {
            serializedProperty = elementProperty;
            idTextField.BindProperty(serializedProperty.FindPropertyRelative("id"));
            nameTextField.BindProperty(serializedProperty.FindPropertyRelative("name"));
            titleTextField.BindProperty(serializedProperty.FindPropertyRelative("title"));
            iconField.BindProperty(serializedProperty.FindPropertyRelative("icon"));
            descriptionTextField.BindProperty(serializedProperty.FindPropertyRelative("description"));
            copyButton.clicked += OnClickCopy;

            iconPreviewImage.sprite = serializedProperty.FindPropertyRelative("icon")?.objectReferenceValue as Sprite;
            iconField.RegisterValueChangedCallback(value =>
            {
                iconPreviewImage.sprite = value.newValue as Sprite;
            });
            iconPreviewImage.sprite = serializedProperty.FindPropertyRelative("icon")?.objectReferenceValue as Sprite;

            Root.MarkDirtyRepaint();
        }

        private void OnClickCopy()
        {
            EditorGUIUtility.systemCopyBuffer =
            serializedProperty.FindPropertyRelative("id")?.stringValue;
        }
    }
}