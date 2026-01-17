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
        protected Foldout definitionFoldout;
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
            definitionFoldout = root.Q<Foldout>("DefinitionFoldout");
            idTextField.isReadOnly = false;
        }

        public override void Bind(SerializedProperty elementProperty)
        {
            serializedProperty = elementProperty;
            idTextField.BindProperty(serializedProperty.FindPropertyRelative("_id"));
            nameTextField.BindProperty(serializedProperty.FindPropertyRelative("_name"));
            titleTextField.BindProperty(serializedProperty.FindPropertyRelative("_title"));
            iconField.BindProperty(serializedProperty.FindPropertyRelative("_icon"));
            descriptionTextField.BindProperty(serializedProperty.FindPropertyRelative("_description"));
            definitionFoldout.text = $"{serializedProperty.FindPropertyRelative("_id").stringValue}_{serializedProperty.FindPropertyRelative("_name").stringValue}";
            copyButton.clicked += OnClickCopy;

            iconPreviewImage.sprite = serializedProperty.FindPropertyRelative("_icon")?.objectReferenceValue as Sprite;
            iconField.RegisterValueChangedCallback(value =>
            {
                iconPreviewImage.sprite = value.newValue as Sprite;
            });
            iconPreviewImage.sprite = serializedProperty.FindPropertyRelative("_icon")?.objectReferenceValue as Sprite;

            idTextField.RegisterValueChangedCallback(value =>
            {
                definitionFoldout.text = $"{serializedProperty.FindPropertyRelative("_id").stringValue}_{serializedProperty.FindPropertyRelative("_name").stringValue}";
            });
            nameTextField.RegisterValueChangedCallback(value =>
            {
                definitionFoldout.text = $"{serializedProperty.FindPropertyRelative("_id").stringValue}_{serializedProperty.FindPropertyRelative("_name").stringValue}";
            });

            Root.MarkDirtyRepaint();
        }

        private void OnClickCopy()
        {
            EditorGUIUtility.systemCopyBuffer =
            serializedProperty.FindPropertyRelative("_id")?.stringValue;
        }
    }
}